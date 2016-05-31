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
using Model;
using Controller.Implementation;
using QuanLyDonHang.Common;
using System.Threading;

namespace QuanLyDonHang
{
    /// <summary>
    /// Interaction logic for InputUser.xaml
    /// </summary>
    public partial class InputUser : UserControl
    {
        private User _selectedItem;
        private string lstRowDelete = string.Empty;
        private ManagerWD _managerWD;
        public InputUser()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            _managerWD = (ManagerWD)Window.GetWindow(this);
            TabControl _tabData = (TabControl)Utilities.FindChildControl<TabControl>(_managerWD);
            AddUserUC _addUser = new AddUserUC();
            TabItem _tabItemUser = _tabData.Items[0] as TabItem;
            _addUser.SetDefaultValue();
            _tabItemUser.Content = _addUser;
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("Bạn có muốn xóa những dòng đã chọn?", "User", MessageBoxButton.YesNo);
                UserGroupImp.DeleteList(lstRowDelete);
                Thread.Sleep(100);
                LoadUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckEditPermission(_selectedItem))
                {
                    _managerWD = (ManagerWD)Window.GetWindow(this);
                    TabControl _tabData = (TabControl)Utilities.FindChildControl<TabControl>(_managerWD);
                    AddUserUC _editUser = new AddUserUC();
                    TabItem _tabItemUser = _tabData.Items[0] as TabItem;
                    _editUser.SetDefaultValue();
                    _editUser.SetTbEditVisible();
                    _editUser.SetDisplayData(_selectedItem);
                    _tabItemUser.Content = _editUser;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void inputUserUC_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUser();
        }

        private void LoadUser()
        {
            try
            {
                List<User> listData = UserImp.GetList();

                if (listData != null)
                {
                    dgShowInfo.ItemsSource = null;
                    dgShowInfo.ItemsSource = listData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CheckEditPermission(User data)
        {
            bool res = true;

            if (data.UserGroup.Ten.ToLower() == CommonConstants.DEFAULT_USER_GROUP_ADMIN_NAME &&
                UserImp.currentUser.UserGroup.Ten.ToLower() == CommonConstants.DEFAULT_USER_GROUP_ADMIN_NAME &&
                data.Id != UserImp.currentUser.Id)
            {
                MessageBox.Show(CommonConstants.MESSAGE_ERROR_EDIT_PROFILE_ADMIN);
                res = false;
            }

            if (data.UserGroup.Ten.ToLower() == CommonConstants.DEFAULT_USER_GROUP_ADMIN_NAME &&
                UserImp.currentUser.UserGroup.Ten.ToLower() != CommonConstants.DEFAULT_USER_GROUP_ADMIN_NAME)
            {
                MessageBox.Show(CommonConstants.MESSAGE_ERROR_DO_NOT_HAVE_PERMISSION);
                res = false;
            }

            return res;
        }

        private void dgShowInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstRowDelete = string.Empty;
            System.Collections.IList _lsSelected = dgShowInfo.SelectedItems;
            foreach (User user in _lsSelected)
            {
                _selectedItem = user;
                lstRowDelete += user.Id + CommonConstants.DELIMITER_STRING;
            }
            if (string.IsNullOrEmpty(lstRowDelete))
            {
                btDelete.IsEnabled = false;
                btEdit.IsEnabled = false;
                chbSelect.IsChecked = false;
            }
            else
            {
                btEdit.IsEnabled = true;
                btDelete.IsEnabled = true;
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
