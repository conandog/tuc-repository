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
    /// Interaction logic for ThuocDetailPage.xaml
    /// </summary>
    public partial class UcThuocDetail : UserControl
    {
        private int currentId;
        private bool isEditing = false;

        public UcThuocDetail()
        {
            InitializeComponent();
        }

        public UcThuocDetail(object selectedData)
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
            mainWD.LoadUcThuocMain();
        }

        private void ResetData()
        {
            tbMa.Text = String.Empty;
            tbTen.Text = String.Empty;
            tbDonViTinh.Text = String.Empty;
            tbMoTa.Text = String.Empty;

            cbGroup.ItemsSource = ThuocGroupImp.GetList();
            cbGroup.SelectedIndex = 0;

            tbMa.Focus();
        }

        private void LoadData(object selectedData)
        {
            Thuoc data = null;

            if (selectedData is int)
            {
                data = ThuocImp.GetById(ConvertUtil.ConvertToInt(selectedData));
            }
            else
            {
                data = selectedData as Thuoc;
            }

            currentId = data.Id;
            tbMa.Text = data.Ma;
            tbMa.IsReadOnly = true;
            tbTen.Text = data.Ten;
            tbDonViTinh.Text = data.DonViTinh;
            tbMoTa.Text = data.MoTa;

            cbGroup.ItemsSource = ThuocGroupImp.GetList();
            cbGroup.SelectedItem = data.ThuocGroup;

            tbTen.Focus();
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
                Thuoc data = ThuocImp.GetByMa(tbMa.Text);

                if (data != null)
                {
                    MessageBox.Show(String.Format(Constant.MESSAGE_INSERT_ERROR_DUPLICATE, tbMa.Text));
                    tbMa.Focus();
                    tbMa.SelectAll();
                }
                else
                {
                    ThuocGroup group = cbGroup.SelectedItem as ThuocGroup;
                    int? id = ThuocImp.Insert(group.Id, tbMa.Text, tbTen.Text, tbDonViTinh.Text, tbMoTa.Text);

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
                ThuocGroup group = cbGroup.SelectedItem as ThuocGroup;
                bool isSuccess = ThuocImp.Update(currentId, group.Id, tbMa.Text, tbTen.Text, tbDonViTinh.Text, tbMoTa.Text);

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
