using Controller.Implementation;
using Model;
using QuanLyDonHang.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

namespace QuanLyDonHang
{
    /// <summary>
    /// Interaction logic for InputCatalogue.xaml
    /// </summary>
    public partial class InputCatalogue : UserControl
    {
        private string lstRowDelete = string.Empty;
        private Catalogue _dataCata;
        private ManagerWD _managerWD;
        public InputCatalogue()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            _managerWD = (ManagerWD)Window.GetWindow(this);
            TabControl _tabData = (TabControl)Utilities.FindChildControl<TabControl>(_managerWD);
            AddCatalogueUC _addCatalogue = new AddCatalogueUC();
            TabItem _tabItemCatalogue = _tabData.Items[2] as TabItem;
            _addCatalogue.SetDefaultValue();
            _tabItemCatalogue.Content = _addCatalogue;
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bạn có muốn xóa những dòng đã chọn?", "Catalogue", MessageBoxButton.YesNo);
            CatalogueImp.DeleteList(lstRowDelete);
            Thread.Sleep(100);
            LoadCatalogueGroup();
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            _managerWD = (ManagerWD)Window.GetWindow(this);
            TabControl _tabData = (TabControl)Utilities.FindChildControl<TabControl>(_managerWD);
            AddCatalogueUC _addCatalogue = new AddCatalogueUC();
            TabItem _tabItemCatalogue = _tabData.Items[2] as TabItem;
            _addCatalogue.SetDefaultValue();
            _addCatalogue.SetTbEditVisible();
            _addCatalogue.SetDisplayData(_dataCata);
            _tabItemCatalogue.Content = _addCatalogue;

        }

        private void btImportExcel_Click(object sender, RoutedEventArgs e)
        {
            WindowImportData _importData = new WindowImportData();
            _importData.SetDisplayData(Common.CommonConstants.DATATYPE.Catalogue);
            _importData.ShowDialog();
            ManagerWD _managerWD = (ManagerWD)Window.GetWindow(this);
            TabControl _tabData = (TabControl)Utilities.FindChildControl<TabControl>(_managerWD);
            InputCatalogue _inputCata = new InputCatalogue();
            TabItem _tabItemUser = _tabData.Items[2] as TabItem;
            _tabItemUser.Content = _inputCata;
        }

        private void inputCataUC_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCatalogueGroup();
        }

        private void LoadCatalogueGroup()
        {
            try
            {
                List<Catalogue> listData = CatalogueImp.GetList();

                if (listData != null)
                {
                    dgShowInfo.ItemsSource = null;
                    dgShowInfo.ItemsSource = listData;
                    SetDefaultValue();
                    CheckPermission();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckPermission()
        {
            if (!CommonFunction.CheckEditPermission())
            {
                btAdd.Visibility = Visibility.Hidden;
                btEdit.Visibility = Visibility.Hidden;
                btDelete.Visibility = Visibility.Hidden;
                btImportExcel.Visibility = Visibility.Hidden;
            }
        }

        private void dgShowInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstRowDelete = string.Empty;
            System.Collections.IList _lsSelected = dgShowInfo.SelectedItems;
            foreach (Catalogue _cata in _lsSelected)
            {
                _dataCata = _cata;
                lstRowDelete += _cata.Id + CommonConstants.DELIMITER_STRING;
            }

            if (string.IsNullOrEmpty(lstRowDelete))
            {
                btDelete.IsEnabled = false;
                btEdit.IsEnabled = false;
                cbItemGroup.IsEnabled = false;
                chbSelect.IsChecked = false;
                cbItemGroup.SelectedIndex = -1;
            }
            else
            {
                btDelete.IsEnabled = true;
                btEdit.IsEnabled = true;
                cbItemGroup.IsEnabled = true;
                chbSelect.IsChecked = true;
                cbItemGroup.SelectedIndex = 0;
            }
        }

        public void SetDefaultValue()
        {
            cbItemGroup.Items.Clear();
            cbItemGroup.Items.Add(CommonConstants.ITEMGROUP_KHAOSAT);
            cbItemGroup.Items.Add(CommonConstants.ITEMGROUP_VANCHUYEN);
            cbItemGroup.Items.Add(CommonConstants.ITEMGROUP_HANGMUCTHICONG);
            cbItemGroup.Items.Add(CommonConstants.ITEMGROUP_LAPDAT);
            cbItemGroup.Items.Add(CommonConstants.ITEMGROUP_XINPHEP);
            cbItemGroup.Items.Add(CommonConstants.ITEMGROUP_HANGMUCKHAC);
        }

        private void UpdateItemGroup(string text)
        {
            try
            {
                string[] lsId = Regex.Split(lstRowDelete, CommonConstants.DELIMITER_STRING);
                foreach (string t in lsId)
                {

                    if (string.IsNullOrEmpty(t))
                        break;
                    Catalogue _cataItem = CatalogueImp.GetById(Int32.Parse(t));
                    _cataItem.ItemGroup = text;
                    CatalogueImp.Update(_cataItem.Id, _cataItem.Country, _cataItem.Category, _cataItem.ItemDescription, _cataItem.UnitPrice, _cataItem.ReferencePrice,
                        _cataItem.Currency, (DateTime)_cataItem.EffectiveDate, (DateTime)_cataItem.ExpiryDate, _cataItem.Code, _cataItem.SubCategory, _cataItem.SupplierCode, _cataItem.SupplierName,
                        _cataItem.ItemGroup, _cataItem.MoreDescription, _cataItem.PartNumber, _cataItem.UOM, _cataItem.Remark, _cataItem.GLCode, _cataItem.HACAT);

                }

                MessageBox.Show(string.Format("Cập nhật ItemGroup với tên '{0}' thành công", text), "Catalogue", MessageBoxButton.OK);
            }
            catch
            {
                MessageBox.Show(string.Format("Không thể cập nhật ItemGroup với tên '{0}'", text), "Catalogue", MessageBoxButton.OK);
                return;
            }
        }

        private void btUpdateItemGroup_Click(object sender, RoutedEventArgs e)
        {
            UpdateItemGroup(cbItemGroup.Text);
            LoadCatalogueGroup();

        }

        private void cbItemGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbItemGroup.SelectedIndex != -1)
            {
                btUpdateItemGroup.IsEnabled = true;
            }
            else
            {
                btUpdateItemGroup.IsEnabled = false;
            }
        }

        private void cbItemGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !String.IsNullOrEmpty(cbItemGroup.Text))
            {
                UpdateItemGroup(cbItemGroup.Text);
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
    }
}
