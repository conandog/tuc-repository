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
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void mnKhachHang_Click(object sender, RoutedEventArgs e)
        {
            var mainWD = (WdMain)Window.GetWindow(this);
            mainWD.LoadUcKhachHangMain();
        }

        private void mnPet_Click(object sender, RoutedEventArgs e)
        {
            var mainWD = (WdMain)Window.GetWindow(this);
            mainWD.LoadUcPetMain();
        }

        private void btThuoc_Click(object sender, RoutedEventArgs e)
        {
            var mainWD = (WdMain)Window.GetWindow(this);
            mainWD.LoadUcThuocMain();
        }

        private void btDieuTri_Click(object sender, RoutedEventArgs e)
        {
            var mainWD = (WdMain)Window.GetWindow(this);
            mainWD.LoadUcDieuTriMain();
        }
    }
}
