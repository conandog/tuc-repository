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

namespace QuanLyDonHang
{
    /// <summary>
    /// Interaction logic for managerWD.xaml
    /// </summary>
    public partial class ManagerWD : Window
    {
        private MasterDataUC _masterDataUC;
        private MainUC _mainUC;
        private PriceUC _priceUC;
        private DataUC _dataUC;
        private Control _currentUser;

        public ManagerWD()
        {
            InitializeComponent();
            _mainUC = new MainUC();
            _currentUser = _mainUC;
            stMainUser.Children.Add(_currentUser);
            _dataUC = new DataUC();
            _currentUser = _dataUC;
            stMainUC.Children.Add(_currentUser);
        }

        public void callDataUC()
        {
            stMainUC.Children.Clear();
            _dataUC = new DataUC();
            _currentUser = _dataUC;
            stMainUC.Children.Add(_currentUser);
        }

        public void callPriceUC()
        {
            stMainUC.Children.Clear();
            _priceUC = new PriceUC();
            _priceUC.SetDefaultData();
            _currentUser = _priceUC;
            stMainUC.Children.Add(_currentUser);
        }

        public void EditPriceUC(ItemMaster data)
        {
            stMainUC.Children.Clear();
            _priceUC = new PriceUC();
            _priceUC.SetTbEditVisible();
            _priceUC.SetDefaultData();
            _priceUC.SetDisplayData(data);
            _currentUser = _priceUC;
            stMainUC.Children.Add(_currentUser);
        }

        public void callExcelUC()
        {
            stMainUC.Children.Clear();
            _masterDataUC = new MasterDataUC();
            _currentUser = _masterDataUC;
            stMainUC.Children.Add(_currentUser);
        }

    }
}
