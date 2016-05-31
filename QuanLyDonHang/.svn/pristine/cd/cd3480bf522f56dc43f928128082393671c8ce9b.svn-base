using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Data.Linq.SqlClient;
using System.Data.Common;
using Controller.Common;
using Model;

namespace Controller.Implementation
{
    public class NhaThuocImp : SQLConnection
    {
        private static IQueryable<NhaThuoc> GetQuery(string text)
        {
            var sql = from data in dbContext.NhaThuocs
                      select data;

            if (!string.IsNullOrEmpty(text))
            {
                text = CommonFunction.GetFilterText(text);
                sql = sql.Where(p => SqlMethods.Like(p.PharmacyName, text)
                    );
            }

            sql = sql.Where(p => p.DeleteFlag == false);
            return sql;
        }

        public static int GetCount(string text = "")
        {
            return GetQuery(text).Count();
        }

        public static List<NhaThuoc> GetList(string text = "",
            string sortColumn = "", string sortOrder = CommonConstants.SORT_ASCENDING, int skip = 0, int take = 0)
        {
            string sortSQL = string.Empty;

            switch (sortColumn)
            {
                case "Id":
                    sortSQL += "Id " + sortOrder;
                    break;

                case "CodeMer":
                    sortSQL += "CodeMer " + sortOrder;
                    break;

                default:
                    sortSQL += "PharmacyName " + sortOrder;
                    break;
            }

            var sql = GetQuery(text).OrderBy(sortSQL);

            if ((skip <= 0 && take <= 0) || (skip < 0 && take > 0) || (skip > 0 && take < 0))
            {
                return sql.ToList();
            }

            return sql.Skip(skip).Take(take).ToList();
        }

        public static NhaThuoc GetById(int id)
        {
            return dbContext.NhaThuocs.Where(p => p.Id == id).FirstOrDefault<NhaThuoc>();
        }

        public static NhaThuoc GetByCode(string text)
        {
            return dbContext.NhaThuocs.Where(p => p.CodeMer == text && p.DeleteFlag == false).FirstOrDefault<NhaThuoc>();
        }

        private static bool Insert(NhaThuoc data)
        {
            try
            {
                dbContext.NhaThuocs.InsertOnSubmit(data);
                dbContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert new data
        /// </summary>
        /// <param name="codeMer"></param>
        /// <param name="pharmacyName"></param>
        /// <param name="address"></param>
        /// <param name="street"></param>
        /// <param name="district"></param>
        /// <param name="other"></param>
        /// <param name="ward"></param>
        /// <param name="province"></param>
        /// <param name="area"></param>
        /// <param name="zone"></param>
        /// <param name="pharmacist"></param>
        /// <param name="pharmacyOwner"></param>
        /// <param name="phone"></param>
        /// <param name="cellphone"></param>
        /// <param name="inChargeFYLCD"></param>
        /// <param name="RL"></param>
        /// <returns>Return id of the new data if success</returns>
        public static int? Insert(string codeMer, string pharmacyName, string address, string street, string district,
            string other = "", string ward = "", string province = "", string area = "", string zone = "",
            string pharmacist = "", string pharmacyOwner = "", string phone = "", string cellphone = "",
            string inChargeFYLCD = "", string RL = "")
        {
            int? res = null;

            try
            {
                NhaThuoc data = new NhaThuoc();
                data.CodeMer = codeMer;
                data.PharmacyName = pharmacyName;
                data.Address = address;
                data.Street = street;
                data.District = district;
                data.Other = other;
                data.Ward = ward;
                data.Province = province;
                data.Area = area;
                data.Zone = zone;
                data.Pharmacist = pharmacist;
                data.PharmacyOwner = pharmacyOwner;
                data.Phone = phone;
                data.Cellphone = cellphone;
                data.InChargeFYLCD = inChargeFYLCD;
                data.RL = RL;

                if (Insert(data))
                {
                    res = data.Id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return res;
        }

        public static bool Delete(NhaThuoc data)
        {
            try
            {
                if (data != null)
                {
                    data.DeleteFlag = true;
                    dbContext.SubmitChanges();
                    return true;
                }
            }
            catch
            {

            }

            NewConnection();
            return false;
        }

        public static bool DeleteList(string ids)
        {
            bool isSuccess = true;

            try
            {
                OpenConnection();

                if (!string.IsNullOrEmpty(ids))
                {
                    string[] idArr = ids.Split(new string[] { CommonConstants.DELIMITER_STRING }, StringSplitOptions.RemoveEmptyEntries);
                    int result = 0;

                    foreach (string id in idArr)
                    {
                        if (int.TryParse(id, out result))
                        {
                            NhaThuoc data = GetById(result);

                            if (!Delete(data))
                            {
                                isSuccess = false;
                                break;
                            }
                        }
                        else
                        {
                            isSuccess = false;
                            break;
                        }
                    }
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch
            {
                isSuccess = false;
            }

            CloseConnection(isSuccess);
            return isSuccess;
        }

        private static bool Update(NhaThuoc data)
        {
            try
            {
                if (data != null)
                {
                    dbContext.SubmitChanges();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool Update(int id, string codeMer, string pharmacyName, string address, string street, string district,
            string other = "", string ward = "", string province = "", string area = "", string zone = "",
            string pharmacist = "", string pharmacyOwner = "", string phone = "", string cellphone = "",
            string inChargeFYLCD = "", string RL = "")
        {
            bool res = false;

            try
            {
                NhaThuoc data = GetById(id);

                if (data != null)
                {
                    data.CodeMer = codeMer;
                    data.PharmacyName = pharmacyName;
                    data.Address = address;
                    data.Street = street;
                    data.District = district;
                    data.Other = other;
                    data.Ward = ward;
                    data.Province = province;
                    data.Area = area;
                    data.Zone = zone;
                    data.Pharmacist = pharmacist;
                    data.PharmacyOwner = pharmacyOwner;
                    data.Phone = phone;
                    data.Cellphone = cellphone;
                    data.InChargeFYLCD = inChargeFYLCD;
                    data.RL = RL;

                    res = Update(data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return res;
        }
    }
}
