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
    public class CatalogueImp : SQLConnection
    {
        private static IQueryable<Catalogue> GetQuery(string text, string itemGroup)
        {
            var sql = from data in dbContext.Catalogues
                      select data;

            if (!String.IsNullOrEmpty(text))
            {
                text = CommonFunction.GetFilterText(text);
                sql = sql.Where(p => SqlMethods.Like(p.ItemDescription, text) ||
                    SqlMethods.Like(p.MoreDescription, text)
                    );
            }

            if (!String.IsNullOrEmpty(itemGroup))
            {
                sql = sql.Where(p => p.ItemGroup.ToLower() == itemGroup.ToLower());
            }

            sql = sql.Where(p => p.DeleteFlag == false);
            return sql;
        }

        public static int GetCount(string text = "", string itemGroup = "")
        {
            return GetQuery(text, itemGroup).Count();
        }

        public static List<Catalogue> GetList(string text = "", string itemGroup = "",
            string sortColumn = "", string sortOrder = CommonConstants.SORT_ASCENDING, int skip = 0, int take = 0)
        {
            string sortSQL = string.Empty;

            switch (sortColumn.Trim().ToLower())
            {
                case "id":
                    sortSQL += "Id " + sortOrder;
                    break;

                case "itemgroup":
                    sortSQL += "ItemGroup " + sortOrder;
                    break;
                    
                case "itemdescription":
                    sortSQL += "ItemDescription " + sortOrder;
                    break;

                case "moredescription":
                    sortSQL += "MoreDescription " + sortOrder;
                    break;

                default:
                    sortSQL += "Id " + sortOrder;
                    break;
            }

            var sql = GetQuery(text, itemGroup).OrderBy(sortSQL);

            if ((skip <= 0 && take <= 0) || (skip < 0 && take > 0) || (skip > 0 && take < 0))
            {
                return sql.ToList();
            }

            return sql.Skip(skip).Take(take).ToList();
        }

        public static Catalogue GetById(int id)
        {
            return dbContext.Catalogues.Where(p => p.Id == id).FirstOrDefault<Catalogue>();
        }

        public static Catalogue GetByCode(string text)
        {
            return dbContext.Catalogues.Where(p => p.Code == text && p.DeleteFlag == false).FirstOrDefault<Catalogue>();
        }

        private static bool Insert(Catalogue data)
        {
            try
            {
                dbContext.Catalogues.InsertOnSubmit(data);
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
        /// <param name="country"></param>
        /// <param name="category"></param>
        /// <param name="itemDescription"></param>
        /// <param name="unitPrice"></param>
        /// <param name="referencePrice"></param>
        /// <param name="currency"></param>
        /// <param name="effectiveDate"></param>
        /// <param name="expiryDate"></param>
        /// <param name="code"></param>
        /// <param name="subCategory"></param>
        /// <param name="supplierCode"></param>
        /// <param name="supplierName"></param>
        /// <param name="itemGroup"></param>
        /// <param name="moreDescription"></param>
        /// <param name="partNumber"></param>
        /// <param name="UOM"></param>
        /// <param name="remark"></param>
        /// <param name="GLCode"></param>
        /// <param name="HACAT"></param>
        /// <returns>Return id of the new data if success</returns>
        public static int? Insert(string country, string category, string itemDescription, int unitPrice, int referencePrice, string currency,
            DateTime effectiveDate, DateTime expiryDate, string code = "", string subCategory = "", string supplierCode = "", string supplierName = "",
            string itemGroup = "", string moreDescription = "", string partNumber = "", string UOM = "", string remark = "",
            string GLCode = "", string HACAT = "")
        {
            int? res = null;

            try
            {
                Catalogue data = new Catalogue();
                data.Country = country;
                data.Category = category;
                data.ItemDescription = itemDescription;
                data.UnitPrice = unitPrice;
                data.ReferencePrice = referencePrice;
                data.Currency = currency;
                data.EffectiveDate = effectiveDate == null ? DateTime.Now : effectiveDate;
                data.ExpiryDate = expiryDate == null ? DateTime.Now.AddMonths(1) : expiryDate;
                data.Code = code;
                data.SubCategory = subCategory;
                data.SupplierCode = supplierCode;
                data.SupplierName = supplierName;
                data.ItemGroup = itemGroup;
                data.MoreDescription = moreDescription;
                data.PartNumber = partNumber;
                data.UOM = UOM;
                data.Remark = remark;
                data.GLCode = GLCode;
                data.HACAT = HACAT;

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

        public static bool Delete(Catalogue data)
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
                            Catalogue data = GetById(result);

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

        private static bool Update(Catalogue data)
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

        public static bool Update(int id, string country, string category, string itemDescription, int unitPrice, int referencePrice, string currency,
            DateTime effectiveDate, DateTime expiryDate, string code = "", string subCategory = "", string supplierCode = "", string supplierName = "",
            string itemGroup = "", string moreDescription = "", string partNumber = "", string UOM = "", string remark = "",
            string GLCode = "", string HACAT = "")
        {
            bool res = false;

            try
            {
                Catalogue data = GetById(id);

                if (data != null)
                {
                    data.Country = country == null ? String.Empty : country;
                    data.Category = category == null ? String.Empty : category;
                    data.ItemDescription = itemDescription == null ? String.Empty : itemDescription;
                    data.UnitPrice = unitPrice;
                    data.ReferencePrice = referencePrice;
                    data.Currency = currency == null ? String.Empty : currency;
                    data.EffectiveDate = effectiveDate == null ? DateTime.Now : effectiveDate;
                    data.ExpiryDate = expiryDate == null ? DateTime.Now.AddMonths(1) : expiryDate;

                    data.Code = code;
                    data.SubCategory = subCategory;
                    data.SupplierCode = supplierCode;
                    data.SupplierName = supplierName;
                    data.ItemGroup = itemGroup;
                    data.MoreDescription = moreDescription;
                    data.PartNumber = partNumber;
                    data.UOM = UOM;
                    data.Remark = remark;
                    data.GLCode = GLCode;
                    data.HACAT = HACAT;

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
