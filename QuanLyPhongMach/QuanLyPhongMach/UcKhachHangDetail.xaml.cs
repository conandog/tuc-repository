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
    /// Interaction logic for KhachHang.xaml
    /// </summary>
    public partial class UcKhachHangDetail : UserControl
    {
        public UcKhachHangDetail()
        {
            InitializeComponent();
        }

        private void UcMain_Loaded(object sender, RoutedEventArgs e)
        {
            ResetData();
        }

        private void BackToMain()
        {
            var mainWD = Window.GetWindow(this) as WdMain;
            mainWD.LoadUcKhachHangMain();
        }

        private void ResetData()
        {
            tbMa.Text = String.Empty;
            tbTen.Text = String.Empty;
            tbCMND.Text = String.Empty;
            tbDiaChi.Text = String.Empty;
            tbDienThoai.Text = String.Empty;
            tbEmail.Text = String.Empty;
            tbGhiChu.Text = String.Empty;

            cbGioiTinh.SelectedIndex = 0;
            datePicker.SelectedDate = DateTime.Now;

            tbMa.Focus();
        }

        private bool Validate()
        {
            bool res = false;

            if (String.IsNullOrEmpty(tbMa.Text))
            {
                MessageBox.Show(Constant.MESSAGE_MISSING_REQUIRED_FIELD);
                tbMa.Focus();
            }
            else if (String.IsNullOrEmpty(tbTen.Text))
            {
                MessageBox.Show(Constant.MESSAGE_MISSING_REQUIRED_FIELD);
                tbTen.Focus();
            }
            else
            {
                res = true;
            }

            return res;
        }

        private void btHoanTat_Click(object sender, RoutedEventArgs e)
        {
            if (!Validate())
            {
                return;
            }

            try
            {
                KhachHang data = KhachHangImp.GetByMa(tbMa.Text);

                if (data != null)
                {
                    MessageBox.Show(Constant.MESSAGE_DUPLICATED_CLIENT_CODE);
                    tbMa.Focus();
                    tbMa.SelectAll();
                }
                else
                {
                    int idKhachHangGroup = KhachHangGroupImp.GetList().FirstOrDefault().Id;
                    int? id = KhachHangImp.Insert(Connection.CurrentUser, idKhachHangGroup, tbMa.Text, tbTen.Text,
                        cbGioiTinh.Text, datePicker.SelectedDate, tbCMND.Text, tbDiaChi.Text,
                        tbDienThoai.Text, tbEmail.Text, tbGhiChu.Text);

                    if (id != null)
                    {
                        if (MessageBox.Show(Constant.MESSAGE_UPDATE_SUCCESSFUL + Constant.MESSAGE_NEW_LINE + Constant.MESSAGE_CONTINUE,
                        Constant.CAPTION_CONFIRM, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            ResetData();
                        }
                        else
                        {
                            BackToMain();
                        }
                    }
                    else if (MessageBox.Show(Constant.MESSAGE_ERROR + Constant.MESSAGE_NEW_LINE + Constant.MESSAGE_EXIT,
                        Constant.CAPTION_ERROR, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        BackToMain();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btHuy_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(Constant.MESSAGE_HUY, Constant.CAPTION_CONFIRM, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                BackToMain();
            }
        }
    }
}
