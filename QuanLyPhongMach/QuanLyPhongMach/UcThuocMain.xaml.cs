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
    /// Interaction logic for ThuocMainPage.xaml
    /// </summary>
    public partial class UcThuocMain : UserControl
    {
        private Thuoc selectedItem;
        private string listSelectedItem;

        public UcThuocMain()
        {
            InitializeComponent();
        }

        private void UcMain_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                List<Thuoc> listData = ThuocImp.GetList();

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

        private void dgShowInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listSelectedItem = string.Empty;
            System.Collections.IList listSelected = dgShowInfo.SelectedItems;

            foreach (Thuoc data in listSelected)
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

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            var mainWD = Window.GetWindow(this) as WdMain;
            mainWD.LoadUcThuocDetail();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show(Constant.MESSAGE_DELETE_CONFIRM, Constant.CAPTION_CONFIRM, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (ThuocImp.DeleteList(listSelectedItem))
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

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
