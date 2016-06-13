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
using Controller.Common;
using Core;

namespace QuanLyPhongMach
{
    /// <summary>
    /// Interaction logic for UcDieuTriPrint.xaml
    /// </summary>
    public partial class UcDieuTriPrint : UserControl
    {
        public UcDieuTriPrint()
        {
            InitializeComponent();
            ResetData();
        }

        public UcDieuTriPrint(PhieuDieuTri data)
        {
            InitializeComponent();
        }

        private void ResetData()
        {
            tblDiaChi.Text = String.Empty;
            tblTuoi.Text = String.Empty;
            tblTrongLuong.Text = String.Empty;
            tblTrieuChung.Text = String.Empty;
            tblKhac.Text = String.Empty;
            tblLoiDanDo.Text = String.Empty;
            tblTongTien.Text = String.Empty;
            tblGioiTinhPet.Text = String.Empty;
            tblLoaiThu.Text = String.Empty;
            tblDate.Text = String.Format(Constant.DEFAULT_TYPE_DATE, DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);

            chbIsKhamBenh.IsChecked = true;
            chbIsChich_UongThuoc.IsChecked = true;
            chbIsTruyenDichTinhMach.IsChecked = false;

            //dgToaThuoc.ItemsSource = null;

            //List<PhieuDieuTri_Thuoc> listData = new List<PhieuDieuTri_Thuoc>()
            //{
            //    new PhieuDieuTri_Thuoc() {  }
            //};

            //dgToaThuoc.ItemsSource = listData;
            //cbThuoc.ItemsSource = ThuocImp.GetList();
            //cbDuongCap.ItemsSource = new List<string>() { "IM", "IV", "PO" };

            //cbKhachHang.Focus();
        }

        private void LoadData(object selectedData)
        {
            PhieuDieuTri data = null;

            if (selectedData is int)
            {
                data = PhieuDieuTriImp.GetById(ConvertUtil.ConvertToInt(selectedData));
            }
            else
            {
                data = selectedData as PhieuDieuTri;
            }

            tblDiaChi.Text = String.Empty;
            tblTuoi.Text = String.Empty;
            tblTrongLuong.Text = String.Empty;
            tblTrieuChung.Text = String.Empty;
            tblKhac.Text = String.Empty;
            tblLoiDanDo.Text = String.Empty;
            tblTongTien.Text = String.Empty;
            tblGioiTinhPet.Text = String.Empty;
            tblLoaiThu.Text = String.Empty;
            tblDate.Text = String.Format(Constant.DEFAULT_TYPE_DATE, DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);

            chbIsKhamBenh.IsChecked = true;
            chbIsChich_UongThuoc.IsChecked = true;
            chbIsTruyenDichTinhMach.IsChecked = false;
        }
    }
}
