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
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        public InputWindow()
        {
            InitializeComponent();
        }



        #region Manager User
        private void btUserSave_Click(object sender, RoutedEventArgs e)
        {
            DateTime DOB = dateUserDOB.SelectedDate.Value;
            DateTime ngaycap = dateUserNgayCap.SelectedDate.Value;
            byte[] inVAR = System.Text.Encoding.ASCII.GetBytes(tbUserMa.Text);
            Controller.Implementation.UserImp.Insert(inVAR[0], tbUserHoTen.Text, tbUserUserName.Text, tbUserPass.Text, tbUserGioiTinh.Text, DOB, ngaycap, tbUserMa.Text, tbUserCMND.Text, tbUserNoiCap.Text, tbUserDiaChi.Text, tbUserDTB.Text, tbUserDTDD.Text, tbUserEmail.Text, tbUserGhiChu.Text);
        }
        private void tbUserId_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine("tbUserId_TextChanged: " + tbUserId.Text);
        }
        private void tbUserIdGroup_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine("tbUserIdGroup_TextChanged: " + tbUserIdGroup.Text);
        }
        private void tbUserMa_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine("tbUserIdGroup_TextChanged: " + tbUserMa.Text);
        }
        private void tbUserHoTen_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserPass_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserGioiTinh_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserCMND_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserNoiCap_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserDiaChi_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserDTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserDTDD_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbUserGhiChu_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        #endregion Manager User
        #region Manager NhaThuoc
        private void btPharmacySave_Click(object sender, RoutedEventArgs e)
        {
            Controller.Implementation.NhaThuocImp.Insert(tbNTCode.Text, tbNTName.Text, tbNTAddress.Text, tbNTStreet.Text, tbNTDistric.Text, tbNTOther.Text, tbNTWard.Text, tbNTCity.Text, tbNTArea.Text, tbNTZone.Text, tbNTPharmacist.Text, tbNTOwner.Text, tbNTDTB.Text, tbNTDTDD.Text, tbNTInFYLCD.Text, tbNTRL.Text);
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
        #region Manager Catalogue
        private void btCataSave_Click(object sender, RoutedEventArgs e)
        {
            DateTime effectiveDate = dateCataEffective.SelectedDate.Value;
            DateTime efpiryDate = dateCataExpiry.SelectedDate.Value;
            Controller.Implementation.CatalogueImp.Insert(tbCataCountry.Text, tbCataCategory.Text, tbCataItemDescrip.Text, int.Parse(tbCataUnitPrice.Text), int.Parse(tbCataRefPrice.Text), tbCataCurrency.Text, effectiveDate, efpiryDate, tbCataCode.Text, tbCataSubCate.Text, tbCataSuplierCode.Text, tbCataSuplierName.Text, tbCataItemGroup.Text, tbCataMoreDescrip.Text, tbCataPartNumber.Text, tbCataUOM.Text, tbCataRemark.Text, tbCataGLCode.Text, tbCataHACAT.Text);
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
        #region Manager Master
        private void btMasSave_Click(object sender, RoutedEventArgs e)
        {
            byte[] inVAR = System.Text.Encoding.ASCII.GetBytes(tbMasIdCaLD.Text);
            Controller.Implementation.MasterChiPhiImp.Insert(int.Parse(tbMasIdCaKS.Text), int.Parse(tbMasIdCaVC.Text), int.Parse(tbMasQtyHMTC.Text), int.Parse(tbMasIdCaLD.Text), int.Parse(tbMasIdCaXP.Text), double.Parse(tbMasNgang.Text), double.Parse(tbMasRong.Text), inVAR[0], int.Parse(tbMasIdCaHMK.Text), inVAR[1], tbMasBrand.Text);
        }
        private void tbMasId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbMasIdCaKS_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbMasIdCaVC_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbMasIdCaHMTC_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbMasIdCaLD_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbMasIdCaXP_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbMasNgang_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbMasRong_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbMasQtyHMTC_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbMasIdCaHMK_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbMasQtyHMK_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbMasBrand_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        #endregion Manager Master

        
    }
}
