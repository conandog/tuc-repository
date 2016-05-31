using Controller.Implementation;
using Model;
using QuanLyDonHang.Common;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Controls.Primitives;


namespace QuanLyDonHang
{
    /// <summary>
    /// Interaction logic for PriceUC.xaml
    /// </summary>
    public partial class PriceUC : UserControl
    {
        private ItemMaster _historyMaster;
        private NhaThuoc _nhathuoc;
        private MasterChiPhi _master;

        public PriceUC()
        {
            InitializeComponent();
            RefreshData();
        }

        public void SetTbEditVisible()
        {
            tbAdd.Visibility = Visibility.Collapsed;
            tbEdit.Visibility = Visibility.Visible;
            btEdit.Visibility = Visibility.Visible;
        }

        public void SetDisplayData(ItemMaster _itemmaster)
        {
            _historyMaster = _itemmaster;
            if (!string.IsNullOrEmpty(_itemmaster.ngayorder))
                dateDateOrder.SelectedDate = DateTime.Parse(_itemmaster.ngayorder);
            Utilities.SelectCombobox(cbNT, _itemmaster.pharmacyname);
            Utilities.SelectCombobox(cbKhaoSat, _itemmaster.khaosat);
            Utilities.SelectCombobox(cbVanChuyen, _itemmaster.vanchuyen);
            Utilities.SelectCombobox(cbLapDat, _itemmaster.lapdat);
            Utilities.SelectCombobox(cbXinPhep, _itemmaster.xinphep);
            Utilities.SelectCombobox(cbThiCong, _itemmaster.HMTC);
            Utilities.SelectCombobox(cbMucKhac, _itemmaster.HMK);
            tbNgang.Text = _itemmaster.ngang.ToString();
            tbRong.Text = _itemmaster.rong.ToString();
            tbSluong.Text = _itemmaster.soluong.ToString();
            tbKSSluong.Text = _itemmaster.soluongKS.ToString();
            tbVCSluong.Text = _itemmaster.soluongVC.ToString();
            tbHMKSluong.Text = _itemmaster.soluongHMK.ToString();
            tbBrand1.Text = _itemmaster.brand1;
            tbBrand2.Text = _itemmaster.brand2;
        }

        public void SetDefaultData()
        {
            //dateDateOrder.SelectedDate = DateTime.Now;
            LoadDataComboCodeMer();
            LoadDataKhaoSat();
            LoadDataVanChuyen();
            LoadDataThiCong();
            LoadDataLapDat();
            LoadDataXinPhep();
            LoadDataMucKhac();
        }

        private void LoadData()
        {
            try
            {
                List<ItemMaster> _lsMasterItem = new List<ItemMaster>();
                int hisCount = HistoryImp.GetCount();
                List<History> _lshistory = HistoryImp.GetList(String.Empty, null, null, null, null, null,
                    null, null, null, String.Empty, false,
                    String.Empty, Controller.Common.CommonConstants.SORT_DESCENDING, 0, 3);

                int i = 1;
                foreach (History _history in _lshistory)
                {
                    _nhathuoc = NhaThuocImp.GetById(_history.IdNhaThuoc);
                    _master = MasterChiPhiImp.GetById(_history.IdMasterChiPhi);
                    ItemMaster _itemmaster = CreateGridItem(_master.STT, _history);
                    _lsMasterItem.Add(_itemmaster);
                    i++;
                }

                dgShowInfo.ItemsSource = _lsMasterItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ItemMaster CreateGridItem(int? stt, History history)
        {
            ItemMaster _itemmaster = new ItemMaster();

            try
            {
                _itemmaster.stt = stt;
                _itemmaster.ngayorder = history.NgayOrder.HasValue ? history.NgayOrder.Value.ToShortDateString() : String.Empty;
                _itemmaster.codemer = _nhathuoc.CodeMer;
                _itemmaster.pharmacyname = _nhathuoc.PharmacyName;
                _itemmaster.address = _nhathuoc.Address;
                _itemmaster.street = _nhathuoc.Street;
                _itemmaster.other = _nhathuoc.Other;
                _itemmaster.ward = _nhathuoc.Ward;
                _itemmaster.dictrict = _nhathuoc.District;
                _itemmaster.city = _nhathuoc.Province;
                Catalogue _cata;
                if (_master.IdCatalogueKS.HasValue)
                {
                    _cata = CatalogueImp.GetById((int)_master.IdCatalogueKS);
                    _itemmaster.khaosat = _cata.ItemDescription;
                    _itemmaster.chiphiKS = _cata.UnitPrice;
                    if (_master.SLKS.HasValue)
                    {
                        _itemmaster.soluongKS = _master.SLKS;
                        _itemmaster.tienKS = _itemmaster.soluongKS * _itemmaster.chiphiKS;
                    }
                }

                if (_master.IdCatalogueVC.HasValue)
                {
                    _cata = CatalogueImp.GetById((int)_master.IdCatalogueVC);
                    _itemmaster.vanchuyen = _cata.ItemDescription;
                    _itemmaster.chiphiVC = _cata.UnitPrice;
                    if (_master.SLVC.HasValue)
                    {
                        _itemmaster.soluongVC = _master.SLVC;
                        _itemmaster.tienVC = _itemmaster.soluongVC * _itemmaster.chiphiVC;
                    }
                }

                if (_master.IdCatalogueHMTC.HasValue)
                {
                    _cata = CatalogueImp.GetById((int)_master.IdCatalogueHMTC);
                    _itemmaster.HMTC = _cata.ItemDescription;
                    _itemmaster.donviHMTC = _cata.PartNumber;
                    _itemmaster.dongiaTC = _cata.UnitPrice;
                }

                if (_master.IdCatalogueLD.HasValue)
                {
                    _cata = CatalogueImp.GetById((int)_master.IdCatalogueLD);
                    _itemmaster.lapdat = _cata.ItemDescription;
                    _itemmaster.donviLD = _cata.PartNumber;
                    _itemmaster.dongiaLD = _cata.UnitPrice;
                }

                if (_master.IdCatalogueXP.HasValue)
                {
                    _cata = CatalogueImp.GetById((int)_master.IdCatalogueXP);
                    _itemmaster.xinphep = _cata.ItemDescription;
                    _itemmaster.donviXP = _cata.PartNumber;
                    _itemmaster.dongiaXP = _cata.UnitPrice;
                }

                double ngang = _master.Ngang.HasValue ? _master.Ngang.Value : 0;
                double rong = _master.Rong.HasValue ? _master.Rong.Value : 0;
                double soluong = _master.SLHMTC.HasValue ? _master.SLHMTC.Value : 0;
                double dientich = ngang * rong * soluong;
                _itemmaster.ngang = _master.Ngang;
                _itemmaster.rong = _master.Rong;
                _itemmaster.soluong = _master.SLHMTC;

                if (dientich != 0)
                {
                    _itemmaster.dientich = dientich;
                    _itemmaster.tienTC = _itemmaster.dientich * _itemmaster.dongiaTC;
                    _itemmaster.tienLD = _itemmaster.dientich * _itemmaster.dongiaLD;
                    _itemmaster.tienXP = _itemmaster.dientich * _itemmaster.dongiaXP;
                }

                if (_master.IdCatalogueHMK.HasValue)
                {
                    _cata = CatalogueImp.GetById((int)_master.IdCatalogueHMK);
                    _itemmaster.HMK = _cata.ItemDescription;
                    _itemmaster.donviHMK = _cata.PartNumber;
                    _itemmaster.dongiaHMK = _cata.UnitPrice;

                    if (_master.SLHMK.HasValue)
                    {
                        _itemmaster.soluongHMK = _master.SLHMK;
                        _itemmaster.tienHMK = _itemmaster.soluongHMK * _itemmaster.dongiaHMK;
                    }
                }

                _itemmaster.brand1 = _master.Brand1;
                _itemmaster.brand2 = _master.Brand2;
                _itemmaster.tongcong = Controller.Common.ConvertUtil.ConvertToDouble(_itemmaster.tienKS) +
                    Controller.Common.ConvertUtil.ConvertToDouble(_itemmaster.tienVC) +
                    Controller.Common.ConvertUtil.ConvertToDouble(_itemmaster.tienHMK) +
                    Controller.Common.ConvertUtil.ConvertToDouble(_itemmaster.tienLD) +
                    Controller.Common.ConvertUtil.ConvertToDouble(_itemmaster.tienTC) +
                    Controller.Common.ConvertUtil.ConvertToDouble(_itemmaster.tienXP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return _itemmaster;
        }

        # region combo_KhaoSat

        private void cbKhaoSat_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void cbKhaoSat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbKhaoSat.SelectedItem != null)
                {
                    Catalogue data = ((CommonComboBoxItem)cbKhaoSat.SelectedItem).Value as Catalogue;
                    if (data != null)
                        tbKSdgia.Text = data.UnitPrice.ToString();
                    else
                    {
                        tbKSdgia.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }
        }

        private void LoadDataKhaoSat()
        {
            LoadData(cbKhaoSat, CommonConstants.ITEMGROUP_KHAOSAT);
        }

        #endregion combo_KhaoSat

        # region combo_VanChuyen

        private void cbVanChuyen_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void cbVanChuyen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbVanChuyen.SelectedItem != null)
                {
                    Catalogue data = ((CommonComboBoxItem)cbVanChuyen.SelectedItem).Value as Catalogue;
                    if (data != null)
                        tbVCdgia.Text = data.UnitPrice.ToString();
                    else
                        tbVCdgia.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }
        }

        private void LoadDataVanChuyen()
        {
            LoadData(cbVanChuyen, CommonConstants.ITEMGROUP_VANCHUYEN);
        }

        #endregion combo_VanChuyen

        # region combo_ThiCong

        private void cbThiCong_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void cbThiCong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbThiCong.SelectedItem != null)
                {
                    Catalogue data = ((CommonComboBoxItem)cbThiCong.SelectedItem).Value as Catalogue;
                    if (data != null)
                    {
                        tbHMTCdgia.Text = data.UnitPrice.ToString();
                        tbHMTCdvi.Text = data.PartNumber;
                    }
                    else
                    {
                        tbHMTCdgia.Text = "";
                        tbHMTCdvi.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }
        }

        private void LoadDataThiCong()
        {
            LoadData(cbThiCong, CommonConstants.ITEMGROUP_HANGMUCTHICONG);
        }

        #endregion combo_ThiCong

        # region combo_LapDat

        private void cbLapDat_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void cbLapDat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbLapDat.SelectedItem != null)
                {
                    Catalogue data = ((CommonComboBoxItem)cbLapDat.SelectedItem).Value as Catalogue;
                    if (data != null)
                    {
                        tbLDdgia.Text = data.UnitPrice.ToString();
                        tbLDdvi.Text = data.PartNumber;
                    }
                    else
                    {
                        tbLDdgia.Text = "";
                        tbLDdvi.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }
        }

        private void LoadDataLapDat()
        {
            LoadData(cbLapDat, CommonConstants.ITEMGROUP_LAPDAT);
        }

        #endregion combo_LapDat

        # region combo_XinPhep

        private void cbXinPhep_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void cbXinPhep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbXinPhep.SelectedItem != null)
                {
                    Catalogue data = ((CommonComboBoxItem)cbXinPhep.SelectedItem).Value as Catalogue;
                    if (data != null)
                    {
                        tbXPdgia.Text = data.UnitPrice.ToString();
                        tbXPdvi.Text = data.PartNumber;
                    }
                    else
                    {
                        tbXPdgia.Text = "";
                        tbXPdvi.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }
        }

        private void LoadDataXinPhep()
        {
            LoadData(cbXinPhep, CommonConstants.ITEMGROUP_XINPHEP);
        }

        #endregion combo_XinPhep

        # region combo_MucKhac

        private void cbMucKhac_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void cbMucKhac_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbMucKhac.SelectedItem != null)
                {
                    Catalogue data = ((CommonComboBoxItem)cbMucKhac.SelectedItem).Value as Catalogue;
                    if (data != null)
                    {
                        tbHMKgia.Text = data.UnitPrice.ToString();
                        tbHMKdvi.Text = data.PartNumber;
                    }
                    else
                    {
                        tbHMKgia.Text = "";
                        tbHMKdvi.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }
        }

        private void LoadDataMucKhac()
        {
            LoadData(cbMucKhac, CommonConstants.ITEMGROUP_HANGMUCKHAC);
        }

        #endregion combo_MucKhac

        private void LoadData(ComboBox combo, string itemgroup)
        {
            try
            {
                List<Catalogue> listData = CatalogueImp.GetList(String.Empty, itemgroup, String.Empty, String.Empty, 0, 0);
                combo.Items.Add(new CommonComboBoxItem(String.Empty, null));
                foreach (Catalogue data in listData)
                {
                    combo.Items.Add(new CommonComboBoxItem(data.ItemDescription, data)); //get all data or just get unit price
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }
        }

        private void LoadDataComboCodeMer()
        {
            try
            {
                List<NhaThuoc> lstData = NhaThuocImp.GetList(string.Empty, "PharmacyName", string.Empty, 0, 0);
                foreach (NhaThuoc data in lstData)
                {
                    cbNT.Items.Add(new CommonComboBoxItem(data.PharmacyName, data)); //get all data or just get unit price
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }
        }

        private void tbXPSluong_TextChanged(object sender, TextChangedEventArgs e)
        {
            TinhPhiHMTC();
        }

        private void TinhPhiHMTC()
        {
            double temp = Controller.Common.ConvertUtil.ConvertToDouble(tbNgang.Text) * Controller.Common.ConvertUtil.ConvertToDouble(tbRong.Text) *
                Controller.Common.ConvertUtil.ConvertToInt(tbSluong.Text);

            if (temp != 0)
            {
                tbDtich.Text = temp.ToString();
                tbTienXinPhep.Text = (Controller.Common.ConvertUtil.ConvertToDouble(tbXPdgia.Text) * temp).ToString();
                tbTienThiCong.Text = (Controller.Common.ConvertUtil.ConvertToDouble(tbHMTCdgia.Text) * temp).ToString();
                tbTienLapDat.Text = (Controller.Common.ConvertUtil.ConvertToDouble(tbLDdgia.Text) * temp).ToString();
            }
            else
            {
                tbDtich.Text = String.Empty;
                tbTienXinPhep.Text = String.Empty;
                tbTienThiCong.Text = String.Empty;
                tbTienLapDat.Text = String.Empty;
            }
        }

        private void tbHMKSluong_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbHMKSluong.Text) && !string.IsNullOrEmpty(tbHMKgia.Text))
            {
                tbTienMucKhac.Text = (Double.Parse(tbHMKSluong.Text) * Double.Parse(tbHMKgia.Text)).ToString();
            }
        }

        private void tbKSSluong_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbKSSluong.Text) && !string.IsNullOrEmpty(tbKSdgia.Text))
            {
                tbTienKhaoSat.Text = (Double.Parse(tbKSSluong.Text) * Double.Parse(tbKSdgia.Text)).ToString();
            }
        }

        private void tbVCSluong_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbVCSluong.Text) && !string.IsNullOrEmpty(tbVCdgia.Text))
            {
                tbTienVanChuyen.Text = (Double.Parse(tbVCSluong.Text) * Double.Parse(tbVCdgia.Text)).ToString();
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateData(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateData(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateData(bool isDeleteData)
        {
            Catalogue cata = null;
            int? IdKhaoSat = null;
            byte? SLKS = null;

            if (cbKhaoSat.SelectedItem != null && ((CommonComboBoxItem)cbKhaoSat.SelectedItem).Value != null)
            {
                cata = ((CommonComboBoxItem)cbKhaoSat.SelectedItem).Value as Catalogue;
                IdKhaoSat = cata.Id;
            }

            int? IdVanChuyen = null;
            byte? SLVC = null;

            if (cbVanChuyen.SelectedItem != null && ((CommonComboBoxItem)cbVanChuyen.SelectedItem).Value != null)
            {
                cata = ((CommonComboBoxItem)cbVanChuyen.SelectedItem).Value as Catalogue;
                IdVanChuyen = cata.Id;
            }

            int? IdLapDat = null;

            if (cbLapDat.SelectedItem != null && ((CommonComboBoxItem)cbLapDat.SelectedItem).Value != null)
            {
                cata = ((CommonComboBoxItem)cbLapDat.SelectedItem).Value as Catalogue;
                IdLapDat = cata.Id;
            }

            int? IdXinPhep = null;

            if (cbXinPhep.SelectedItem != null && ((CommonComboBoxItem)cbXinPhep.SelectedItem).Value != null)
            {
                cata = ((CommonComboBoxItem)cbXinPhep.SelectedItem).Value as Catalogue;
                IdXinPhep = cata.Id;
            }

            int? IdThiCong = null;

            if (cbThiCong.SelectedItem != null && ((CommonComboBoxItem)cbThiCong.SelectedItem).Value != null)
            {
                cata = ((CommonComboBoxItem)cbThiCong.SelectedItem).Value as Catalogue;
                IdThiCong = cata.Id;
            }

            int? IdMucKhac = null;

            if (cbMucKhac.SelectedItem != null && ((CommonComboBoxItem)cbMucKhac.SelectedItem).Value != null)
            {
                cata = ((CommonComboBoxItem)cbMucKhac.SelectedItem).Value as Catalogue;
                IdMucKhac = cata.Id;
            }

            double? ngang = null;
            double? rong = null;
            byte? soLuongHMTC = null;
            byte? soLuongHMK = null;

            if (!String.IsNullOrEmpty(tbNgang.Text))
            {
                ngang = Controller.Common.ConvertUtil.ConvertToDouble(tbNgang.Text);
            }

            if (!String.IsNullOrEmpty(tbRong.Text))
            {
                rong = Controller.Common.ConvertUtil.ConvertToDouble(tbRong.Text);
            }

            if (!String.IsNullOrEmpty(tbSluong.Text))
            {
                soLuongHMTC = Controller.Common.ConvertUtil.ConvertToByte(tbSluong.Text);
            }

            if (!String.IsNullOrEmpty(tbKSSluong.Text))
            {
                SLKS = Controller.Common.ConvertUtil.ConvertToByte(tbKSSluong.Text);
            }

            if (!String.IsNullOrEmpty(tbVCSluong.Text))
            {
                SLVC = Controller.Common.ConvertUtil.ConvertToByte(tbVCSluong.Text);
            }

            if (!String.IsNullOrEmpty(tbHMKSluong.Text))
            {
                soLuongHMK = Controller.Common.ConvertUtil.ConvertToByte(tbHMKSluong.Text);
            }

            int? stt = null;

            if (Controller.Common.ConvertUtil.ConvertToInt(tbSTT.Text) != 0)
            {
                stt = Controller.Common.ConvertUtil.ConvertToInt(tbSTT.Text);
            }

            int? IdMaster = MasterChiPhiImp.Insert(stt, IdKhaoSat, SLKS, IdVanChuyen, SLVC, IdThiCong, IdLapDat, IdXinPhep,
                ngang, rong, soLuongHMTC, tbBrand1.Text, IdMucKhac, soLuongHMK, tbBrand2.Text);
            NhaThuoc _nhathuoc1 = ((CommonComboBoxItem)cbNT.SelectedItem).Value as NhaThuoc;
            int IdNhaThuoc = _nhathuoc1.Id;
            int IdUser = UserImp.currentUser.Id;
            DateTime? _date = dateDateOrder.SelectedDate;
            int? id = HistoryImp.Insert(IdUser, IdNhaThuoc, (int)IdMaster, _date);

            if (id != null)
            {
                if (isDeleteData)
                {
                    HistoryImp.Delete(HistoryImp.GetById(_historyMaster.id));
                }

                RefreshData();
                MessageBox.Show("Cập nhật dữ liệu thành công");
            }
        }

        private void RefreshData()
        {
            LoadData();
            cbKhaoSat.SelectedIndex = 0;
            tbTienKhaoSat.Text = String.Empty;
            tbKSSluong.Text = String.Empty;
            cbVanChuyen.SelectedIndex = 0;
            tbTienVanChuyen.Text = String.Empty;
            tbVCSluong.Text = String.Empty;
            cbThiCong.SelectedIndex = 0;
            cbLapDat.SelectedIndex = 0;
            cbXinPhep.SelectedIndex = 0;
            cbMucKhac.SelectedIndex = 0;
            tbBrand1.Text = String.Empty;
            tbBrand2.Text = String.Empty;
            tbNgang.Text = String.Empty;
            tbRong.Text = String.Empty;
            tbSluong.Text = String.Empty;
            tbDtich.Text = String.Empty;
            tbHMKSluong.Text = String.Empty;
            tbTonggia.Text = String.Empty;
        }

        private void TongTien()
        {
            double tienKhaoSat = Controller.Common.ConvertUtil.ConvertToDouble(tbTienKhaoSat.Text);
            double tienVanChuyen = Controller.Common.ConvertUtil.ConvertToDouble(tbTienVanChuyen.Text);
            double tienHMTC = Controller.Common.ConvertUtil.ConvertToDouble(tbTienThiCong.Text);
            double tienLapDat = Controller.Common.ConvertUtil.ConvertToDouble(tbTienLapDat.Text);
            double tienXinPhep = Controller.Common.ConvertUtil.ConvertToDouble(tbTienXinPhep.Text);
            double tienHMC = Controller.Common.ConvertUtil.ConvertToDouble(tbTienMucKhac.Text);

            tbTonggia.Text = (tienKhaoSat + tienVanChuyen + tienHMTC + tienLapDat + tienXinPhep + tienHMC).ToString();
        }

        private void tbTienKhaoSat_TextChanged(object sender, TextChangedEventArgs e)
        {
            TongTien();
        }

        private void tbTienVanChuyen_TextChanged(object sender, TextChangedEventArgs e)
        {
            TongTien();
        }

        private void tbTienThiCong_TextChanged(object sender, TextChangedEventArgs e)
        {
            TongTien();
        }

        private void tbTienLapDat_TextChanged(object sender, TextChangedEventArgs e)
        {
            TongTien();
        }

        private void tbTienXinPhep_TextChanged(object sender, TextChangedEventArgs e)
        {
            TongTien();
        }

        private void tbTienMucKhac_TextChanged(object sender, TextChangedEventArgs e)
        {
            TongTien();
        }

        private void tbNgang_TextChanged(object sender, TextChangedEventArgs e)
        {
            TinhPhiHMTC();
        }

        private void tbRong_TextChanged(object sender, TextChangedEventArgs e)
        {
            TinhPhiHMTC();
        }

        private void SelectComboCodeMer(ComboBox combo, string itemText)
        {
            for (int i = 0; i < combo.Items.Count; i++)
            {
                NhaThuoc _nt = combo.Items[i] as NhaThuoc;
                if (_nt.CodeMer.ToString().Equals(itemText))
                {
                    combo.SelectedIndex = i;
                    break;
                }
            }
        }

        private void cb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            TextBox textBox = comboBox.Template.FindName("PART_EditableTextBox", comboBox) as TextBox;
            Popup popup = comboBox.Template.FindName("PART_Popup", comboBox) as Popup;

            if (textBox != null)
            {
                //textBox.TextChanged += delegate
                //{
                    popup.IsOpen = true;
                    comboBox.Items.Filter += a =>
                    {
                        if (a.ToString().ToLower().StartsWith(textBox.Text.ToLower()))
                        {
                            return true;
                        }
                        return false;
                    };
                //};
            }
        }

        private void cbCodeMer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbNT.SelectedItem != null)
            {
                gridChiPhi.IsEnabled = true;
                NhaThuoc data = ((CommonComboBoxItem)cbNT.SelectedItem).Value as NhaThuoc;
                if (data != null)
                {
                    tbAdress.Text = data.Address;
                    tbWard.Text = data.Ward;
                    tbCodeMer.Text = data.CodeMer;
                    tbStreet.Text = data.Street;
                    tbDistrict.Text = data.District;
                    tbOther.Text = data.Other;
                    tbCity.Text = data.Province;
                }
            }
            else
            {
                gridChiPhi.IsEnabled = false;
            }
        }
    }
}
