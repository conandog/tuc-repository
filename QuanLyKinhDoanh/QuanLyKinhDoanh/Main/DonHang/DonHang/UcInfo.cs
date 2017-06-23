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
    public partial class UcInfo : UserControl
    {
        //private DTO.SanPham dataSP;
        //private DTO.KhachHang dataKH;
        //private DTO.ChietKhau dataCK;
        //private DTO.HoaDon dataHoaDon;
        //private DTO.HoaDonDetail dataHoaDonDetail;
        //private List<DTO.SanPham> listDataSP;

        private long totalMoney;

        public UcInfo()
        {
            InitializeComponent();

            if (Init())
            {
                RefreshData();
            }
            else
            {
                this.Visible = false;
            }
        }

        private void LoadResource()
        {
            try
            {
                pbAdd.Image = Image.FromFile(ConstantResource.GIAODICH_ICON_CART_ADD);
                pbHoanTat.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_OK_DISABLE);
                pbXoa.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_DELETE_DISABLE);
            }
            catch
            {
                MessageBox.Show(Constant.MESSAGE_ERROR_MISSING_RESOURCE, Constant.CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Dispose();
            }
        }

        private void UcOrder_Load(object sender, EventArgs e)
        {
            LoadResource();
            //pnInfo.Location = CommonFunc.SetWidthCenter(this.Size, pnInfo.Size, pnInfo.Top);
            this.BringToFront();
            FormMain.isEditing = true;
            ValidateInput();
            tbTenSP.Focus();
        }



        #region Function
        private bool Init()
        {
            //listDataSP = SanPhamBus.GetList(string.Empty, 0, true, Constant.DEFAULT_STATUS_SP_NOT_ZERO,
            //    false, 0,
            //    string.Empty, string.Empty, 0, 0);

            //GetListSP(listDataSP);
            //GetListKhachHang();
            //GetListHoaDonStatus();

            return true;
        }

        private void RefreshData()
        {
            totalMoney = 0;

            lvThongTin.Items.Clear();
            dtpNgayGio.Value = DateTime.Now;
            dtpNgayGio.CustomFormat = Constant.DEFAULT_DATE_TIME_FORMAT;
            lbNgayGio.Text = dtpNgayGio.Value.ToString(Constant.DEFAULT_DATE_TIME_FORMAT);

            tbTenSP.Text = String.Empty;
            tbMaSP.Text = String.Empty;
            tbSoLuong.Text = "1";
            tbDonGia.Text = String.Empty;
            tbThanhTien.Text = String.Empty;

            tbTenKH.Text = string.Empty;
            tbDienThoai.Text = string.Empty;
            tbDiaChi.Text = string.Empty;

            tbMaCOD.Text = string.Empty;
            cbLoaiCOD.Text = string.Empty;
            tbGiaCOD.Text = string.Empty;
            tbTongHoaDon.Text = string.Empty;
            cbTinhTrang.SelectedIndex = 0;
            tbGhiChu.Text = String.Empty;

            pbXoa.Enabled = false;
            pbXoa.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_DELETE_DISABLE);

            tbMaHD.Text = CreateNewId().ToString();
            ValidateHoanTat();
        }

        private void ValidateInput()
        {
            if (!string.IsNullOrEmpty(tbTenSP.Text) &&
                !string.IsNullOrEmpty(tbSoLuong.Text) &&
                !string.IsNullOrEmpty(tbThanhTien.Text)
                )
            {
                pbAdd.Enabled = true;
                pbAdd.Image = Image.FromFile(ConstantResource.GIAODICH_ICON_CART_ADD);
            }
            else
            {
                pbAdd.Enabled = false;
                pbAdd.Image = Image.FromFile(ConstantResource.GIAODICH_ICON_CART_ADD_DISABLE);
            }
        }

        private void ValidateHoanTat()
        {
            if (lvThongTin.Items.Count > 0)
            {
                pbHoanTat.Enabled = false;
                pbHoanTat.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_OK_DISABLE);

                if (!String.IsNullOrEmpty(tbTenKH.Text))
                {
                    pbHoanTat.Enabled = true;
                    pbHoanTat.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_OK);
                }
            }
            else
            {
                pbHoanTat.Enabled = false;
                pbHoanTat.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_OK_DISABLE);

                pbXoa.Enabled = false;
                pbXoa.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_DELETE_DISABLE);
            }
        }

        private void CheckListViewItemsIsChecked()
        {
            if (lvThongTin.CheckedItems.Count > 0)
            {
                pbXoa.Enabled = true;
                pbXoa.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_DELETE);
            }
            else
            {
                pbXoa.Enabled = false;
                pbXoa.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_DELETE_DISABLE);
            }
        }

        private void CalculateMoney()
        {
            long money = ConvertUtil.ConvertToLong(tbDonGia.Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty)) * ConvertUtil.ConvertToInt(tbSoLuong.Text);
            tbThanhTien.Text = money.ToString(Constant.DEFAULT_FORMAT_MONEY);
        }

        private void AddToBill()
        {
            int soLuong = 0;
            bool isDuplicated = false;

            foreach (ListViewItem item in lvThongTin.Items)
            {
                if (item.SubItems[3].Text == tbMaSP.Text)
                {
                    soLuong = ConvertUtil.ConvertToInt(item.SubItems[4].Text) + ConvertUtil.ConvertToInt(tbSoLuong.Text);
                    item.SubItems[4].Text = soLuong.ToString();
                    item.SubItems[6].Text = (ConvertUtil.ConvertToInt(tbThanhTien.Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty)) +
                        ConvertUtil.ConvertToInt(item.SubItems[6].Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty))).ToString(Constant.DEFAULT_FORMAT_MONEY);
                    isDuplicated = true;
                    break;
                }
            }

            totalMoney += ConvertUtil.ConvertToLong(tbThanhTien.Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty));
            tbTongHoaDon.Text = totalMoney.ToString(Constant.DEFAULT_FORMAT_MONEY);

            if (!isDuplicated)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add((lvThongTin.Items.Count + 1).ToString());
                lvi.SubItems.Add(tbTenSP.Text);
                lvi.SubItems.Add(tbMaSP.Text);
                lvi.SubItems.Add(tbSoLuong.Text);
                lvi.SubItems.Add(tbDonGia.Text);
                lvi.SubItems.Add(tbThanhTien.Text);
                lvThongTin.Items.Add(lvi);
            }

            tbSoLuong.Text = "1";
            tbGiaCOD_TextChanged(null, null);
        }

        private void RemoveFromBill()
        {
            if (MessageBox.Show(Constant.MESSAGE_DELETE_CONFIRM, Constant.CAPTION_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string ids = string.Empty;

                foreach (ListViewItem lvi in lvThongTin.CheckedItems)
                {
                    long money = ConvertUtil.ConvertToLong(lvi.SubItems[6].Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty));
                    totalMoney -= ConvertUtil.ConvertToLong(money);
                    tbTongHoaDon.Text = totalMoney.ToString(Constant.DEFAULT_FORMAT_MONEY);
                    lvThongTin.Items.Remove(lvi);

                    for (int i = 0; i < lvThongTin.Items.Count; i++)
                    {
                        lvThongTin.Items[i].SubItems[1].Text = (i + 1).ToString();
                    }
                }
            }

            tbGiaCOD_TextChanged(null, null);
        }

        private int CreateNewId()
        {
            DTO.Order dataTemp = OrderBus.GetLastData();
            return dataTemp == null ? 1 : dataTemp.Id + 1;
        }

        private void ExportBill()
        {
            string path = File_Function.SaveDialog("HoaDon_" + tbMaHD.Text + "_" + DateTime.Now.ToString(Constant.DEFAULT_EXPORT_EXCEL_DATE_FORMAT), Constant.DEFAULT_EXPORT_EXCEL_FILE_TYPE_NAME, Constant.DEFAULT_EXPORT_EXCEL_FILE_TYPE);

            if (path != null)
            {
                ListView lvInfoNew = new ListView();

                for (int i = 2; i < lvThongTin.Columns.Count; i++)
                {
                    lvInfoNew.Columns.Add((ColumnHeader)lvThongTin.Columns[i].Clone());
                }

                for (int i = 0; i < lvThongTin.Items.Count; i++)
                {
                    ListViewItem lviInfo = new ListViewItem();
                    lviInfo.SubItems[0].Text = lvThongTin.Items[i].SubItems[1].Text; //STT
                    lviInfo.SubItems.Add(lvThongTin.Items[i].SubItems[2].Text); //SP
                    lviInfo.SubItems.Add(lvThongTin.Items[i].SubItems[3].Text); //ma SP
                    lviInfo.SubItems.Add(lvThongTin.Items[i].SubItems[4].Text); //SL
                    lviInfo.SubItems.Add(lvThongTin.Items[i].SubItems[5].Text); //don gia
                    lviInfo.SubItems.Add(lvThongTin.Items[i].SubItems[6].Text); //thanh tien
                    lvInfoNew.Items.Add(lviInfo);
                }

                ExportExcel.InitWorkBook("Hóa đơn bán hàng");
                ExportExcel.CreateSummaryHoaDon(tbMaHD.Text, FormMain.user.Ten, tbTenKH.Text,
                    dtpNgayGio.Value, "-1", tbTongHoaDon.Text);

                ExportExcel.CreateDetailsTableHoaDon(lvInfoNew);

                ExportExcel.SaveExcel(path);
            }
        }

        private void InsertData()
        {
            InsertDataOrder();
        }

        private void InsertDataOrder()
        {
            int idHD = ConvertUtil.ConvertToInt(tbMaHD.Text);
            long totalBill = ConvertUtil.ConvertToLong(tbTongHoaDon.Text);
            long codBill = ConvertUtil.ConvertToLong(tbGiaCOD.Text);
            double codWeight = ConvertUtil.ConvertToDouble(tbTongHoaDon.Text);

            DTO.Order order = new DTO.Order(idHD, tbTenKH.Text, tbDienThoai.Text, tbDiaChi.Text,
                totalBill, cbTinhTrang.Text, tbMaCOD.Text, codWeight, codBill, tbGhiChu.Text,
                GetListDetail());

            if (OrderBus.Insert(order, FormMain.user))
            {
                if (MessageBox.Show(Constant.MESSAGE_CONFIRM_EXPORT, Constant.CAPTION_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    ExportBill();
                }

                RefreshData();
            }
            else
            {
                MessageBox.Show(Constant.MESSAGE_INSERT_ERROR + Constant.MESSAGE_NEW_LINE + Constant.MESSAGE_EXIT, Constant.CAPTION_ERROR, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private List<OrderDetails> GetListDetail()
        {
            List<OrderDetails> res = new List<OrderDetails>();

            foreach (ListViewItem lvi in lvThongTin.Items)
            {
                int quantity = ConvertUtil.ConvertToInt(lvi.SubItems[4].Text);
                long price = ConvertUtil.ConvertToLong(lvi.SubItems[5].Text);
                long total = ConvertUtil.ConvertToLong(lvi.SubItems[6].Text);

                OrderDetails detail = new OrderDetails(lvi.SubItems[2].Text, lvi.SubItems[3].Text, quantity, price, total);
            }

            return res;
        }

        private void InsertDataHoaDonDetail(int idHoaDon)
        {
            //foreach (ListViewItem lvi in lvThongTin.Items)
            //{
            //    dataHoaDonDetail = new HoaDonDetail();

            //    dataHoaDonDetail.IdHoaDon = idHoaDon;
            //    dataHoaDonDetail.IdSanPham = ConvertUtil.ConvertToInt(lvi.SubItems[1].Text);
            //    dataHoaDonDetail.ChietKhau = ConvertUtil.ConvertToInt(lvi.SubItems[4].Text.Replace(Constant.SYMBOL_DISCOUNT, ""));
            //    dataHoaDonDetail.SoLuong = ConvertUtil.ConvertToInt(lvi.SubItems[6].Text);
            //    dataHoaDonDetail.DonGia = ConvertUtil.ConvertToLong(lvi.SubItems[8].Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty));
            //    dataHoaDonDetail.ThanhTien = ConvertUtil.ConvertToLong(lvi.SubItems[9].Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty));

            //    if (HoaDonDetailBus.Insert(dataHoaDonDetail))
            //    {
            //        UpdateDataSP(dataHoaDonDetail.SanPham, dataHoaDonDetail.SoLuong);
            //    }
            //    else
            //    {
            //        try
            //        {
            //            HoaDonDetailBus.Delete(dataHoaDonDetail);
            //        }
            //        catch
            //        {
            //            //
            //        }

            //        MessageBox.Show(Constant.MESSAGE_INSERT_ERROR + Constant.MESSAGE_NEW_LINE + Constant.MESSAGE_EXIT, Constant.CAPTION_ERROR, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    }
            //}
        }

        private void UpdateDataSP(DTO.SanPham dataUpdate, int soLuong)
        {
            if (dataUpdate != null)
            {
                dataUpdate.SoLuong -= soLuong;
                dataUpdate.IsSold = true;

                if (SanPhamBus.Update(dataUpdate, FormMain.user))
                {
                    //this.Dispose();
                }
                else
                {
                    MessageBox.Show(Constant.MESSAGE_ERROR + Constant.MESSAGE_NEW_LINE + Constant.MESSAGE_EXIT, Constant.CAPTION_ERROR, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion



        #region Button
        private void pbAdd_Click(object sender, EventArgs e)
        {
            pbAdd.Focus();
            AddToBill();
            ValidateHoanTat();
            tbTenSP.Focus();
        }

        private void pbAdd_MouseEnter(object sender, EventArgs e)
        {
            pbAdd.Image = Image.FromFile(ConstantResource.GIAODICH_ICON_CART_ADD_MOUSEOVER);
        }

        private void pbAdd_MouseLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSoLuong.Text))
            {
                pbAdd.Image = Image.FromFile(ConstantResource.GIAODICH_ICON_CART_ADD);
            }
        }

        private void pbHoanTat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Constant.MESSAGE_CONFIRM, Constant.CAPTION_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                InsertData();
            }
        }

        private void pbHoanTat_MouseEnter(object sender, EventArgs e)
        {
            pbHoanTat.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_OK_MOUSEOVER);
        }

        private void pbHoanTat_MouseLeave(object sender, EventArgs e)
        {
            pbHoanTat.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_OK);
        }

        private void pbXoa_Click(object sender, EventArgs e)
        {
            RemoveFromBill();
            ValidateHoanTat();
        }

        private void pbXoa_MouseEnter(object sender, EventArgs e)
        {
            pbXoa.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_DELETE_MOUSEOVER);
        }

        private void pbXoa_MouseLeave(object sender, EventArgs e)
        {
            pbXoa.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_DELETE);
        }
        #endregion



        #region Controls
        private void tbGiaBan_TextChanged(object sender, EventArgs e)
        {
            long money = ConvertUtil.ConvertToLong(tbDonGia.Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty));
            tbDonGia.Text = money.ToString(Constant.DEFAULT_FORMAT_MONEY);
            tbDonGia.Select(tbDonGia.Text.Length, 0);

            CalculateMoney();
            ValidateInput();
        }

        private void tbSoLuong_TextChanged(object sender, EventArgs e)
        {
            tbSoLuong.Text = ConvertUtil.ConvertToInt(tbSoLuong.Text) == 0 ? string.Empty :
                ConvertUtil.ConvertToInt(tbSoLuong.Text).ToString();

            CalculateMoney();
            ValidateInput();
        }

        private void lvThongTin_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void lvThongTin_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.NewWidth = 30;
                e.Cancel = true;
            }
        }

        private void lvThongTin_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0 && lvThongTin.Items.Count > 0)
            {
                bool isChecked = lvThongTin.Items[0].Checked;

                foreach (ListViewItem item in lvThongTin.Items)
                {
                    item.Checked = !isChecked;
                }
            }
        }

        private void lvThongTin_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            CheckListViewItemsIsChecked();
        }

        private void tbSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonFunc.ValidateNumeric(e);
            AddToBillWhenPressEnter(sender, e);
        }

        private void AddToBillWhenPressEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && pbAdd.Enabled)
            {
                pbAdd_Click(sender, e);
            }
        }

        private void tbTenSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddToBillWhenPressEnter(sender, e);
        }

        private void tbMaSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddToBillWhenPressEnter(sender, e);
        }

        private void tbGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddToBillWhenPressEnter(sender, e);
        }

        private void tbThanhTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddToBillWhenPressEnter(sender, e);
        }
        #endregion

        private void tbGiaCOD_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonFunc.ValidateNumeric(e);
        }

        private void tbMaSP_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
        }

        private void tbTenSP_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
        }

        private void tbGiaCOD_TextChanged(object sender, EventArgs e)
        {
            long money = ConvertUtil.ConvertToLong(tbGiaCOD.Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty));
            tbGiaCOD.Text = money.ToString(Constant.DEFAULT_FORMAT_MONEY);
            tbGiaCOD.Select(tbGiaCOD.Text.Length, 0);

            tbTongHoaDon.Text = (totalMoney + money).ToString(Constant.DEFAULT_FORMAT_MONEY);
        }

        private void tbTrongLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && tbTrongLuong.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
            }
            else if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}