using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controller.Implementation;
using QuanLyDonHang.Common;
using Model;
using System.Windows.Controls.Primitives;
using System.Threading;

namespace QuanLyDonHang
{
    /// <summary>
    /// Interaction logic for MasterDataUC.xaml
    /// </summary>
    public partial class MasterDataUC : UserControl
    {
        private User _user;
        private NhaThuoc _nhathuoc;
        private MasterChiPhi _master;
        private ItemMaster _selectedItem;
        private List<History> _lshistory;
        private string lstRowDelete = string.Empty;
        public MasterDataUC()
        {
            InitializeComponent();
        }

        private void MasterDataUC_Loaded(object sender, RoutedEventArgs e)
        {
            InitDate();
            InitFilter(cbKhaoSat, CommonConstants.ITEMGROUP_KHAOSAT);
            InitFilter(cbVanChuyen, CommonConstants.ITEMGROUP_VANCHUYEN);
            InitFilter(cbThiCong, CommonConstants.ITEMGROUP_HANGMUCTHICONG);
            InitFilter(cbLapDat, CommonConstants.ITEMGROUP_LAPDAT);
            InitFilter(cbXinPhep, CommonConstants.ITEMGROUP_XINPHEP);
            InitFilter(cbMucKhac, CommonConstants.ITEMGROUP_HANGMUCKHAC);
            LoadData();
            CheckPermission();
        }

        private void LoadData()
        {
            try
            {
                List<ItemMaster> _lsMasterItem = new List<ItemMaster>();
                Catalogue cata = null;
                int? IdKhaoSat = null;

                if (cbKhaoSat.SelectedItem != null && ((CommonComboBoxItem)cbKhaoSat.SelectedItem).Value != null)
                {
                    cata = ((CommonComboBoxItem)cbKhaoSat.SelectedItem).Value as Catalogue;
                    IdKhaoSat = cata.Id;
                }

                int? IdVanChuyen = null;

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

                _lshistory = HistoryImp.GetList(tbNhaThuoc.Text, tbSTT.Text, IdKhaoSat, IdVanChuyen, IdThiCong,
                    IdLapDat, IdXinPhep, IdMucKhac, dpDate.SelectedDate, cbDateType.SelectedValue.ToString(), chbShowHistory.IsChecked.Value);

                int i = 1;
                double khaoSat = 0;
                double vanChuyen = 0;
                double HMTC = 0;
                double lapDat = 0;
                double xinPhep = 0;
                double HMK = 0;
                double tong = 0;

                double SLkhaoSat = 0;
                double SLvanChuyen = 0;
                double tienkhaoSat = 0;
                double tienvanChuyen = 0;

                double ngang = 0;
                double rong = 0;
                int soluong = 0;
                double dientich = 0;
                int soluongHMK = 0;

                ItemMaster total = new ItemMaster();

                if (_lshistory.Count > 0)
                {
                    _lsMasterItem.Add(total);
                }

                foreach (History _history in _lshistory)
                {
                    _user = UserImp.GetById(_history.IdUser);
                    _nhathuoc = NhaThuocImp.GetById(_history.IdNhaThuoc);
                    _master = MasterChiPhiImp.GetById(_history.IdMasterChiPhi);
                    ItemMaster _itemmaster = CreateGridItem(_master.STT, _history);
                    _lsMasterItem.Add(_itemmaster);

                    double temp1 = _itemmaster.chiphiKS.HasValue ? _itemmaster.chiphiKS.Value : 0;
                    double temp2 = _itemmaster.soluongKS.HasValue ? _itemmaster.soluongKS.Value : 0;
                    int temp3 = 0;
                    khaoSat += temp1;
                    SLkhaoSat += temp2;
                    tienkhaoSat += temp1 * temp2;

                    temp1 = _itemmaster.chiphiVC.HasValue ? _itemmaster.chiphiVC.Value : 0;
                    temp2 = _itemmaster.soluongVC.HasValue ? _itemmaster.soluongVC.Value : 0;
                    vanChuyen += temp1;
                    SLvanChuyen += temp2;
                    tienvanChuyen += temp1 * temp2;

                    HMTC += _itemmaster.tienTC.HasValue ? _itemmaster.tienTC.Value : 0;
                    lapDat += _itemmaster.tienLD.HasValue ? _itemmaster.tienLD.Value : 0;
                    xinPhep += _itemmaster.tienXP.HasValue ? _itemmaster.tienXP.Value : 0;

                    temp1 = _itemmaster.ngang.HasValue ? _itemmaster.ngang.Value : 0;
                    temp2 = _itemmaster.rong.HasValue ? _itemmaster.rong.Value : 0;
                    temp3 = _itemmaster.soluong.HasValue ? _itemmaster.soluong.Value : 0;
                    ngang += temp1;
                    rong += temp2;
                    soluong += temp3;
                    dientich += temp1 * temp2 * temp3;

                    soluongHMK += _itemmaster.soluongHMK.HasValue ? _itemmaster.soluongHMK.Value : 0;
                    HMK += _itemmaster.tienHMK.HasValue ? _itemmaster.tienHMK.Value : 0;
                    tong += _itemmaster.tongcong;
                    i++;
                }

                if (_lsMasterItem.Count > 0)
                {
                    total.chiphiKS = khaoSat == 0 ? null : (double?)khaoSat;
                    total.soluongKS = SLkhaoSat == 0 ? null : (int?)SLkhaoSat;
                    total.tienKS = tienkhaoSat == 0 ? null : (double?)tienkhaoSat;
                    total.chiphiVC = vanChuyen == 0 ? null : (double?)vanChuyen;
                    total.soluongVC = SLvanChuyen == 0 ? null : (int?)SLvanChuyen;
                    total.tienVC = tienvanChuyen == 0 ? null : (double?)tienvanChuyen;
                    total.tienTC = HMTC == 0 ? null : (double?)HMTC;
                    total.tienLD = lapDat == 0 ? null : (double?)lapDat;
                    total.tienXP = xinPhep == 0 ? null : (double?)xinPhep;
                    total.ngang = ngang == 0 ? null : (double?)ngang;
                    total.rong = rong == 0 ? null : (double?)rong;
                    total.soluong = soluong == 0 ? null : (int?)soluong;
                    total.dientich = dientich == 0 ? null : (double?)dientich;

                    total.soluongHMK = soluongHMK == 0 ? null : (int?)soluongHMK;
                    total.tienHMK = HMK == 0 ? null : (double?)HMK;
                    total.tongcong = tong;
                }

                dgShowInfo.ItemsSource = _lsMasterItem;

                if (_lsMasterItem.Count > 0)
                {
                    btXuatExcel.IsEnabled = true;
                }
                else
                {
                    btXuatExcel.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitDate()
        {
            cbDateType.Items.Add(Controller.Common.CommonConstants.DEFAULT_TYPE_DAY);
            cbDateType.Items.Add(Controller.Common.CommonConstants.DEFAULT_TYPE_WEEK);
            cbDateType.Items.Add(Controller.Common.CommonConstants.DEFAULT_TYPE_MONTH);
            cbDateType.Items.Add(Controller.Common.CommonConstants.DEFAULT_TYPE_YEAR);
            cbDateType.SelectedIndex = 2;
            dpDate.SelectedDate = DateTime.Now;
        }

        private void InitFilter(ComboBox combo, string itemgroup)
        {
            try
            {
                List<Catalogue> listData = CatalogueImp.GetList(String.Empty, itemgroup, String.Empty, String.Empty, 0, 0);
                combo.Items.Add(new CommonComboBoxItem(String.Empty, null));
                foreach (Catalogue data in listData)
                {
                    combo.Items.Add(new CommonComboBoxItem(data.ItemDescription, data));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }
        }

        private void CheckPermission()
        {
            if (!CommonFunction.CheckEditPermission())
            {
                btEdit.Visibility = Visibility.Hidden;
            }
        }

        public ItemMaster CreateGridItem(int? stt, History history)
        {
            ItemMaster _itemmaster = new ItemMaster();

            try
            {
                _itemmaster.id = history.Id;
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

        private void btXuatExcel_Click(object sender, RoutedEventArgs e)
        {
            if (_lshistory.Count > 0)
            {
                try
                {
                    Controller.Common.CommonFunction.ExportMasterChiPhi(_lshistory);
                    MessageBox.Show("Xuất dữ liệu thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất");
            }
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            ManagerWD _managerWD = (ManagerWD)Window.GetWindow(this);
            _managerWD.EditPriceUC(_selectedItem);
        }

        private void dgShowInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstRowDelete = string.Empty;
            System.Collections.IList _lsSelected = dgShowInfo.SelectedItems;
            foreach (ItemMaster _master in _lsSelected)
            {
                _selectedItem = _master;
                lstRowDelete += _selectedItem.id + CommonConstants.DELIMITER_STRING;
            }
            if (string.IsNullOrEmpty(lstRowDelete))
            {
                btDelete.IsEnabled = false;
                btEdit.IsEnabled = false;
                chbSelect.IsChecked = false;
            }
            else
            {
                btDelete.IsEnabled = true;
                btEdit.IsEnabled = true;
                chbSelect.IsChecked = true;
            }

            if (dgShowInfo.SelectedItems.Count == 1 && dgShowInfo.SelectedIndex == 0)
            {
                btDelete.IsEnabled = false;
                btEdit.IsEnabled = false;
            }
        }

        private void SelectRowByIndex(int startrow, int endrow)
        {
            dgShowInfo.SelectedItems.Clear();
            for (int i = startrow; i < endrow; i++)
            {
                object item = dgShowInfo.Items[i]; //=Product X
                dgShowInfo.SelectedItems.Add(item);
            }
        }

        private void chbSelect_Click(object sender, RoutedEventArgs e)
        {
            CheckBox chb = sender as CheckBox;
            if ((bool)chb.IsChecked)
            {
                SelectRowByIndex(0, dgShowInfo.Items.Count);
            }
            else
            {
                dgShowInfo.SelectedItems.Clear();
            }
        }

        private void cbDateType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        private void tbNhaThuoc_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
        }

        private void chbShowHistory_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
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

        private void cbKhaoSat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        private void cbVanChuyen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        private void cbThiCong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        private void cbLapDat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        private void cbXinPhep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        private void cbMucKhac_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("Bạn có muốn xóa những dòng đã chọn?", "Master chi phí", MessageBoxButton.YesNo);
                HistoryImp.DeleteList(lstRowDelete);
                Thread.Sleep(100);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btImportExcel_Click(object sender, RoutedEventArgs e)
        {
            WindowImportData _importData = new WindowImportData();
            _importData.SetDisplayData(Common.CommonConstants.DATATYPE.Master);
            _importData.ShowDialog();
            ManagerWD _managerWD = (ManagerWD)Window.GetWindow(this);
            _managerWD.callExcelUC();
        }
    }

    public class ItemMaster
    {
        public int id { get; set; }
        public int? stt {get; set;}
        public string ngayorder { get; set; }
        public string codemer { get; set; }
        public string pharmacyname { get; set; }
        public string address { get; set; }
        public string street { get; set; }
        public string other { get; set; }
        public string ward { get; set; }
        public string dictrict { get; set; }
        public string city { get; set; }
        public string khaosat { get; set; }
        public double? chiphiKS { get; set; }
        public int? soluongKS { get; set; }
        public double? tienKS { get; set; }
        public string vanchuyen { get; set; }
        public double? chiphiVC { get; set; }
        public int? soluongVC { get; set; }
        public double? tienVC { get; set; }
        public string HMTC { get; set; }
        public string donviHMTC { get; set; }
        public double? dongiaTC { get; set; }
        public string lapdat { get; set; }
        public string donviLD { get; set; }
        public double? dongiaLD { get; set; }
        public string xinphep { get; set; }
        public string donviXP { get; set; }
        public double? dongiaXP { get; set; }
        public double? ngang { get; set; }
        public double? rong { get; set; }
        public int? soluong { get; set; }
        public double? dientich { get; set; }
        public string brand1 { get; set; }
        public double? tienTC { get; set; }
        public double? tienLD { get; set; }
        public double? tienXP { get; set; }
        public string HMK { get; set; }
        public string donviHMK { get; set; }
        public double? dongiaHMK { get; set; }
        public int? soluongHMK { get; set; }
        public double? tienHMK { get; set; }
        public string brand2 { get; set; }
        public double tongcong { get; set; }
    }
}
