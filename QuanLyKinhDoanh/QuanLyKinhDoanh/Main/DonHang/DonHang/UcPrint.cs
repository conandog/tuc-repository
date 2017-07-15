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

namespace QuanLyKinhDoanh.Order
{
    public partial class UcPrint : UserControl
    {
        public UcPrint()
        {
            InitializeComponent();
        }

        public UcPrint(DTO.Order data)
        {
            InitializeComponent();
            LoadData(data);
        }

        private void LoadData(DTO.Order data)
        {
            lbMaHDNgayGio.Text = "HĐ: " + data.Id + Constant.SYMBOL_LINK_STRING + data.CreatedDate.ToString(Constant.DEFAULT_DATE_TIME_FORMAT);

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
    }
}
