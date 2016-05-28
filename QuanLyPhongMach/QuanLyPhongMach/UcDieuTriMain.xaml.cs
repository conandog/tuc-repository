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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core;

namespace QuanLyPhongMach
{
    /// <summary>
    /// Interaction logic for DieuTriMainPage.xaml
    /// </summary>
    public partial class UcDieuTriMain : UserControl
    {
        public UcDieuTriMain()
        {
            InitializeComponent();
        }

        private void UcMain_Loaded(object sender, RoutedEventArgs e)
        {
            ResetData();
        }

        private void ResetData()
        {
            tbDienThoai.Text = String.Empty;
            tbDiaChi.Text = String.Empty;
            tbTuoi.Text = String.Empty;
            tbTrongLuong.Text = String.Empty;
            tbNhietDo.Text = String.Empty;
            tbTrieuChung.Text = String.Empty;
            tbKhac.Text = String.Empty;
            tbLoiDanDo.Text = String.Empty;
            tbTongTien.Text = String.Empty;

            cbKhachHang.ItemsSource = KhachHangImp.GetList();
            cbKhachHang.SelectedIndex = -1;

            cbPet.ItemsSource = null;
            cbPetGroup.ItemsSource = null;
            cbGioiTinh.SelectedIndex = 0;

            chbIsKhamBenh.IsChecked = true;
            chbIsChich_UongThuoc.IsChecked = true;
            chbIsTruyenDichTinhMach.IsChecked = false;

            dgToaThuoc.Items.Clear();

            cbKhachHang.Focus();
        }

        private bool Validate()
        {
            bool res = false;

            if (cbKhachHang.SelectedItem == null)
            {
                MessageBox.Show(Constant.MESSAGE_MISSING_REQUIRED_FIELD);
                cbKhachHang.Focus();
            }
            else if (cbPet.SelectedItem == null)
            {
                MessageBox.Show(Constant.MESSAGE_MISSING_REQUIRED_FIELD);
                cbPet.Focus();
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
                //KhachHang khachHang = cbKhachHang.SelectedItem as KhachHang;
                //PetGroup group = cbGroup.SelectedItem as PetGroup;
                //DateTime DOB = DateTime.Today.AddYears(-ConvertUtil.ConvertToInt(tbTuoi));
                //int? id = PetImp.Insert(group.Id, khachHang.Id, tbTen.Text,
                //    cbGioiTinh.Text, DOB, ConvertUtil.ConvertToDouble(tbTrongLuong.Text), tbGhiChu.Text);

                //if (id != null)
                //{
                //    if (MessageBox.Show(Constant.MESSAGE_GENERAL_SUCCESS + Constant.MESSAGE_NEW_LINE + Constant.MESSAGE_CONTINUE,
                //        Constant.CAPTION_CONFIRM, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                //    {
                //        ResetData();
                //    }
                //    else
                //    {
                //        BackToMain();
                //    }
                //}
                //else if (MessageBox.Show(Constant.MESSAGE_ERROR + Constant.MESSAGE_NEW_LINE + Constant.MESSAGE_EXIT,
                //    Constant.CAPTION_ERROR, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                //{
                //    BackToMain();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btHuy_Click(object sender, RoutedEventArgs e)
        {
            //if (MessageBox.Show(Constant.MESSAGE_HUY, Constant.CAPTION_CONFIRM, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            //{
            //    BackToMain();
            //}
        }

        private void cbKhachHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbKhachHang.SelectedItem != null)
            {
                var selectedItem = cbKhachHang.SelectedItem as KhachHang;
                tbDienThoai.Text = selectedItem.DienThoai;
                tbDiaChi.Text = selectedItem.DiaChi;
                cbPet.ItemsSource = PetImp.GetListByIdKhachHang(selectedItem.Id);

                if (cbPet.HasItems)
                {
                    cbPet.SelectedIndex = 0;
                }
            }
        }

        private void cbPet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbPet.SelectedItem != null)
            {
                var selectedPet = cbPet.SelectedItem as Pet;
                Model.PetViewModel selectedItem = new Model.PetViewModel(selectedPet);
                cbPetGroup.SelectedItem = selectedItem.PetGroup;
                tbTuoi.Text = selectedItem.Tuoi.ToString();
                cbGioiTinh.SelectedItem = selectedItem.GioiTinh;
                tbTrongLuong.Text = selectedItem.TrongLuong.ToString();
                cbPet.ItemsSource = PetImp.GetListByIdKhachHang(selectedItem.Id);
            }
        }
    }

    public class RowToIndexConverter : MarkupExtension, IValueConverter
    {
        static RowToIndexConverter converter;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DataGridRow row = value as DataGridRow;
            if (row != null)
                return row.GetIndex();
            else
                return -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (converter == null) converter = new RowToIndexConverter();
            return converter;
        }

        public RowToIndexConverter()
        {
        }
    }
}
