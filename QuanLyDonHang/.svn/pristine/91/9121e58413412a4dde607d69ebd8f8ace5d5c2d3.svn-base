using Controller.Implementation;
using Model;
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
using QuanLyDonHang.Common;

namespace QuanLyDonHang
{
    /// <summary>
    /// Interaction logic for AddCatalogueUC.xaml
    /// </summary>
    public partial class AddCatalogueUC : UserControl
    {
        private ManagerWD _managerWD;
        private Catalogue _dataCata;
        public AddCatalogueUC()
        {
            InitializeComponent();
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            _managerWD = (ManagerWD)Window.GetWindow(this);
            TabControl _tabData = (TabControl)Utilities.FindChildControl<TabControl>(_managerWD);
            InputCatalogue _inputCatalogue = new InputCatalogue();
            TabItem _tabItemCatalogue = _tabData.Items[2] as TabItem;
            _tabItemCatalogue.Content = _inputCatalogue;
        }

        public void SetTbEditVisible()
        {
            tbAddCatalogue.Visibility = Visibility.Collapsed;
            tbEditCatalogue.Visibility = Visibility.Visible;
            btUpdateCata.Visibility = Visibility.Visible;
        }

        #region Manager Catalogue
        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime effectiveDate = dateCataEffective.SelectedDate.Value;
                DateTime efpiryDate = dateCataExpiry.SelectedDate.Value;
                int? id = Controller.Implementation.CatalogueImp.Insert(tbCataCountry.Text, tbCataCategory.Text, tbCataItemDescrip.Text, int.Parse(tbCataUnitPrice.Text), int.Parse(tbCataRefPrice.Text), tbCataCurrency.Text, effectiveDate, efpiryDate, tbCataCode.Text, tbCataSubCate.Text, tbCataSuplierCode.Text, tbCataSuplierName.Text, cbItemGroup.Text, tbCataMoreDescrip.Text, tbCataPartNumber.Text, tbCataUOM.Text, tbCataRemark.Text, tbCataGLCode.Text, tbCataHACAT.Text);

                if (id != null)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SetDisplayData(Catalogue _curCata)
        {
            _dataCata = _curCata;
            tbCataCountry.Text = _dataCata.Country;
            tbCataCategory.Text = _dataCata.Category;
            tbCataItemDescrip.Text = _dataCata.ItemDescription;
            tbCataUnitPrice.Text = _dataCata.UnitPrice.ToString();
            tbCataRefPrice.Text = _dataCata.ReferencePrice.ToString();
            tbCataCurrency.Text = _dataCata.Currency;
            dateCataEffective.SelectedDate = (DateTime)_dataCata.EffectiveDate;
            dateCataExpiry.SelectedDate = (DateTime)_dataCata.ExpiryDate;
            tbCataCode.Text = _dataCata.Code;
            tbCataSubCate.Text = _dataCata.SubCategory;
            tbCataSuplierCode.Text = _dataCata.SupplierCode;
            tbCataSuplierName.Text = _dataCata.SupplierName;
            Utilities.SelectCombobox(cbItemGroup, _dataCata.ItemGroup);
            tbCataMoreDescrip.Text = _dataCata.MoreDescription;
            tbCataPartNumber.Text = _dataCata.PartNumber;
            tbCataUOM.Text = _dataCata.UOM;
            tbCataRemark.Text = _dataCata.Remark;
            tbCataGLCode.Text = _dataCata.GLCode;
            tbCataHACAT.Text = _dataCata.HACAT;
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime effectiveDate = dateCataEffective.SelectedDate.Value;
                DateTime efpiryDate = dateCataExpiry.SelectedDate.Value;
                int _idCata = _dataCata.Id;
                
                if (CatalogueImp.Update(_idCata, tbCataCountry.Text, tbCataCategory.Text, tbCataItemDescrip.Text, int.Parse(tbCataUnitPrice.Text), int.Parse(tbCataRefPrice.Text), tbCataCurrency.Text, effectiveDate, efpiryDate, tbCataCode.Text, tbCataSubCate.Text, tbCataSuplierCode.Text, tbCataSuplierName.Text, cbItemGroup.Text, tbCataMoreDescrip.Text, tbCataPartNumber.Text, tbCataUOM.Text, tbCataRemark.Text, tbCataGLCode.Text, tbCataHACAT.Text))
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbCataId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbCataCode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbCataCountry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbCataCategory_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbCataSubCate_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbCataSuplierCode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbCataSuplierName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbCataItemGroup_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbCataItemDescrip_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbCataMoreDescrip_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbCataPartNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbCataUOM_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbCataUnitPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbCataRefPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbCataRemark_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbCataGLCode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbCataHACAT_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbCataCurrency_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        #endregion Manager Catalogue

        public void SetDefaultValue()
        {
            cbItemGroup.Items.Clear();
            cbItemGroup.Items.Add(CommonConstants.ITEMGROUP_KHAOSAT);
            cbItemGroup.Items.Add(CommonConstants.ITEMGROUP_VANCHUYEN);
            cbItemGroup.Items.Add(CommonConstants.ITEMGROUP_HANGMUCTHICONG);
            cbItemGroup.Items.Add(CommonConstants.ITEMGROUP_LAPDAT);
            cbItemGroup.Items.Add(CommonConstants.ITEMGROUP_XINPHEP);
            cbItemGroup.Items.Add(CommonConstants.ITEMGROUP_HANGMUCKHAC);
            cbItemGroup.SelectedIndex = 0;

            dateCataEffective.SelectedDate = DateTime.Now;
            dateCataExpiry.SelectedDate = DateTime.Now;
        }
    }
}
