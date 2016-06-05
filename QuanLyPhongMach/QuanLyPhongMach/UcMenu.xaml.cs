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

namespace QuanLyPhongMach
{
    /// <summary>
    /// Interaction logic for MenuUC.xaml
    /// </summary>
    public partial class UcMenu : UserControl
    {
        public UcMenu()
        {
            InitializeComponent();
        }

        private void ButtonDropdown_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            button.ContextMenu.IsEnabled = true;
            button.ContextMenu.PlacementTarget = button;
            button.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            button.ContextMenu.IsOpen = true;
        }

        private void mnKhachHang_Click(object sender, RoutedEventArgs e)
        {
            var mainWD = Window.GetWindow(this) as WdMain;
            mainWD.LoadUcKhachHangMain();
        }

        private void mnPet_Click(object sender, RoutedEventArgs e)
        {
            var mainWD = Window.GetWindow(this) as WdMain;
            mainWD.LoadUcPetMain();
        }

        private void btThuoc_Click(object sender, RoutedEventArgs e)
        {
            var mainWD = Window.GetWindow(this) as WdMain;
            mainWD.LoadUcThuocMain();
        }

        private void btDieuTri_Click(object sender, RoutedEventArgs e)
        {
            var mainWD = Window.GetWindow(this) as WdMain;
            mainWD.LoadUcDieuTriDetail();
        }
    }
}
