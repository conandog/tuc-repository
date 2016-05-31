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
using Controller.Implementation;
using QuanLyDonHang.Common;
using Model;

namespace QuanLyDonHang
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PriceWindow : Window
    {

        public PriceWindow()
        {
            InitializeComponent();
        }

        private void ChiTietGiaCaWD_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataKhaoSat();
            LoadDataVanChuyen();
            LoadDataThiCong();
            LoadDataLapDat();
            LoadDataXinPhep();
            LoadDataMucKhac();
        }

        # region combo_KhaoSat

        private void cbKhaoSat_Loaded(object sender, RoutedEventArgs e)
        {
            
            //// ... A List KhaoSat
            //List<KhaoSat> khaosat = new List<KhaoSat>();
            //khaosat.Add(new KhaoSat(20000, "TPHCM"));
            //khaosat.Add(new KhaoSat(30000, "CanTho"));
            //khaosat.Add(new KhaoSat(40000, "DongNai"));
            //khaosat.Add(new KhaoSat(50000, "BinhDuong"));


            //// ... Get the ComboBox reference.
            //var comboBox = sender as ComboBox;

            //// ... Assign the ItemsSource to the List.
            //comboBox.ItemsSource = khaosat;
            //comboBox.DisplayMemberPath = "noiKhaoSat";
            //comboBox.SelectedValuePath = "tienKhaoSat";
            //// ... Make the first item selected.
            //comboBox.SelectedIndex = 0;
        }

        private void cbKhaoSat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbKhaoSat.SelectedItem != null)
                {
                    Catalogue data = ((CommonComboBoxItem)cbKhaoSat.SelectedItem).Value as Catalogue;
                    tbTienKhaoSat.Text = data.UnitPrice.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }
        }

        private void LoadDataKhaoSat()
        {
            /*try
            {
                List<Catalogue> listData = CatalogueImp.GetList(String.Empty, CommonConstants.ITEMGROUP_KHAOSAT, String.Empty, String.Empty, 0, 0);

                foreach (Catalogue data in listData)
                {
                    cbKhaoSat.Items.Add(new CommonComboBoxItem(data.ItemDescription, data)); //get all data or just get unit price
                }

                if (cbKhaoSat.Items.Count > 0)
                {
                    cbKhaoSat.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }*/
            LoadData(cbKhaoSat, CommonConstants.ITEMGROUP_KHAOSAT);
        }

        #endregion combo_KhaoSat

        # region combo_VanChuyen

        private void cbVanChuyen_Loaded(object sender, RoutedEventArgs e)
        {

            //// ... A List KhaoSat
            //List<KhaoSat> khaosat = new List<KhaoSat>();
            //khaosat.Add(new KhaoSat(20000, "TPHCM"));
            //khaosat.Add(new KhaoSat(30000, "CanTho"));
            //khaosat.Add(new KhaoSat(40000, "DongNai"));
            //khaosat.Add(new KhaoSat(50000, "BinhDuong"));


            //// ... Get the ComboBox reference.
            //var comboBox = sender as ComboBox;

            //// ... Assign the ItemsSource to the List.
            //comboBox.ItemsSource = khaosat;
            //comboBox.DisplayMemberPath = "noiKhaoSat";
            //comboBox.SelectedValuePath = "tienKhaoSat";
            //// ... Make the first item selected.
            //comboBox.SelectedIndex = 0;
        }

        private void cbVanChuyen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbVanChuyen.SelectedItem != null)
                {
                    Catalogue data = ((CommonComboBoxItem)cbVanChuyen.SelectedItem).Value as Catalogue;
                    tbTienVanChuyen.Text = data.UnitPrice.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }
        }

        private void LoadDataVanChuyen()
        {
            /*try
            {
                List<Catalogue> listData = CatalogueImp.GetList(String.Empty, CommonConstants.ITEMGROUP_VANCHUYEN, String.Empty, String.Empty, 0, 0);

                foreach (Catalogue data in listData)
                {
                    cbVanChuyen.Items.Add(new CommonComboBoxItem(data.ItemDescription, data)); //get all data or just get unit price
                }

                if (cbVanChuyen.Items.Count > 0)
                {
                    cbVanChuyen.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }*/
            LoadData(cbVanChuyen, CommonConstants.ITEMGROUP_VANCHUYEN);
        }

        #endregion combo_VanChuyen

        # region combo_ThiCong

        private void cbThiCong_Loaded(object sender, RoutedEventArgs e)
        {

            //// ... A List KhaoSat
            //List<KhaoSat> khaosat = new List<KhaoSat>();
            //khaosat.Add(new KhaoSat(20000, "TPHCM"));
            //khaosat.Add(new KhaoSat(30000, "CanTho"));
            //khaosat.Add(new KhaoSat(40000, "DongNai"));
            //khaosat.Add(new KhaoSat(50000, "BinhDuong"));


            //// ... Get the ComboBox reference.
            //var comboBox = sender as ComboBox;

            //// ... Assign the ItemsSource to the List.
            //comboBox.ItemsSource = khaosat;
            //comboBox.DisplayMemberPath = "noiKhaoSat";
            //comboBox.SelectedValuePath = "tienKhaoSat";
            //// ... Make the first item selected.
            //comboBox.SelectedIndex = 0;
        }

        private void cbThiCong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbThiCong.SelectedItem != null)
                {
                    Catalogue data = ((CommonComboBoxItem)cbThiCong.SelectedItem).Value as Catalogue;
                    tbTienThiCong.Text = data.UnitPrice.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }
        }

        private void LoadDataThiCong()
        {
            /*try
            {
                List<Catalogue> listData = CatalogueImp.GetList(String.Empty, CommonConstants.ITEMGROUP_HANGMUCTHICONG, String.Empty, String.Empty, 0, 0);

                foreach (Catalogue data in listData)
                {
                    cbThiCong.Items.Add(new CommonComboBoxItem(data.ItemDescription, data)); //get all data or just get unit price
                }

                if (cbThiCong.Items.Count > 0)
                {
                    cbThiCong.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }*/
            LoadData(cbThiCong, CommonConstants.ITEMGROUP_HANGMUCTHICONG);
        }

        #endregion combo_ThiCong

        # region combo_LapDat

        private void cbLapDat_Loaded(object sender, RoutedEventArgs e)
        {

            //// ... A List KhaoSat
            //List<KhaoSat> khaosat = new List<KhaoSat>();
            //khaosat.Add(new KhaoSat(20000, "TPHCM"));
            //khaosat.Add(new KhaoSat(30000, "CanTho"));
            //khaosat.Add(new KhaoSat(40000, "DongNai"));
            //khaosat.Add(new KhaoSat(50000, "BinhDuong"));


            //// ... Get the ComboBox reference.
            //var comboBox = sender as ComboBox;

            //// ... Assign the ItemsSource to the List.
            //comboBox.ItemsSource = khaosat;
            //comboBox.DisplayMemberPath = "noiKhaoSat";
            //comboBox.SelectedValuePath = "tienKhaoSat";
            //// ... Make the first item selected.
            //comboBox.SelectedIndex = 0;
        }

        private void cbLapDat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbLapDat.SelectedItem != null)
                {
                    Catalogue data = ((CommonComboBoxItem)cbLapDat.SelectedItem).Value as Catalogue;
                    tbTienLapDat.Text = data.UnitPrice.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }
        }

        private void LoadDataLapDat()
        {
            /*try
            {
                List<Catalogue> listData = CatalogueImp.GetList(String.Empty, CommonConstants.ITEMGROUP_LAPDAT, String.Empty, String.Empty, 0, 0);

                foreach (Catalogue data in listData)
                {
                    cbLapDat.Items.Add(new CommonComboBoxItem(data.ItemDescription, data)); //get all data or just get unit price
                }

                if (cbLapDat.Items.Count > 0)
                {
                    cbLapDat.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }*/
            LoadData(cbLapDat, CommonConstants.ITEMGROUP_LAPDAT);
        }

        #endregion combo_LapDat

        # region combo_XinPhep

        private void cbXinPhep_Loaded(object sender, RoutedEventArgs e)
        {

            //// ... A List KhaoSat
            //List<KhaoSat> khaosat = new List<KhaoSat>();
            //khaosat.Add(new KhaoSat(20000, "TPHCM"));
            //khaosat.Add(new KhaoSat(30000, "CanTho"));
            //khaosat.Add(new KhaoSat(40000, "DongNai"));
            //khaosat.Add(new KhaoSat(50000, "BinhDuong"));


            //// ... Get the ComboBox reference.
            //var comboBox = sender as ComboBox;

            //// ... Assign the ItemsSource to the List.
            //comboBox.ItemsSource = khaosat;
            //comboBox.DisplayMemberPath = "noiKhaoSat";
            //comboBox.SelectedValuePath = "tienKhaoSat";
            //// ... Make the first item selected.
            //comboBox.SelectedIndex = 0;
        }

        private void cbXinPhep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbXinPhep.SelectedItem != null)
                {
                    Catalogue data = ((CommonComboBoxItem)cbXinPhep.SelectedItem).Value as Catalogue;
                    tbTienXinPhep.Text = data.UnitPrice.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }
        }

        private void LoadDataXinPhep()
        {
            /*try
            {
                List<Catalogue> listData = CatalogueImp.GetList(String.Empty, CommonConstants.ITEMGROUP_XINPHEP, String.Empty, String.Empty, 0, 0);

                foreach (Catalogue data in listData)
                {
                    cbXinPhep.Items.Add(new CommonComboBoxItem(data.ItemDescription, data)); //get all data or just get unit price
                }

                if (cbXinPhep.Items.Count > 0)
                {
                    cbXinPhep.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }*/
            LoadData(cbXinPhep, CommonConstants.ITEMGROUP_XINPHEP);
        }

        #endregion combo_XinPhep

        # region combo_MucKhac

        private void cbMucKhac_Loaded(object sender, RoutedEventArgs e)
        {

            //// ... A List KhaoSat
            //List<KhaoSat> khaosat = new List<KhaoSat>();
            //khaosat.Add(new KhaoSat(20000, "TPHCM"));
            //khaosat.Add(new KhaoSat(30000, "CanTho"));
            //khaosat.Add(new KhaoSat(40000, "DongNai"));
            //khaosat.Add(new KhaoSat(50000, "BinhDuong"));


            //// ... Get the ComboBox reference.
            //var comboBox = sender as ComboBox;

            //// ... Assign the ItemsSource to the List.
            //comboBox.ItemsSource = khaosat;
            //comboBox.DisplayMemberPath = "noiKhaoSat";
            //comboBox.SelectedValuePath = "tienKhaoSat";
            //// ... Make the first item selected.
            //comboBox.SelectedIndex = 0;
        }

        private void cbMucKhac_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbMucKhac.SelectedItem != null)
                {
                    Catalogue data = ((CommonComboBoxItem)cbMucKhac.SelectedItem).Value as Catalogue;
                    tbTienKhaoSat.Text = data.UnitPrice.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }
        }

        private void LoadDataMucKhac()
        {
            /*try
            {
                List<Catalogue> listData = CatalogueImp.GetList(String.Empty, CommonConstants.ITEMGROUP_HANGMUCKHAC, String.Empty, String.Empty, 0, 0);

                foreach (Catalogue data in listData)
                {
                    cbMucKhac.Items.Add(new CommonComboBoxItem(data.ItemDescription, data)); //get all data or just get unit price
                }

                if (cbMucKhac.Items.Count > 0)
                {
                    cbMucKhac.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }*/
            LoadData(cbMucKhac, CommonConstants.ITEMGROUP_HANGMUCKHAC);
        }

        #endregion combo_MucKhac

        private void LoadData(ComboBox combo, string itemgroup)
        {
            try
            {
                List<Catalogue> listData = CatalogueImp.GetList(String.Empty, itemgroup, String.Empty, String.Empty, 0, 0);

                foreach (Catalogue data in listData)
                {
                    combo.Items.Add(new CommonComboBoxItem(data.ItemDescription, data)); //get all data or just get unit price
                }

                if (combo.Items.Count > 0)
                {
                    combo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //log
            }
        }
    }
}
