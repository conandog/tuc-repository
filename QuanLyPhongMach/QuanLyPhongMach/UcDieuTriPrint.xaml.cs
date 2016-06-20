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
using QuanLyPhongMach.Model;

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
            LoadData(data);
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

            tblDiaChi.Text = data.Pet.KhachHang.DiaChi;
            tblTuoi.Text = PetImp.GetTuoi(data.Pet.DOB).ToString();
            tblTrongLuong.Text = data.TrongLuong.HasValue ? data.TrongLuong.ToString() : String.Empty;
            tblTrieuChung.Text = data.TrieuChung;
            tblKhac.Text = data.Khac;
            tblLoiDanDo.Text = data.LoiDanDo;
            tblTongTien.Text = data.TongTien.ToString(Constant.DEFAULT_FORMAT_MONEY);
            tblGioiTinhPet.Text = data.Pet.GioiTinh;
            tblLoaiThu.Text = data.Pet.PetGroup.Ten + Constant.SYMBOL_LINK_STRING + data.Pet.Giong;
            tblDate.Text = String.Format(Constant.DEFAULT_TYPE_DATE, data.CreateDate.Day, data.CreateDate.Month, data.CreateDate.Year);

            chbIsKhamBenh.IsChecked = data.IsKhamBenh;
            chbIsChich_UongThuoc.IsChecked = data.IsChich_UongThuoc;
            chbIsTruyenDichTinhMach.IsChecked = data.IsTruyenDichTinhMach;

            List<ToaThuocViewModel> listThuoc = new List<ToaThuocViewModel>();

            foreach (var thuoc in data.PhieuDieuTri_Thuoc)
            {
                ToaThuocViewModel newThuoc = new ToaThuocViewModel(thuoc);
                newThuoc.STT = listThuoc.Count + 1;
                listThuoc.Add(newThuoc);
            }

            lvToaThuoc.ItemsSource = listThuoc;
        }
    }
}
