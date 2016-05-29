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
using System.Windows.Shapes;
using Core;

namespace QuanLyPhongMach
{
    /// <summary>
    /// Interaction logic for MainWD.xaml
    /// </summary>
    public partial class WdMain : Window
    {
        public WdMain()
        {
            InitializeComponent();

            spMenu.Children.Add(new UcMenu());
        }

        private void wdMain_Loaded(object sender, RoutedEventArgs e)
        {
            Connection.NewConnection();
            Connection.currentUserId = 1;
            //menuUC = new MenuUC();
            //currentControl = menuUC;
            //spMenu.Children.Add(currentControl);
        }

        public void LoadUcKhachHangMain()
        {
            spMain.Children.Clear();
            spMain.Children.Add(new UcKhachHangMain());
        }

        public void LoadUcKhachHangDetail()
        {
            spMain.Children.Clear();
            spMain.Children.Add(new UcKhachHangDetail());
        }

        public void LoadUcKhachHangDetail(object selectedItem)
        {
            spMain.Children.Clear();
            spMain.Children.Add(new UcKhachHangDetail(selectedItem));
        }

        public void LoadUcPetMain()
        {
            spMain.Children.Clear();
            spMain.Children.Add(new UcPetMain());
        }

        public void LoadUcPetDetail()
        {
            spMain.Children.Clear();
            spMain.Children.Add(new UcPetDetail());
        }

        public void LoadUcPetDetail(object selectedItem)
        {
            spMain.Children.Clear();
            spMain.Children.Add(new UcPetDetail(selectedItem));
        }

        public void LoadUcThuocMain()
        {
            spMain.Children.Clear();
            spMain.Children.Add(new UcThuocMain());
        }

        public void LoadUcThuocDetail()
        {
            spMain.Children.Clear();
            spMain.Children.Add(new UcThuocDetail());
        }

        public void LoadUcThuocDetail(object selectedItem)
        {
            spMain.Children.Clear();
            spMain.Children.Add(new UcThuocDetail(selectedItem));
        }

        public void LoadUcDieuTriMain()
        {
            spMain.Children.Clear();
            spMain.Children.Add(new UcDieuTriMain());
        }
    }
}
