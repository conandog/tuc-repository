using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace QuanLyDonHang
{
    /// <summary>
    /// Interaction logic for dataUC.xaml
    /// </summary>
    public partial class DataUC : UserControl
    {
        public DataUC()
        {
            InitializeComponent();
        }

        private void dataUC_Loaded(object sender, RoutedEventArgs e)
        {
            tabNhaThuoc.Content = new InputNhaThuoc();
            tabCatalogue.Content = new InputCatalogue();
            tabUser.Content = new InputUser();
            //tabMaster.Content = new MasterDataUC();
        }

        private void tabData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((tabNhaThuoc != null) && (tabNhaThuoc.IsSelected))
            {
                Thread mythread = new Thread(new ThreadStart(SetNhaThuocContent));
            }
            else if ((tabCatalogue != null) && (tabCatalogue.IsSelected))
            {
                Thread mythread = new Thread(new ThreadStart(SetCataContent));
            }
            /*else if ((tabMaster != null) && (tabMaster.IsSelected))
            {
                Thread mythread = new Thread(new ThreadStart(SetMasterContent));
            }*/

        }

        public void SetNhaThuocContent()
        {

            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                   delegate()
                   {
                       tabNhaThuoc.Content = new InputNhaThuoc();
                   }));
        }

        public void SetCataContent()
        {

            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                   delegate()
                   {
                       tabCatalogue.Content = new InputCatalogue();
                   }));
        }

        /*public void SetMasterContent()
        {
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(
                   delegate()
                   {
                       tabMaster.Content = new MasterDataUC();
                   }));
        }*/
        
    }
}
