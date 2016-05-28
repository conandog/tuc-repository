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
    /// Interaction logic for PetMainPage.xaml
    /// </summary>
    public partial class UcPetMain : UserControl
    {
        private Pet selectedItem;
        private string listSelectedItem;

        public UcPetMain()
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
                List<Pet> listData = PetImp.GetList();

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
            var mainWD = (WdMain)Window.GetWindow(this);
            mainWD.LoadUcPetDetail();
        }

        private void dgShowInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listSelectedItem = string.Empty;
            System.Collections.IList listSelected = dgShowInfo.SelectedItems;

            foreach (Pet data in listSelected)
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
