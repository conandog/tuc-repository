using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Library;
using System.Drawing.Printing;

namespace QuanLyKinhDoanh.Order
{
    public partial class UcPrint : UserControl
    {
        private PageSetupDialog pgSetupDialog;
        private PageSettings pgSettings;
        private PrinterSettings prtSettings;
        private PrintPreviewDialog dlg;

        public UcPrint()
        {
            InitializeComponent();
        }

        public UcPrint(DTO.Order data)
        {
            InitializeComponent();
            LoadData(data);
            InitPrintDefault();

            if (pgSetupDialog.PageSettings != null)
            {
                pgSettings = pgSetupDialog.PageSettings;
            }
            else
            {
                pgSettings.Landscape = false;
            }

            printDocumentBill.DefaultPageSettings = pgSettings;
            dlg.Document = printDocumentBill;

            ((Form)dlg).WindowState = FormWindowState.Maximized;
            dlg.ShowDialog();
        }

        private void LoadData(DTO.Order data)
        {
            lbMaHDNgayGio.Text = "HĐ: " + data.Id + Constant.SYMBOL_LINK_STRING + data.UpdatedDate.ToString(Constant.DEFAULT_DATE_TIME_FORMAT);

            foreach (var detail in data.ListDetail)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add((lvThongTin.Items.Count + 1).ToString());
                lvi.SubItems.Add(detail.Name);
                lvi.SubItems.Add(detail.Id);
                lvi.SubItems.Add(detail.Quantity.ToString());
                lvi.SubItems.Add(detail.Price.ToString(Constant.DEFAULT_FORMAT_MONEY));
                lvi.SubItems.Add(detail.Total.ToString(Constant.DEFAULT_FORMAT_MONEY));
                lvThongTin.Items.Add(lvi);
            }

            ListViewItem cod = new ListViewItem();
            cod.SubItems.Add((lvThongTin.Items.Count + 1).ToString());
            cod.SubItems.Add("Giá cước");
            cod.SubItems.Add(String.Empty);
            cod.SubItems.Add(String.Empty);
            cod.SubItems.Add(String.Empty);
            cod.SubItems.Add(ConvertUtil.ConvertToLong(data.CodBill) == 0 ? "Miễn phí" : data.CodBill.ToString(Constant.DEFAULT_FORMAT_MONEY));
            lvThongTin.Items.Add(cod);

            lbTongHD.Text = lbTongHD.Text + data.GetTotalBillWithCod().ToString(Constant.DEFAULT_FORMAT_MONEY) + Constant.DEFAULT_MONEY_SUBFIX;
            lbKhachHang.Text = data.Name;
            lbDiaChi.Text = data.Address;
            lbDT.Text = data.Phone;
        }

        private void UcPrint_Load(object sender, EventArgs e)
        {
            pbLogo.Image = Image.FromFile(ConstantResource.DONHANG_ICON_DONHANG_PRINT_LOGO);
            LoadDataFromConfig();
        }

        private void LoadDataFromConfig()
        {
            try
            {
                string infor1 = ConfigurationManager.AppSettings["print_thong_tin_1"];
                string infor2 = ConfigurationManager.AppSettings["print_thong_tin_2"];
                string infor3 = ConfigurationManager.AppSettings["print_thong_tin_3"];
                string slogan = ConfigurationManager.AppSettings["print_tieu_chi"];

                lbInfor1.Text = String.IsNullOrEmpty(infor1) ? lbInfor1.Text : infor1;
                lbInfor2.Text = String.IsNullOrEmpty(infor2) ? String.Empty : infor2;
                lbInfor3.Text = String.IsNullOrEmpty(infor3) ? lbInfor3.Text : infor3;
                lbTieuChi.Text = String.IsNullOrEmpty(slogan) ? lbTieuChi.Text : slogan;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constant.CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitPrintDefault()
        {
            pgSetupDialog = new PageSetupDialog();
            pgSettings = new PageSettings();
            prtSettings = new PrinterSettings();
            dlg = new PrintPreviewDialog();

            IEnumerable<PaperSize> paperSizes = printDocumentBill.PrinterSettings.PaperSizes.Cast<PaperSize>();
            PaperSize sizeA5 = null;

            if (paperSizes.Any(size => size.Kind == PaperKind.A5))
            {
                sizeA5 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A5);
            }
            else
            {
                sizeA5 = new PaperSize("Custom", 583, 827);
            }

            pgSettings.PaperSize = sizeA5;
            pgSettings.Margins = new Margins(0, 0, 0, 0);
            pgSetupDialog.PageSettings = pgSettings;
            pgSetupDialog.PageSettings.PaperSize = pgSettings.PaperSize;
            pgSetupDialog.PageSettings.Landscape = false;
            pgSetupDialog.PrinterSettings = prtSettings;
            pgSetupDialog.AllowOrientation = true;
            pgSetupDialog.AllowMargins = false;
        }

        private void printDocumentBill_PrintPage(object sender, PrintPageEventArgs e)
        {
            var bitmap = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
