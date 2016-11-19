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
using Core;

namespace QuanLyPhongMach
{
    /// <summary>
    /// Interaction logic for KhachHangMainPage.xaml
    /// </summary>
    public partial class UcKhachHangMain : UserControl
    {
        private KhachHang selectedItem;
        private string listSelectedItem;

        public UcKhachHangMain()
        {
            InitializeComponent();
        }

        private void UcMain_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid(string text = "")
        {
            try
            {
                List<KhachHang> listData = null;

                if (String.IsNullOrEmpty(text))
                {
                    listData = KhachHangImp.GetList();
                }
                else
                {
                    listData = KhachHangImp.GetList(text);
                }

                if (listData != null)
                {
                    dgShowInfo.ItemsSource = listData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CheckEditPermission()
        {
            bool res = true;

            //if (data.UserGroup.Ten.ToLower() == Constant.DEFAULT_USER_GROUP_ADMIN_NAME &&
            //    UserImp.currentUser.UserGroup.Ten.ToLower() == CommonConstants.DEFAULT_USER_GROUP_ADMIN_NAME &&
            //    data.Id != UserImp.currentUser.Id)
            //{
            //    MessageBox.Show(CommonConstants.MESSAGE_ERROR_EDIT_PROFILE_ADMIN);
            //    res = false;
            //}

            //if (data.UserGroup.Ten.ToLower() == CommonConstants.DEFAULT_USER_GROUP_ADMIN_NAME &&
            //    UserImp.currentUser.UserGroup.Ten.ToLower() != CommonConstants.DEFAULT_USER_GROUP_ADMIN_NAME)
            //{
            //    MessageBox.Show(CommonConstants.MESSAGE_ERROR_DO_NOT_HAVE_PERMISSION);
            //    res = false;
            //}

            return res;
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            var mainWD = Window.GetWindow(this) as WdMain;
            mainWD.LoadUcKhachHangDetail();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show(Constant.MESSAGE_DELETE_CONFIRM, Constant.CAPTION_CONFIRM, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (KhachHangImp.DeleteList(listSelectedItem))
                    {
                        LoadDataGrid();
                    }
                    else
                    {
                        MessageBox.Show(Constant.MESSAGE_GENERAL_ERROR, Constant.CAPTION_ERROR, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgShowInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listSelectedItem = string.Empty;
            System.Collections.IList listSelected = dgShowInfo.SelectedItems;

            foreach (KhachHang data in listSelected)
            {
                selectedItem = data;
                listSelectedItem += data.Id + Constant.DELIMITER_STRING;
            }

            if (listSelected.Count == 1)
            {
                btDelete.IsEnabled = true;
                btEdit.IsEnabled = true;
                chbSelect.IsChecked = true;
            }
            else if (listSelected.Count > 1)
            {
                btDelete.IsEnabled = true;
                btEdit.IsEnabled = false;
                chbSelect.IsChecked = true;
            }
            else
            {
                btEdit.IsEnabled = false;
                btDelete.IsEnabled = false;
                chbSelect.IsChecked = false;
            }
        }

        private void SelectRowByIndex(int startrow, int endrow)
        {
            dgShowInfo.SelectedItems.Clear();

            for (int i = startrow; i < endrow; i++)
            {
                object item = dgShowInfo.Items[i];
                dgShowInfo.SelectedItems.Add(item);
            }
        }

        private void chbSelect_Click(object sender, RoutedEventArgs e)
        {
            CheckBox chb = sender as CheckBox;

            if (chb.IsChecked.HasValue && chb.IsChecked.Value)
            {
                SelectRowByIndex(0, dgShowInfo.Items.Count);
            }
            else
            {
                dgShowInfo.SelectedItems.Clear();
            }
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            var mainWD = Window.GetWindow(this) as WdMain;
            mainWD.LoadUcKhachHangDetail(selectedItem);
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoadDataGrid(tbSearch.Text);
            }
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            LoadDataGrid(tbSearch.Text);
        }

        private void PreLoadHandler(object sender, ContextMenuEventArgs e)
        {
            FrameworkElement fe = e.Source as FrameworkElement;
            fe.ContextMenu = BuildMenu(selectedItem);
        }

        private ContextMenu BuildMenu(KhachHang khachHang)
        {
            ContextMenu theMenu = new ContextMenu();
            MenuItem miDefault = new MenuItem();
            miDefault.Header = khachHang.Ma + " -> THEM MOI THU NUOI";
            miDefault.Click += MiDefault_Click;
            theMenu.Items.Add(miDefault);

            if (khachHang != null)
            {
                List<Pet> listData = PetImp.GetListByIdKhachHang(khachHang.Id);

                foreach (Pet data in listData)
                {
                    MenuItem mi = new MenuItem();
                    mi.Header = data.Ten;
                    mi.Click += Mi_Click;
                    theMenu.Items.Add(mi);
                }
            }

            return theMenu;
        }

        private void MiDefault_Click(object sender, RoutedEventArgs e)
        {
            var mainWD = Window.GetWindow(this) as WdMain;
            mainWD.LoadUcPetDetail(selectedItem);
        }

        private void Mi_Click(object sender, RoutedEventArgs e)
        {
            Pet data = sender as Pet;
            var mainWD = Window.GetWindow(this) as WdMain;
            mainWD.LoadUcPetDetail(data);
        }
    }
}
