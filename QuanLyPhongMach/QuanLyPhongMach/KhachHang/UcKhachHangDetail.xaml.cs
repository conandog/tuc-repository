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
    /// Interaction logic for KhachHang.xaml
    /// </summary>
    public partial class UcKhachHangDetail : UserControl
    {
        private int currentId;
        private bool isEditing = false;

        public UcKhachHangDetail()
        {
            InitializeComponent();
        }

        public UcKhachHangDetail(object selectedData)
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

        private void LoadData(object selectedData)
        {
            KhachHang data = null;

            if (selectedData is int)
            {
                data = KhachHangImp.GetById(ConvertUtil.ConvertToInt(selectedData));
            }
            else
            {
                data = selectedData as KhachHang;
            }

            currentId = data.Id;
            tbMa.Text = data.Ma;
            tbMa.IsReadOnly = true;
            tbTen.Text = data.Ten;
            tbCMND.Text = data.CMND;
            tbDiaChi.Text = data.DiaChi;
            tbDienThoai.Text = data.DienThoai;
            tbEmail.Text = data.Email;
            tbGhiChu.Text = data.GhiChu;

            cbGioiTinh.Text = data.GioiTinh;
            datePicker.SelectedDate = data.DOB;

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

        private void Create()
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
                    MessageBox.Show(String.Format(Constant.MESSAGE_INSERT_ERROR_DUPLICATE, tbMa.Text));
                    tbMa.Focus();
                    tbMa.SelectAll();
                }
                else
                {
                    int idKhachHangGroup = KhachHangGroupImp.GetList().FirstOrDefault().Id;
                    int? id = KhachHangImp.Insert(idKhachHangGroup, tbMa.Text, tbTen.Text,
                        cbGioiTinh.Text, datePicker.SelectedDate, tbCMND.Text, tbDiaChi.Text,
                        tbDienThoai.Text, tbEmail.Text, tbGhiChu.Text);

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
                int idKhachHangGroup = KhachHangGroupImp.GetList().FirstOrDefault().Id;
                bool isSuccess = KhachHangImp.Update(currentId, idKhachHangGroup, tbMa.Text, tbTen.Text,
                    cbGioiTinh.Text, datePicker.SelectedDate, tbCMND.Text, tbDiaChi.Text,
                    tbDienThoai.Text, tbEmail.Text, tbGhiChu.Text);

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
