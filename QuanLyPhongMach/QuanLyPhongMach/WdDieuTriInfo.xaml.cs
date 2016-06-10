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

namespace QuanLyPhongMach
{
    /// <summary>
    /// Interaction logic for WdDieuTriInfo.xaml
    /// </summary>
    public partial class WdDieuTriInfo : Window
    {
        public WdDieuTriInfo()
        {
            InitializeComponent();
        }

        private void WdMain_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        public void CreateMyWPFControlReport()
        {
            ////Set up the WPF Control to be printed
            //MyWPFControl controlToPrint;
            //controlToPrint = new MyWPFControl();
            //controlToPrint.DataContext = usefulData;

            //FixedDocument fixedDoc = new FixedDocument();
            //PageContent pageContent = new PageContent();
            //FixedPage fixedPage = new FixedPage();

            ////Create first page of document
            //fixedPage.Children.Add(controlToPrint);
            //((System.Windows.Markup.IAddChild)pageContent).AddChild(fixedPage);
            //fixedDoc.Pages.Add(pageContent);
            ////Create any other required pages here

            ////View the document
            //documentViewer1.Document = fixedDoc;
        }
    }
}
