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
using System.Configuration;

namespace QuanLyKinhDoanh.Order
{
    public partial class UcInfo : UserControl
    {
        private long totalMoney;
        private long codMoney;
        private bool isUpdate;

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

        public UcInfo(DTO.Order data)
        {
            InitializeComponent();
            isUpdate = true;
            RefreshData();
            lbSelect.Text = Constant.DEFAULT_TITLE_EDIT;

            if (Init())
            {
                tbTenSP.Enabled = false;
                tbMaSP.Enabled = false;
                tbSoLuong.Enabled = false;
                tbDonGia.Enabled = false;
                tbThanhTien.Enabled = false;
                pbXoa.Visible = false;
                pbAdd.Visible = false;

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

                tbMaCOD.ReadOnly = true;
                tbMaCOD.Text = data.CodCode;
                tbTrongLuong.ReadOnly = true;
                tbTrongLuong.Text = data.CodWeight == 0 ? String.Empty : data.CodWeight.ToString();
                cbLoaiCOD.Enabled = false;
                cbLoaiCOD.Text = data.CodType;
                codMoney = data.CodBill;
                tbGiaCOD.ReadOnly = true;
                tbGiaCOD.Text = codMoney.ToString(Constant.DEFAULT_FORMAT_MONEY);
                cbTinhTrang.Text = data.Status;

                tbMaHD.Text = data.Id.ToString();
                totalMoney = data.TotalBill;
                tbTongHoaDon.Text = (totalMoney + codMoney).ToString(Constant.DEFAULT_FORMAT_MONEY);
                tbGhiChu.Text = data.Notes;

                tbTenKH.ReadOnly = true;
                tbTenKH.Text = data.Name;
                tbDienThoai.Text = data.Phone;
                tbContact.Text = data.Contact;
                tbDiaChi.Text = data.Address;

                if (data.Status != DTO.Order.ListStatus[0])
                {
                    cbTinhTrang.Enabled = false;
                }
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
                pbXoa.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_DELETE_DISABLE);
                pbHoanTat.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_OK_DISABLE);
                pbHuy.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_CANCEL);
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

            if (isUpdate)
            {
                ValidateHoanTat();
            }

            tbTenSP.Focus();
        }



        #region Function
        private bool Init()
        {
            return true;
        }

        private void RefreshData()
        {
            totalMoney = 0;
            codMoney = 0;

            lvThongTin.Items.Clear();
            dtpNgayGio.Value = DateTime.Now;
            dtpNgayGio.CustomFormat = Constant.DEFAULT_DATE_TIME_FORMAT;
            lbNgayGio.Text = dtpNgayGio.Value.ToString(Constant.DEFAULT_DATE_TIME_FORMAT);

            tbTenSP.Text = String.Empty;
            tbMaSP.Text = String.Empty;
            tbSoLuong.Text = String.Empty;
            tbDonGia.Text = String.Empty;
            tbThanhTien.Text = String.Empty;

            tbMaCOD.Text = String.Empty;
            tbTrongLuong.Text = String.Empty;
            cbLoaiCOD.Text = String.Empty;
            tbGiaCOD.Text = String.Empty;

            if (cbTinhTrang.Items.Count == 0)
            {
                cbTinhTrang.Items.AddRange(DTO.Order.ListStatus.ToArray());
            }

            cbTinhTrang.SelectedIndex = 0;

            tbMaHD.Text = CreateNewId().ToString();
            tbTongHoaDon.Text = String.Empty;
            tbGhiChu.Text = String.Empty;

            tbTenKH.Text = String.Empty;
            tbDienThoai.Text = String.Empty;
            tbDiaChi.Text = String.Empty;

            pbXoa.Enabled = false;
            pbXoa.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_DELETE_DISABLE);

            
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
            //int soLuong = 0;
            bool isDuplicated = false;

            //foreach (ListViewItem item in lvThongTin.Items)
            //{
            //    if (item.SubItems[3].Text == tbMaSP.Text)
            //    {
            //        soLuong = ConvertUtil.ConvertToInt(item.SubItems[4].Text) + ConvertUtil.ConvertToInt(tbSoLuong.Text);
            //        item.SubItems[4].Text = soLuong.ToString();
            //        item.SubItems[6].Text = (ConvertUtil.ConvertToInt(tbThanhTien.Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty)) +
            //            ConvertUtil.ConvertToInt(item.SubItems[6].Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty))).ToString(Constant.DEFAULT_FORMAT_MONEY);
            //        isDuplicated = true;
            //        break;
            //    }
            //}

            totalMoney += ConvertUtil.ConvertToLong(tbThanhTien.Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty));
            tbTongHoaDon.Text = (totalMoney + codMoney).ToString(Constant.DEFAULT_FORMAT_MONEY);

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
            CheckItemsToSetCodBill();
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
                    tbTongHoaDon.Text = (totalMoney + codMoney).ToString(Constant.DEFAULT_FORMAT_MONEY);
                    lvThongTin.Items.Remove(lvi);

                    for (int i = 0; i < lvThongTin.Items.Count; i++)
                    {
                        lvThongTin.Items[i].SubItems[1].Text = (i + 1).ToString();
                    }
                }
            }

            CheckItemsToSetCodBill();
            tbGiaCOD_TextChanged(null, null);
        }

        private void CheckItemsToSetCodBill()
        {
            int defaultItemsForFreeCod = ConvertUtil.ConvertToInt(ConfigurationManager.AppSettings["soluongspmienphigh"]);
            string defaultCodBill = ConfigurationManager.AppSettings["giacuoc"] == null ? "30000" : ConfigurationManager.AppSettings["giacuoc"];

            //set default to 3 if there is no setting
            if (defaultItemsForFreeCod == 0)
            {
                defaultItemsForFreeCod = 3;
            }

            string currentCodBill = tbGiaCOD.Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty);

            if (String.IsNullOrEmpty(tbGiaCOD.Text) || currentCodBill == defaultCodBill)
            {
                if (lvThongTin.Items.Count < defaultItemsForFreeCod)
                {
                    tbGiaCOD.Text = defaultCodBill;
                }
                else
                {
                    tbGiaCOD.Text = String.Empty;
                }
            }
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
            double codWeight = ConvertUtil.ConvertToDouble(tbTrongLuong.Text);

            DTO.Order order = new DTO.Order(idHD, tbTenKH.Text, tbDienThoai.Text, tbContact.Text, tbDiaChi.Text,
                totalMoney, cbTinhTrang.Text, tbMaCOD.Text, cbLoaiCOD.Text, codWeight, codMoney, tbGhiChu.Text,
                GetListDetail());

            if (OrderBus.Insert(order, FormMain.user))
            {
                //if (MessageBox.Show(Constant.MESSAGE_CONFIRM_EXPORT, Constant.CAPTION_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                //{
                //    ExportBill();
                //}

                MessageBox.Show(String.Format(Constant.MESSAGE_INSERT_SUCCESS, "Hóa đơn " + order.Id), Constant.CAPTION_CONFIRM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();
            }
            else
            {
                if (MessageBox.Show(Constant.MESSAGE_INSERT_ERROR + Constant.MESSAGE_NEW_LINE + Constant.MESSAGE_TRY_AGAIN, Constant.CAPTION_ERROR, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (OrderBus.Insert(order, FormMain.user))
                    {
                        //if (MessageBox.Show(String.Format(Constant.MESSAGE_INSERT_SUCCESS, "Đơn hàng " + order.Id) + Constant.MESSAGE_NEW_LINE + Constant.MESSAGE_CONFIRM_EXPORT, Constant.CAPTION_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        //{
                        //    ExportBill();
                        //}

                        MessageBox.Show(String.Format(Constant.MESSAGE_INSERT_SUCCESS, "Hóa đơn " + order.Id), Constant.CAPTION_CONFIRM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshData();
                    }
                    else
                    {
                        MessageBox.Show(Constant.MESSAGE_INSERT_ERROR + Constant.MESSAGE_NEW_LINE + Constant.MESSAGE_EXIT, Constant.CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private List<OrderDetails> GetListDetail()
        {
            List<OrderDetails> res = new List<OrderDetails>();

            foreach (ListViewItem lvi in lvThongTin.Items)
            {
                int quantity = ConvertUtil.ConvertToInt(lvi.SubItems[4].Text);
                long price = ConvertUtil.ConvertToLong(lvi.SubItems[5].Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty));
                long total = ConvertUtil.ConvertToLong(lvi.SubItems[6].Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty));
                OrderDetails detail = new OrderDetails(lvi.SubItems[2].Text, lvi.SubItems[3].Text, quantity, price, total);
                res.Add(detail);
            }

            return res;
        }

        private void UpdateData()
        {
            int idHD = ConvertUtil.ConvertToInt(tbMaHD.Text);
            double codWeight = ConvertUtil.ConvertToDouble(tbTrongLuong.Text);

            DTO.Order order = new DTO.Order(idHD, tbTenKH.Text, tbDienThoai.Text, tbContact.Text, tbDiaChi.Text,
                totalMoney, cbTinhTrang.Text, tbMaCOD.Text, cbLoaiCOD.Text, codWeight, codMoney, tbGhiChu.Text,
                GetListDetail());

            if (OrderBus.Update(order, FormMain.user))
            {
                this.Dispose();
            }
            else
            {
                if (MessageBox.Show(Constant.MESSAGE_ERROR + Constant.MESSAGE_NEW_LINE + Constant.MESSAGE_EXIT, Constant.CAPTION_ERROR, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    this.Dispose();
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
                if (!isUpdate)
                {
                    InsertData();
                }
                else
                {
                    UpdateData();
                }
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

        private void pbHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Constant.MESSAGE_EXIT, Constant.CAPTION_WARNING, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void pbHuy_MouseEnter(object sender, EventArgs e)
        {
            pbHuy.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_CANCEL_MOUSEOVER);
        }

        private void pbHuy_MouseLeave(object sender, EventArgs e)
        {
            pbHuy.Image = Image.FromFile(ConstantResource.CHUC_NANG_ICON_CANCEL);
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
            codMoney = ConvertUtil.ConvertToLong(tbGiaCOD.Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty));
            tbGiaCOD.Text = codMoney.ToString(Constant.DEFAULT_FORMAT_MONEY);
            tbGiaCOD.Select(tbGiaCOD.Text.Length, 0);

            tbTongHoaDon.Text = (totalMoney + codMoney).ToString(Constant.DEFAULT_FORMAT_MONEY);
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

        private void tbTenKH_TextChanged(object sender, EventArgs e)
        {
            ValidateHoanTat();
        }

        private void tbSoLuong_Enter(object sender, EventArgs e)
        {
            tbSoLuong.SelectAll();
        }

        private void tbDonGia_Enter(object sender, EventArgs e)
        {
            tbDonGia.SelectAll();
        }

        private void tbTrongLuong_Enter(object sender, EventArgs e)
        {
            tbTrongLuong.SelectAll();
        }

        private void tbGiaCOD_Enter(object sender, EventArgs e)
        {
            tbGiaCOD.SelectAll();
        }
    }
}