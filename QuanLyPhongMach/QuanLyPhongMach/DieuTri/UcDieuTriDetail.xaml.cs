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
using Controller.Common;

namespace QuanLyPhongMach
{
    /// <summary>
    /// Interaction logic for UcDieuTriDetail.xaml
    /// </summary>
    public partial class UcDieuTriDetail : UserControl
    {
        public UcDieuTriDetail()
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
            tbGiong.Text = String.Empty;
            tbTuoi.Text = String.Empty;
            tbTrongLuong.Text = String.Empty;
            tbNhietDo.Text = String.Empty;
            tbTrieuChung.Text = String.Empty;
            tbKhac.Text = String.Empty;
            tbLoiDanDo.Text = String.Empty;
            tbTongTien.Text = String.Empty;

            cbGioiTinhKhachHang.SelectedIndex = 0;
            cbKhachHang.ItemsSource = KhachHangImp.GetList();
            cbKhachHang.SelectedIndex = -1;

            cbGioiTinhPet.SelectedIndex = 0;
            cbPet.ItemsSource = null;
            cbPetGroup.ItemsSource = PetGroupImp.GetList();
            cbPetGroup.SelectedIndex = 0;

            chbIsKhamBenh.IsChecked = true;
            chbIsChich_UongThuoc.IsChecked = true;
            chbIsTruyenDichTinhMach.IsChecked = false;

            dgToaThuoc.ItemsSource = null;

            List<PhieuDieuTri_Thuoc> listData = new List<PhieuDieuTri_Thuoc>()
            {
                new PhieuDieuTri_Thuoc() {  }
            };

            dgToaThuoc.ItemsSource = listData;
            cbThuoc.ItemsSource = ThuocImp.GetList();
            cbDuongCap.ItemsSource = new List<string>() { "IM", "IV", "PO" };

            cbKhachHang.Focus();
        }

        private void LoadFromTheLast(PhieuDieuTri data)
        {
            tbTrongLuong.Text = data.TrongLuong.HasValue ? data.TrongLuong.ToString() : String.Empty;
            tbTrieuChung.Text = data.TrieuChung;
            tbKhac.Text = data.Khac;
            tbLoiDanDo.Text = data.LoiDanDo;
            tbTongTien.Text = data.TongTien.ToString(Constant.DEFAULT_FORMAT_MONEY);

            chbIsKhamBenh.IsChecked = data.IsKhamBenh;
            chbIsChich_UongThuoc.IsChecked = data.IsChich_UongThuoc;
            chbIsTruyenDichTinhMach.IsChecked = data.IsTruyenDichTinhMach;

            dgToaThuoc.ItemsSource = data.PhieuDieuTri_Thuoc;
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

        private int? CreateKhachHang()
        {
            int? res = null;

            try
            {
                if (cbKhachHang.SelectedItem != null)
                {
                    var data = cbKhachHang.SelectedItem as KhachHang;
                    data.GioiTinh = cbGioiTinhKhachHang.Text;
                    data.DienThoai = tbDienThoai.Text;
                    data.DiaChi = tbDiaChi.Text;
                    bool isSuccess = KhachHangImp.Update(data);

                    if (isSuccess)
                    {
                        res = data.Id;
                    }
                }
                else
                {
                    var khachHangGroup = KhachHangGroupImp.GetList().FirstOrDefault();
                    int idKhachHangGroup = khachHangGroup.Id;
                    string ma = khachHangGroup.Ma + KhachHangImp.GetList().LastOrDefault().Id + 1;
                    int? id = KhachHangImp.Insert(idKhachHangGroup, ma, cbKhachHang.Text,
                        cbGioiTinhKhachHang.Text, DateTime.Now, String.Empty, tbDiaChi.Text,
                        tbDienThoai.Text);

                    if (id != null)
                    {
                        res = id;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return res;
        }

        private int? CreatePet()
        {
            int? res = null;

            try
            {
                int? idKhachHang = CreateKhachHang();

                if (idKhachHang != null)
                {
                    if (cbPet.SelectedItem != null)
                    {
                        var data = cbPet.SelectedItem as Pet;
                        data.GioiTinh = cbGioiTinhPet.Text;
                        data.Giong = tbGiong.Text;
                        DateTime DOB = DateTime.Today.AddYears(-ConvertUtil.ConvertToInt(tbTuoi.Text));
                        data.TrongLuong = ConvertUtil.ConvertToDouble(tbTrongLuong.Text);
                        bool isSuccess = PetImp.Update(data);

                        if (isSuccess)
                        {
                            res = data.Id;
                        }
                    }
                    else
                    {
                        PetGroup group = cbPetGroup.SelectedItem as PetGroup;
                        DateTime DOB = DateTime.Today.AddYears(-ConvertUtil.ConvertToInt(tbTuoi.Text));
                        int? id = PetImp.Insert(group.Id, idKhachHang.Value, cbPet.Text,
                            cbGioiTinhPet.Text, tbGiong.Text, DOB, ConvertUtil.ConvertToDouble(tbTrongLuong.Text));

                        if (id != null)
                        {
                            res = id;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return res;
        }

        private int? CreatePhieuDieuTri()
        {
            int? res = null;

            try
            {
                int? idPet = CreatePet();

                if (idPet != null)
                {
                    string ma = Constant.DEFAULT_PHIEU_DIEU_TRI_PREFIX + PhieuDieuTriImp.GetList().LastOrDefault().Id + 1;
                    long money = ConvertUtil.ConvertToLong(tbTongTien.Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty));
                    int? id = PhieuDieuTriImp.Insert(idPet.Value, ma, money,
                        chbIsKhamBenh.IsChecked.Value, chbIsChich_UongThuoc.IsChecked.Value, chbIsTruyenDichTinhMach.IsChecked.Value,
                        tbKhac.Text, tbTrieuChung.Text, ConvertUtil.ConvertToDouble(tbTrongLuong.Text), tbNhietDo.Text, tbLoiDanDo.Text);

                    if (id != null)
                    {
                        res = id;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return res;
        }

        private bool CreatePhieuDieuTri_Thuoc(int idPhieuDieuTri)
        {
            bool res = true;

            try
            {
                for (int i = 0; i < dgToaThuoc.Items.Count; i++)
                {
                    DataGridRow row = dgToaThuoc.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;

                    if (row.Item != null && row.Item is PhieuDieuTri_Thuoc)
                    {
                        var data = row.Item as PhieuDieuTri_Thuoc;

                        if (data.Thuoc != null && !String.IsNullOrEmpty(data.DuongCap) && ConvertUtil.ConvertToDouble(data.LieuLuong) > 0)
                        {
                            int? id = PhieuDieuTri_ThuocImp.Insert(idPhieuDieuTri, data.Thuoc.Id, data.DuongCap, data.LieuLuong);

                            if (id == null)
                            {
                                res = false;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                res = false;
            }

            return res;
        }

        private void Create()
        {
            int? idPhieuDieuTri = CreatePhieuDieuTri();

            if (idPhieuDieuTri != null && CreatePhieuDieuTri_Thuoc(idPhieuDieuTri.Value))
            {
                MessageBox.Show(Constant.MESSAGE_GENERAL_SUCCESS);
                ResetData();
            }
            else
            {
                MessageBox.Show(Constant.MESSAGE_GENERAL_ERROR,
                    Constant.CAPTION_ERROR, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btHoanTat_Click(object sender, RoutedEventArgs e)
        {
            if (!Validate() || !ValidateDataGrid())
            {
                return;
            }

            try
            {
                //Create();
                ResetData();
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
                    cbGioiTinhPet.Text = "Đực";
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
                cbGioiTinhPet.Text = selectedItem.GioiTinh;
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
                    else if (data.Thuoc == null || String.IsNullOrEmpty(data.DuongCap) || data.LieuLuong <= 0)
                    {
                        MessageBox.Show(Constant.MESSAGE_MISSING_REQUIRED_FIELD);
                        return false;
                    }
                }
            }

            var duplicateKeys = listData.GroupBy(x => x).Where(group => group.Count() > 1).Select(group => group.Key).ToList();

            if (duplicateKeys.Count > 0 && MessageBox.Show("Toa thuốc có dữ liệu bị trùng!" + Constant.MESSAGE_NEW_LINE + "Bạn có muốn tiếp tục cập nhật?",
                    Constant.CAPTION_CONFIRM, MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
            {
                res = false;
            }
            else
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

        private void tbDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            CommonFunc.ValidateNumeric(e);
        }

        private void tbTrongLuong_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbTrongLuong.Text = ConvertUtil.ConvertToDouble(tbTrongLuong.Text) <= 0 ? string.Empty :
                ConvertUtil.ConvertToDouble(tbTrongLuong.Text).ToString();
        }

        private void tbTongTien_TextChanged(object sender, TextChangedEventArgs e)
        {
            long money = ConvertUtil.ConvertToLong(tbTongTien.Text.Replace(Constant.SYMBOL_LINK_MONEY, string.Empty));
            tbTongTien.Text = money.ToString(Constant.DEFAULT_FORMAT_MONEY);
            tbTongTien.Select(tbTongTien.Text.Length, 0);
        }

        private void tbTongTien_KeyDown(object sender, KeyEventArgs e)
        {
            CommonFunc.ValidateNumeric(e);
        }

        private void tbTuoi_KeyDown(object sender, KeyEventArgs e)
        {
            CommonFunc.ValidateNumeric(e);
        }

        private void tbTrongLuong_KeyDown(object sender, KeyEventArgs e)
        {
            CommonFunc.ValidateNumeric(e);
        }

        private void btCopyFromTheLast_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
