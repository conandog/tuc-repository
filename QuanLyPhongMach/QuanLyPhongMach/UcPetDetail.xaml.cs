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
        private int currentId;
        private bool isEditing = false;

        public UcPetDetail()
        {
            InitializeComponent();
        }

        public UcPetDetail(object selectedData)
        {
            InitializeComponent();
            LoadData(selectedData);
            isEditing = true;
        }

        private void UcMain_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isEditing)
            {
                ResetData();
            }
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
            tbTrongLuong.Text = String.Empty;
            tbGhiChu.Text = String.Empty;
            cbGioiTinh.SelectedIndex = 0;

            cbGroup.ItemsSource = PetGroupImp.GetList();
            cbGroup.SelectedIndex = 0;

            cbKhachHang.ItemsSource = KhachHangImp.GetList();
            cbKhachHang.SelectedIndex = -1;
            cbKhachHang.Focus();
        }

        private void LoadData(object selectedData)
        {
            Pet data = null;

            if (selectedData is int)
            {
                data = PetImp.GetById(ConvertUtil.ConvertToInt(selectedData));
            }
            else
            {
                data = selectedData as Pet;
            }

            currentId = data.Id;
            tbTen.Text = data.Ten;
            tbTuoi.Text = String.Empty;
            tbTrongLuong.Text = data.TrongLuong == null ? String.Empty : data.TrongLuong.ToString();
            tbGhiChu.Text = data.GhiChu;

            cbGioiTinh.Text = data.GioiTinh;
            cbGroup.ItemsSource = PetGroupImp.GetList();
            cbGroup.SelectedItem = data.PetGroup;
            cbKhachHang.ItemsSource = KhachHangImp.GetList();
            cbKhachHang.SelectedItem = data.KhachHang;

            tbTen.Focus();
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

        private void Create()
        {
            if (!Validate())
            {
                return;
            }

            try
            {
                KhachHang khachHang = cbKhachHang.SelectedItem as KhachHang;
                PetGroup group = cbGroup.SelectedItem as PetGroup;
                DateTime DOB = DateTime.Today.AddYears(-ConvertUtil.ConvertToInt(tbTuoi.Text));
                int? id = PetImp.Insert(group.Id, khachHang.Id, tbTen.Text,
                    cbGioiTinh.Text, DOB, ConvertUtil.ConvertToDouble(tbTrongLuong.Text), tbGhiChu.Text);

                if (id != null)
                {
                    if (MessageBox.Show(Constant.MESSAGE_GENERAL_SUCCESS + Constant.MESSAGE_NEW_LINE + Constant.MESSAGE_CONTINUE,
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

        private void Update()
        {
            if (!Validate())
            {
                return;
            }

            try
            {
                KhachHang khachHang = cbKhachHang.SelectedItem as KhachHang;
                PetGroup group = cbGroup.SelectedItem as PetGroup;
                DateTime DOB = DateTime.Today.AddYears(-ConvertUtil.ConvertToInt(tbTuoi.Text));
                bool isSuccess = PetImp.Update(currentId, group.Id, khachHang.Id, tbTen.Text,
                    cbGioiTinh.Text, DOB, ConvertUtil.ConvertToDouble(tbTrongLuong.Text), tbGhiChu.Text);

                if (isSuccess)
                {
                    if (MessageBox.Show(Constant.MESSAGE_GENERAL_SUCCESS + Constant.MESSAGE_NEW_LINE + Constant.MESSAGE_CONTINUE,
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

        private void btHoanTat_Click(object sender, RoutedEventArgs e)
        {
            if (!isEditing)
            {
                Create();
            }
            else
            {
                Update();
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
