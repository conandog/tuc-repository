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
using Controller.Common;

namespace QuanLyPhongMach
{
    /// <summary>
    /// Interaction logic for PetUC.xaml
    /// </summary>
    public partial class UcPetDetail : UserControl
    {
        public UcPetDetail()
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
            mainWD.LoadUcPetMain();
        }

        private void ResetData()
        {
            tbTen.Text = String.Empty;
            tbTuoi.Text = String.Empty;
            tbGhiChu.Text = String.Empty;
            cbGioiTinh.SelectedIndex = 0;

            cbGroup.ItemsSource = PetGroupImp.GetList();
            cbGroup.SelectedIndex = 0;

            cbKhachHang.ItemsSource = KhachHangImp.GetList();
            cbKhachHang.SelectedIndex = -1;
            cbKhachHang.Focus();
        }

        private bool Validate()
        {
            bool res = false;

            if (cbGroup.SelectedItem == null)
            {
                MessageBox.Show(Constant.MESSAGE_MISSING_REQUIRED_FIELD);
                cbGroup.Focus();
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
                KhachHang khachHang = cbKhachHang.SelectedItem as KhachHang;
                PetGroup group = cbGroup.SelectedItem as PetGroup;
                DateTime DOB = DateTime.Today.AddYears(-ConvertUtil.ConvertToInt(tbTuoi));

                int? id = PetImp.Insert(Connection.CurrentUser, group.Id, khachHang.Id, tbTen.Text,
                    cbGioiTinh.Text, DOB, tbGhiChu.Text);

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
