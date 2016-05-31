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
using Controller.Implementation;
using Model;

namespace QuanLyDonHang
{
    /// <summary>
    /// Interaction logic for mainUC.xaml
    /// </summary>
    public partial class MainUC : UserControl
    {
        private static ManagerWD _managerWD;
        public MainUC()
        {
            InitializeComponent();
        }

        private void btData_Click(object sender, RoutedEventArgs e)
        {
            _managerWD = (ManagerWD)Window.GetWindow(this);
            _managerWD.callDataUC();
        }

        private void btPrice_Click(object sender, RoutedEventArgs e)
        {
            _managerWD = (ManagerWD)Window.GetWindow(this);
            _managerWD.callPriceUC();
        }

        private void btExportExcel_Click(object sender, RoutedEventArgs e)
        {
            _managerWD = (ManagerWD)Window.GetWindow(this);
            _managerWD.callExcelUC();
        }
    }
}
