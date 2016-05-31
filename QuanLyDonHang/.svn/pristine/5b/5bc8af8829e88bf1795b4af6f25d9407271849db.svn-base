using Controller.Implementation;
using QuanLyDonHang.Common;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Text.RegularExpressions;

namespace QuanLyDonHang
{
    /// <summary>
    /// Interaction logic for WindowImportData.xaml
    /// </summary>
    public partial class WindowImportData : Window
    {
        private Common.CommonConstants.DATATYPE dataType;

        public WindowImportData()
        {
            InitializeComponent();
        }

        public void SetDisplayData(Common.CommonConstants.DATATYPE type)
        {
            try
            {
                string path = Controller.Common.File_Function.OpenDialog("Excel", "xlsx");

                if (!String.IsNullOrEmpty(path))
                {
                    Controller.Common.Office_Function.InitWorkBook(path, 1);
                    dgShowInfo.DataContext = Controller.Common.Office_Function.GetTable().DefaultView;
                    dataType = type;
                }
            }
            catch (Exception ex)
            {
                btImport.IsEnabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void btImport_Click(object sender, RoutedEventArgs e)
        {
            switch (dataType)
            {
                case (CommonConstants.DATATYPE.NhaThuoc):
                    ImportNhaThuoc();
                    break;
                case (CommonConstants.DATATYPE.Catalogue):
                    ImportCatalogue();
                    break;
                case (CommonConstants.DATATYPE.Master):
                    ImportHistory();
                    break;
                default:
                    break;

            }
        }

        private void ImportHistory()
        {
            try
            {
                int? idHR = null;
                int? _stt = null;
                string codemer = "";
                string listNhaThuoc = string.Empty;
                bool newFlag = dgShowInfo.Columns.Count == 42 ? true : false;
                int i = newFlag == true ? 1 : 2;
                for (; i < dgShowInfo.Items.Count; i++)
                {
                    DataRowView item = dgShowInfo.Items[i] as DataRowView;
                    string tbCodeMer = item.Row.ItemArray[2].ToString();
                    if (tbCodeMer != "")
                    {
                        int _idNT = 0;
                        Model.NhaThuoc _NhaThuoc = NhaThuocImp.GetByCode(tbCodeMer);
                        if (_NhaThuoc != null)
                        {
                            _idNT = _NhaThuoc.Id;
                        }
                        else
                        {
                            MessageBox.Show(string.Format("không tìm thấy tên nhà thuốc với mã {0}", tbCodeMer), "", MessageBoxButton.OK);
                            continue;
                        }
                        int? _idKS = null, _idVC = null, _idHMTC = null, _idLapDat = null, _idXP = null, _idHMK = null;
                        byte? SLKS = null, SLVC = null;
                        string strKhaoSat = item.Row.ItemArray[10].ToString();
                        List<Model.Catalogue> _lsCata = CatalogueImp.GetList(strKhaoSat, CommonConstants.ITEMGROUP_KHAOSAT, CommonConstants.ITEMDESCRIPTION);
                        if (!string.IsNullOrEmpty(strKhaoSat) && _lsCata.Count > 0)
                        {
                            _idKS = _lsCata[0].Id;
                        }

                        _lsCata.Clear();
                        string strVanChuyen = string.Empty;
                        if (newFlag)
                            strVanChuyen = item.Row.ItemArray[14].ToString();
                        else
                            strVanChuyen = item.Row.ItemArray[12].ToString();
                        _lsCata = CatalogueImp.GetList(strVanChuyen, CommonConstants.ITEMGROUP_VANCHUYEN, CommonConstants.ITEMDESCRIPTION);
                        if (!string.IsNullOrEmpty(strVanChuyen) && _lsCata.Count > 0)
                        {
                            _idVC = _lsCata[0].Id;
                        }

                        _lsCata.Clear();
                        string strHMTC = string.Empty;
                        if (newFlag)
                            strHMTC = item.Row.ItemArray[18].ToString();
                        else
                            strHMTC = item.Row.ItemArray[14].ToString();
                        _lsCata = CatalogueImp.GetList(strHMTC, CommonConstants.ITEMGROUP_HANGMUCTHICONG, CommonConstants.ITEMDESCRIPTION);
                        if (!string.IsNullOrEmpty(strHMTC) && _lsCata.Count > 0)
                        {
                            _idHMTC = _lsCata[0].Id;
                        }

                        _lsCata.Clear();
                        string strLapDat = string.Empty;
                        if (newFlag)
                            strLapDat = item.Row.ItemArray[21].ToString();
                        else
                            strLapDat = item.Row.ItemArray[17].ToString();
                        _lsCata = CatalogueImp.GetList(strLapDat, CommonConstants.ITEMGROUP_LAPDAT, CommonConstants.ITEMDESCRIPTION);
                        if (!string.IsNullOrEmpty(strLapDat) && _lsCata.Count > 0)
                        {
                            _idLapDat = _lsCata[0].Id;
                        }

                        _lsCata.Clear();
                        string strXinPhep = string.Empty;
                        if (newFlag)
                            strXinPhep = item.Row.ItemArray[24].ToString();
                        else
                            strXinPhep = item.Row.ItemArray[20].ToString();
                        _lsCata = CatalogueImp.GetList(strXinPhep, CommonConstants.ITEMGROUP_XINPHEP, CommonConstants.ITEMDESCRIPTION);
                        if (!string.IsNullOrEmpty(strXinPhep) && _lsCata.Count > 0)
                        {
                            _idXP = _lsCata[0].Id;
                        }

                        _lsCata.Clear();
                        string strHMK = string.Empty;
                        if (newFlag)
                            strHMK = item.Row.ItemArray[35].ToString();
                        else
                            strHMK = item.Row.ItemArray[30].ToString();
                        _lsCata = CatalogueImp.GetList(strHMK, CommonConstants.ITEMGROUP_HANGMUCKHAC, CommonConstants.ITEMDESCRIPTION);
                        if (!string.IsNullOrEmpty(strHMK) && _lsCata.Count > 0)
                        {
                            _idHMK = _lsCata[0].Id;
                        }

                        if (codemer != tbCodeMer)
                        {
                            int stt = Controller.Common.ConvertUtil.ConvertToInt(item.Row.ItemArray[0].ToString());

                            if (stt != 0)
                            {
                                _stt = stt;
                            }

                            codemer = tbCodeMer;
                        }
                        string _brand1 = string.Empty;
                        string _brand2 = string.Empty;
                        double? ngang = null;
                        double? rong = null;
                        byte? soLuongHMTC = null;
                        byte? soLuongHMK = null;
                        if (newFlag)
                        {
                            _brand1 = item.Row.ItemArray[31].ToString();
                            _brand2 = item.Row.ItemArray[40].ToString();

                            if (!String.IsNullOrEmpty(item.Row.ItemArray[27].ToString()))
                            {
                                ngang = Controller.Common.ConvertUtil.ConvertToDouble(item.Row.ItemArray[27].ToString());
                            }

                            if (!String.IsNullOrEmpty(item.Row.ItemArray[28].ToString()))
                            {
                                rong = Controller.Common.ConvertUtil.ConvertToDouble(item.Row.ItemArray[28].ToString());
                            }

                            if (!String.IsNullOrEmpty(item.Row.ItemArray[29].ToString()))
                            {
                                soLuongHMTC = Controller.Common.ConvertUtil.ConvertToByte(item.Row.ItemArray[29].ToString());
                            }

                            if (!String.IsNullOrEmpty(item.Row.ItemArray[38].ToString()))
                            {
                                soLuongHMK = Controller.Common.ConvertUtil.ConvertToByte(item.Row.ItemArray[38].ToString());
                            }
                        }
                        else
                        {
                            _brand2 = item.Row.ItemArray[35].ToString();

                            if (!String.IsNullOrEmpty(item.Row.ItemArray[23].ToString()))
                            {
                                ngang = Controller.Common.ConvertUtil.ConvertToDouble(item.Row.ItemArray[23].ToString());
                            }

                            if (!String.IsNullOrEmpty(item.Row.ItemArray[24].ToString()))
                            {
                                rong = Controller.Common.ConvertUtil.ConvertToDouble(item.Row.ItemArray[24].ToString());
                            }

                            if (!String.IsNullOrEmpty(item.Row.ItemArray[25].ToString()))
                            {
                                soLuongHMTC = Controller.Common.ConvertUtil.ConvertToByte(item.Row.ItemArray[25].ToString());
                            }

                            if (!String.IsNullOrEmpty(item.Row.ItemArray[33].ToString()))
                            {
                                soLuongHMK = Controller.Common.ConvertUtil.ConvertToByte(item.Row.ItemArray[33].ToString());
                            }
                        }

                        if (newFlag)
                        {
                            if (!String.IsNullOrEmpty(item.Row.ItemArray[12].ToString()))
                            {
                                SLKS = Controller.Common.ConvertUtil.ConvertToByte(item.Row.ItemArray[12].ToString());
                            }

                            if (!String.IsNullOrEmpty(item.Row.ItemArray[16].ToString()))
                            {
                                SLVC = Controller.Common.ConvertUtil.ConvertToByte(item.Row.ItemArray[16].ToString());
                            }
                        }

                        int? IdMaster = MasterChiPhiImp.Insert(_stt, _idKS, SLKS, _idVC, SLVC, _idHMTC, _idLapDat, _idXP,
                            ngang, rong, soLuongHMTC, _brand1, _idHMK, soLuongHMK, _brand2);

                        int IdUser = UserImp.currentUser.Id;
                        DateTime? _date = null;
                        if (!string.IsNullOrEmpty(item.Row.ItemArray[1].ToString()))
                            Controller.Common.ConvertUtil.ConvertToDatetime(item.Row.ItemArray[1].ToString());
                        idHR = HistoryImp.Insert(IdUser, _idNT, (int)IdMaster, _date);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(listNhaThuoc))
                            listNhaThuoc = item.Row.ItemArray[3].ToString();
                        else if (!string.IsNullOrEmpty(item.Row.ItemArray[3].ToString()))
                            listNhaThuoc = string.Format("{0}; {1}", listNhaThuoc, item.Row.ItemArray[3].ToString());
                        continue;
                    }
                        
                    
                }
                if (!string.IsNullOrEmpty(listNhaThuoc))
                {
                    MessageBox.Show(string.Format("danh sách nhà thuốc không có CodeMer: {0}", listNhaThuoc), "", MessageBoxButton.OK);
                }
                if (idHR != null)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ImportCatalogue()
        {
            try
            {
                int? id = null;
                for (int i = 0; i < dgShowInfo.Items.Count; i++)
                {
                    DataRowView item = dgShowInfo.Items[i] as DataRowView;
                    string tbCataCountry = item.Row.ItemArray[0].ToString();
                    string tbCataCategory = item.Row.ItemArray[1].ToString();
                    string tbCataSubCate = item.Row.ItemArray[2].ToString();
                    string tbCataSuplierCode = item.Row.ItemArray[3].ToString();
                    string tbCataSuplierName = item.Row.ItemArray[4].ToString();
                    string cbItemGroup = String.Empty;
                    string tbCataItemDescrip = item.Row.ItemArray[5].ToString();
                    string tbCataCode = (Regex.Split(tbCataItemDescrip, "_"))[0];
                    string tbCataMoreDescrip = item.Row.ItemArray[6].ToString();
                    string tbCataPartNumber = item.Row.ItemArray[7].ToString();
                    string tbCataUOM = item.Row.ItemArray[8].ToString();
                    string tbCataUnitPrice = item.Row.ItemArray[9].ToString();
                    string tbCataRefPrice = item.Row.ItemArray[10].ToString();
                    string tbCataRemark = item.Row.ItemArray[11].ToString();
                    string tbCataGLCode = item.Row.ItemArray[12].ToString();
                    string tbCataHACAT = item.Row.ItemArray[13].ToString();
                    string tbCataCurrency = item.Row.ItemArray[16].ToString();
                    string effective = item.Row.ItemArray[14].ToString() != "" ? item.Row.ItemArray[14].ToString() : "0";
                    double date = double.Parse(effective);
                    DateTime effectiveDate = DateTime.FromOADate(date);
                    string efpiry = item.Row.ItemArray[15].ToString() != "" ? item.Row.ItemArray[15].ToString() : "0";
                    date = double.Parse(efpiry);
                    DateTime efpiryDate = DateTime.FromOADate(date);
                    id = CatalogueImp.Insert(tbCataCountry, tbCataCategory, tbCataItemDescrip, int.Parse(tbCataUnitPrice), int.Parse(tbCataRefPrice), tbCataCurrency, effectiveDate, efpiryDate, tbCataCode, tbCataSubCate, tbCataSuplierCode, tbCataSuplierName, cbItemGroup, tbCataMoreDescrip, tbCataPartNumber, tbCataUOM, tbCataRemark, tbCataGLCode, tbCataHACAT);
                }

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

        private void ImportNhaThuoc()
        {
            try
            {
                int? id = null;
                for (int i = 0; i < dgShowInfo.Items.Count; i++)
                {
                    DataRowView item = dgShowInfo.Items[i] as DataRowView;
                    string tbNTCode = item.Row.ItemArray[0].ToString();
                    string tbNTName = item.Row.ItemArray[1].ToString();
                    string tbNTAddress  = item.Row.ItemArray[2].ToString();
                    string tbNTStreet = item.Row.ItemArray[3].ToString();
                    string tbNTOther = item.Row.ItemArray[4].ToString();
                    string tbNTWard = item.Row.ItemArray[5].ToString();
                    string tbNTDistric = item.Row.ItemArray[6].ToString();
                    string tbNTCity  = item.Row.ItemArray[7].ToString();
                    string tbNTArea  = item.Row.ItemArray[8].ToString();
                    string tbNTZone  = item.Row.ItemArray[9].ToString();
                    string tbNTPharmacist  = item.Row.ItemArray[10].ToString();
                    string tbNTOwner = item.Row.ItemArray[11].ToString();
                    string tbNTDTB = item.Row.ItemArray[12].ToString();
                    string tbNTDTDD  = item.Row.ItemArray[13].ToString();
                    string tbNTInFYLCD  = item.Row.ItemArray[14].ToString();
                    string tbNTRL = item.Row.ItemArray[15].ToString();
                    id = NhaThuocImp.Insert(tbNTCode, tbNTName, tbNTAddress, tbNTStreet, tbNTDistric, tbNTOther, tbNTWard, tbNTCity, tbNTArea, tbNTZone, tbNTPharmacist, tbNTOwner, tbNTDTB, tbNTDTDD, tbNTInFYLCD, tbNTRL);
                }

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

        private void WindowImportData1_Closed(object sender, EventArgs e)
        {   
        }
    }
}
