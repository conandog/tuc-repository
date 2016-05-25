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
    /// Interaction logic for ThuocMainPage.xaml
    /// </summary>
    public partial class UcThuocMain : UserControl
    {
        public UcThuocMain()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            var mainWD = (WdMain)Window.GetWindow(this);
            mainWD.LoadUcThuocDetail();
        }
    }
}
