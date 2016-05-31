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

namespace QuanLyDonHang
{
    /// <summary>
    /// Interaction logic for AddNhaThuocUC.xaml
    /// </summary>
    public partial class AddNhaThuocUC : UserControl
    {
        private ManagerWD _managerWD;
        private NhaThuoc _nhathuocData;
        public AddNhaThuocUC()
        {
            InitializeComponent();
        }
        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            _managerWD = (ManagerWD)Window.GetWindow(this);
            TabControl _tabData = (TabControl)Utilities.FindChildControl<TabControl>(_managerWD);
            InputNhaThuoc _inputNhaThuoc = new InputNhaThuoc();
            TabItem _tabItemNhaThuoc = _tabData.Items[1] as TabItem;
            _tabItemNhaThuoc.Content = _inputNhaThuoc;
        }

        public void SetTbEditVisible()
        {
            tbAddNhaThuoc.Visibility = Visibility.Collapsed;
            tbEditNhaThuoc.Visibility = Visibility.Visible;
            btUpdateNhaThuoc.Visibility = Visibility.Visible;
        }

        #region Manager NhaThuoc
        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int? id = Controller.Implementation.NhaThuocImp.Insert(tbNTCode.Text, tbNTName.Text, tbNTAddress.Text, tbNTStreet.Text, tbNTDistric.Text, tbNTOther.Text, tbNTWard.Text, tbNTCity.Text, tbNTArea.Text, tbNTZone.Text, tbNTPharmacist.Text, tbNTOwner.Text, tbNTDTB.Text, tbNTDTDD.Text, tbNTInFYLCD.Text, tbNTRL.Text);

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

        public void SetDisplayData(NhaThuoc _curNhaThuoc)
        {
            _nhathuocData = _curNhaThuoc;
            tbNTName.Text = _curNhaThuoc.PharmacyName;
            tbNTCode.Text = _curNhaThuoc.CodeMer;
            tbNTAddress.Text = _curNhaThuoc.Address;
            tbNTStreet.Text = _curNhaThuoc.Street;
            tbNTDistric.Text = _curNhaThuoc.District;
            tbNTOther.Text = _curNhaThuoc.Other;
            tbNTWard.Text = _curNhaThuoc.Ward;
            tbNTCity.Text = _curNhaThuoc.Province;
            tbNTArea.Text = _curNhaThuoc.Area;
            tbNTZone.Text = _curNhaThuoc.Zone;
            tbNTPharmacist.Text = _curNhaThuoc.Pharmacist;
            tbNTOwner.Text = _curNhaThuoc.PharmacyOwner;
            tbNTDTB.Text = _curNhaThuoc.Phone;
            tbNTDTDD.Text = _curNhaThuoc.Cellphone;
            tbNTInFYLCD.Text = _curNhaThuoc.InChargeFYLCD;
            tbNTRL.Text = _curNhaThuoc.RL;
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int _idNhaThuoc = _nhathuocData.Id;
                if (NhaThuocImp.Update(_idNhaThuoc, tbNTCode.Text, tbNTName.Text, tbNTAddress.Text, tbNTStreet.Text, tbNTDistric.Text, tbNTOther.Text, tbNTWard.Text, tbNTCity.Text, tbNTArea.Text, tbNTZone.Text, tbNTPharmacist.Text, tbNTOwner.Text, tbNTDTB.Text, tbNTDTDD.Text, tbNTInFYLCD.Text, tbNTRL.Text))
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbNTId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbNTName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbNTCode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbNTAddress_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbNTStreet_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbNTWard_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbNTDistric_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbNTCity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbNTZone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbNTArea_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbNTOwner_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbNTDTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbNTDTDD_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbNTInFYLCD_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbNTRL_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbNTOther_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbNTPharmacist_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        #endregion Manager NhaThuoc
    }
}
