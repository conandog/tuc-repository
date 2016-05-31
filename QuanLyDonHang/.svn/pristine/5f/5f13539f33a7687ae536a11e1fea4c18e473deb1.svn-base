using Controller.Implementation;
using Model;
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

namespace QuanLyDonHang
{
    /// <summary>
    /// Interaction logic for AddUserUC.xaml
    /// </summary>
    public partial class AddUserUC : UserControl
    {
        private ManagerWD _managerWD;
        private User _curUser;
        public AddUserUC()
        {
            InitializeComponent();
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            _managerWD = (ManagerWD)Window.GetWindow(this);
            TabControl _tabData = (TabControl)Utilities.FindChildControl<TabControl>(_managerWD);
            InputUser _inputUser = new InputUser();
            TabItem _tabItemUser = _tabData.Items[0] as TabItem;
            _tabItemUser.Content = _inputUser;
        }

        public void SetTbEditVisible()
        {
            btUpdateUser.Visibility = Visibility.Visible;
            tbAddUser.Visibility = Visibility.Collapsed;
            tbEditUser.Visibility = Visibility.Visible;
        }

        public void SetDisplayData(User _userData)
        {
            _curUser = _userData;
            tbUserHoTen.Text = _curUser.Ten;
            tbUserUserName.Text = _curUser.UserName;
            
            if (_curUser.GioiTinh.Equals("Nam"))
                cbGioiTinh.SelectedIndex = 0;
            else
                cbGioiTinh.SelectedIndex = 1;

            dateUserDOB.SelectedDate = _curUser.DOB;
            dateUserNgayCap.SelectedDate = _curUser.NgayCap;
            tbUserMa.Text = _curUser.Ma;
            tbUserCMND.Text = _curUser.CMND;
            tbUserNoiCap.Text = _curUser.NoiCap;
            tbUserDiaChi.Text = _curUser.DiaChi;
            tbUserDTB.Text = _curUser.DienThoai;
            tbUserDTDD.Text = _curUser.DTDD;
            tbUserEmail.Text = _curUser.Email;
            tbUserGhiChu.Text = _curUser.GhiChu;
        }

        #region Manager User
        private void btSaveUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User _username = UserImp.GetByUserName(tbUserUserName.Text);
                if (_username != null)
                {
                    MessageBox.Show("The username is valid");
                }
                else
                {
                    DateTime DOB = (dateUserDOB.SelectedDate == null) ? DateTime.Now : dateUserDOB.SelectedDate.Value;
                    DateTime ngaycap = (dateUserNgayCap.SelectedDate == null) ? DateTime.Now : dateUserNgayCap.SelectedDate.Value;
                    if (pwUserPass.Password == pwUserXacNhanPass.Password)
                    {
                        byte idUserGroup = ((UserGroup)cbUserGroup.SelectedItem).Id;
                        string gioitinh = cbGioiTinh.Text;
                        int? id = UserImp.Insert(idUserGroup, tbUserHoTen.Text, tbUserUserName.Text, pwUserPass.Password, gioitinh, DOB, ngaycap, tbUserMa.Text, tbUserCMND.Text, tbUserNoiCap.Text, tbUserDiaChi.Text, tbUserDTB.Text, tbUserDTDD.Text, tbUserEmail.Text, tbUserGhiChu.Text);

                        if (id != null)
                        {
                            MessageBox.Show("Cập nhật dữ liệu thành công");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please input password again");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime DOB = (dateUserDOB.SelectedDate == null) ? (DateTime)_curUser.DOB : dateUserDOB.SelectedDate.Value;
                DateTime ngaycap = (dateUserNgayCap.SelectedDate == null) ? (DateTime)_curUser.NgayCap : dateUserNgayCap.SelectedDate.Value;
                if (pwUserPass.Password == pwUserXacNhanPass.Password)
                {
                    byte idUserGroup = ((UserGroup)cbUserGroup.SelectedItem).Id;
                    int _userId = _curUser.Id;
                    string gioitinh = cbGioiTinh.Text;

                    if (UserImp.Update(_userId, idUserGroup, tbUserHoTen.Text, tbUserUserName.Text, pwUserPass.Password, gioitinh, DOB, ngaycap, tbUserMa.Text, tbUserCMND.Text, tbUserNoiCap.Text, tbUserDiaChi.Text, tbUserDTB.Text, tbUserDTDD.Text, tbUserEmail.Text, tbUserGhiChu.Text))
                    {
                        MessageBox.Show("Cập nhật dữ liệu thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Please input password again");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbUserIdGroup_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void tbUserMa_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void tbUserHoTen_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserPass_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserGioiTinh_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserCMND_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserNoiCap_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserDiaChi_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserDTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserDTDD_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserGhiChu_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void SetDefaultValue()
        {
            List<UserGroup> listData = UserGroupImp.GetList(String.Empty, String.Empty, String.Empty, 0, 0);
            cbUserGroup.ItemsSource = listData;
            cbUserGroup.SelectedIndex = 0;
            dateUserDOB.SelectedDate = DateTime.Now;
            dateUserNgayCap.SelectedDate = DateTime.Now;
        }


        #endregion Manager User
    }
}
