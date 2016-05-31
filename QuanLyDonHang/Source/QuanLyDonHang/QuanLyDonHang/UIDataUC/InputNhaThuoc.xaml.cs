using Controller.Implementation;
using Model;
using QuanLyDonHang.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for InputNhaThuoc.xaml
    /// </summary>
    public partial class InputNhaThuoc : UserControl
    {
        private string lstRowDelete = string.Empty;
        private NhaThuoc _nhathuoc;
        private ManagerWD _managerWD;
        public InputNhaThuoc()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            _managerWD = (ManagerWD)Window.GetWindow(this);
            TabControl _tabData = (TabControl)Utilities.FindChildControl<TabControl>(_managerWD);
            AddNhaThuocUC _addNhaThuoc = new AddNhaThuocUC();
            TabItem _tabItemNhaThuoc = _tabData.Items[1] as TabItem;
            _tabItemNhaThuoc.Content = _addNhaThuoc;
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bạn có muốn xóa những dòng đã chọn?", "Nha Thuoc", MessageBoxButton.YesNo);
            NhaThuocImp.DeleteList(lstRowDelete);
            Thread.Sleep(100);
            LoadNhaThuoc();
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            _managerWD = (ManagerWD)Window.GetWindow(this);
            TabControl _tabData = (TabControl)Utilities.FindChildControl<TabControl>(_managerWD);
            AddNhaThuocUC _addNhaThuoc = new AddNhaThuocUC();
            TabItem _tabItemNhaThuoc = _tabData.Items[1] as TabItem;
            _addNhaThuoc.SetTbEditVisible();
            _addNhaThuoc.SetDisplayData(_nhathuoc);
            _tabItemNhaThuoc.Content = _addNhaThuoc;
        }

        private void btImportExcel_Click(object sender, RoutedEventArgs e)
        {
            WindowImportData _importData = new WindowImportData();
            _importData.SetDisplayData(Common.CommonConstants.DATATYPE.NhaThuoc);
            _importData.ShowDialog();
            ManagerWD _managerWD = (ManagerWD)Window.GetWindow(this);
            TabControl _tabData = (TabControl)Utilities.FindChildControl<TabControl>(_managerWD);
            InputNhaThuoc _inputNhaThuoc = new InputNhaThuoc();
            TabItem _tabItemUser = _tabData.Items[1] as TabItem;
            _tabItemUser.Content = _inputNhaThuoc;
        }

        private void inputNhaThuocUC_Loaded(object sender, RoutedEventArgs e)
        {
            LoadNhaThuoc();
        }

        private void LoadNhaThuoc()
        {
            try
            {
                List<NhaThuoc> listData = NhaThuocImp.GetList();

                if (listData != null)
                {
                    dgShowInfo.ItemsSource = null;
                    dgShowInfo.ItemsSource = listData;
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
            System.Collections.IList _lsrowSlected = dgShowInfo.SelectedItems;
            foreach (NhaThuoc _nt in _lsrowSlected)
            {
                _nhathuoc = _nt;
                lstRowDelete += _nt.Id + CommonConstants.DELIMITER_STRING;
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
