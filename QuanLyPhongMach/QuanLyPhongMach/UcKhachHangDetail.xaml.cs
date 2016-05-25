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
    /// Interaction logic for KhachHang.xaml
    /// </summary>
    public partial class UcKhachHangDetail : UserControl
    {
        public UcKhachHangDetail()
        {
            InitializeComponent();
        }

        private void btHuy_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(Constant.HUY_MESSAGE, Constant.CONFIRMATION_CAPTION, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var mainWD = (WdMain)Window.GetWindow(this);
                mainWD.LoadUcKhachHangMain();
            }
        }
    }
}
