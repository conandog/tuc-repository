using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library;
using DTO;
using BUS;

namespace QuanLyKinhDoanh.Order
{
    public partial class UcDetail : UserControl
    {
        public UcDetail()
        {
            InitializeComponent();
        }

        public UcDetail(DTO.Order data)
        {
            InitializeComponent();

            Init();
            LoadData(data);
        }

        private void LoadResource()
        {
            try
            {
                pbHoanTat.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_OK);
            }
            catch
            {
                MessageBox.Show(Constant.MESSAGE_ERROR_MISSING_RESOURCE, Constant.CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Dispose();
            }
        }

        private void UcDetail_Load(object sender, EventArgs e)
        {
            LoadResource();
            pnTitle.Location = CommonFunc.SetWidthCenter(this.Size, pnTitle.Size, pnTitle.Top);
            this.BringToFront();
        }

        private void Init()
        {
            lvThongTin.Items.Clear();
            lbNgayGio.Text = DateTime.Now.ToString(Constant.DEFAULT_DATE_TIME_FORMAT);

            lbMaCOD.Text = String.Empty;
            lbTrongLuong.Text = String.Empty;
            lbLoaiCOD.Text = String.Empty;
            lbGiaCOD.Text = String.Empty;
            lbTinhTrang.Text = String.Empty;

            lbMaHD.Text = String.Empty;
            lbTongHD.Text = String.Empty;
            lbGhiChu.Text = String.Empty;

            lbKhachHang.Text = String.Empty;
            lbDienThoai.Text = String.Empty;
            lbDiaChi.Text = String.Empty;
            
        }

        private void LoadData(DTO.Order data)
        {
            lbNgayGio.Text = data.CreatedDate.ToString(Constant.DEFAULT_DATE_TIME_FORMAT);

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

            
            lbMaCOD.Text = data.CodCode;
            lbTrongLuong.Text = data.CodWeight == 0 ? String.Empty : data.CodWeight.ToString();
            lbLoaiCOD.Text = data.CodType;
            lbGiaCOD.Text = data.CodBill.ToString(Constant.DEFAULT_FORMAT_MONEY);
            lbTinhTrang.Text = data.Status;

            lbMaHD.Text = data.Id.ToString();
            lbTongHD.Text = data.GetTotalBillWithCod().ToString(Constant.DEFAULT_FORMAT_MONEY);
            lbGhiChu.Text = data.Notes;

            lbKhachHang.Text = data.Name;
            lbDienThoai.Text = data.Phone;
            lbContact.Text = data.Contact;
            lbDiaChi.Text = data.Address;
        }

        private void pbHoanTat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pbHoanTat_MouseEnter(object sender, EventArgs e)
        {
            pbHoanTat.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_OK_MOUSEOVER);
        }

        private void pbHoanTat_MouseLeave(object sender, EventArgs e)
        {
            pbHoanTat.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_OK);
        }
    }
}
