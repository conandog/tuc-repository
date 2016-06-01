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
            cbPetGroup.ItemsSource = PetGroupImp.GetList();
            cbPetGroup.SelectedIndex = 0;
            cbGioiTinh.SelectedIndex = 0;

            chbIsKhamBenh.IsChecked = true;
            chbIsChich_UongThuoc.IsChecked = true;
            chbIsTruyenDichTinhMach.IsChecked = false;

            dgToaThuoc.Items.Clear();

            List<PhieuDieuTri_Thuoc> listData = new List<PhieuDieuTri_Thuoc>()
            {
                new PhieuDieuTri_Thuoc() { Thuoc = ThuocImp.GetList().FirstOrDefault(), DuongCap = "IM" }
            };

            dgToaThuoc.ItemsSource = listData;
            cbThuoc.ItemsSource = ThuocImp.GetList();
            cbDuongCap.ItemsSource = new List<string>() { "IM", "IV", "PO" };

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
            if (!Validate() || !ValidateDataGrid())
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
                else
                {
                    tbTuoi.Text = String.Empty;
                    cbGioiTinh.Text = "Đực";
                    tbTrongLuong.Text = String.Empty;
                    tbNhietDo.Text = String.Empty;
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
                cbGioiTinh.Text = selectedItem.GioiTinh;
                tbTrongLuong.Text = selectedItem.TrongLuong.ToString();
                tbNhietDo.Text = String.Empty;
            }
        }

        private bool ValidateDataGrid()
        {
            bool res = false;
            var listData = new List<Thuoc>();

            for (int i = 0; i < dgToaThuoc.Items.Count; i++)
            {
                DataGridRow row = dgToaThuoc.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;

                if (row.Item != null && row.Item is PhieuDieuTri_Thuoc)
                {
                    var data = row.Item as PhieuDieuTri_Thuoc;

                    if (data.Thuoc != null)
                    {
                        listData.Add(data.Thuoc);
                    }
                }
            }

            var duplicateKeys = listData.GroupBy(x => x).Where(group => group.Count() > 1).Select(group => group.Key).ToList();

            if (duplicateKeys.Count > 0 && MessageBox.Show("Toa thuốc có dữ liệu bị trùng!" + Constant.MESSAGE_NEW_LINE + "Bạn có muốn tiếp tục cập nhật?",
                    Constant.CAPTION_CONFIRM, MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK
                || duplicateKeys.Count == 0)
            {
                res = true;
            }

            return res;
        }

        private void GenerateRowNumber()
        {
            for (int i = 0; i < dgToaThuoc.Items.Count; i++)
            {
                DataGridRow row = dgToaThuoc.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
                row.Header = (i + 1).ToString();
            }
        }

        private void dgToaThuoc_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (e.Row.IsNewItem)
            {
                GenerateRowNumber();
            }
            else
            {
                e.Row.Header = (e.Row.GetIndex() + 1).ToString();
            }
        }

        private void dgToaThuoc_UnloadingRow(object sender, DataGridRowEventArgs e)
        {
            GenerateRowNumber();
        }
    }
}
