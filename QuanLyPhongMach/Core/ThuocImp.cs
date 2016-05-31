using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Controller.Common;

namespace Core
{
    public class ThuocImp : Connection
    {
        private static IQueryable<Thuoc> GetQuery(string text, bool? deleteFlag = false)
        {
            IQueryable<Thuoc> query;
            query = dbContext.Thuocs.Where(p => p.Ma.Contains(text) ||
                p.Ten.Contains(text)
                );

            if (deleteFlag != null)
            {
                query = query.Where(p => p.DeleteFlag == deleteFlag);
            }

            return query;
        }

        public static int GetCount(string text = "", bool? deleteFlag = false)
        {
            return GetQuery(text, deleteFlag).Count();
        }

        public static List<Thuoc> GetList(string text = "", bool? deleteFlag = false, int skip = 0, int take = 0)
        {
            if ((skip <= 0 && take <= 0) || (skip < 0 && take > 0) || (skip > 0 && take < 0))
            {
                return GetQuery(text, deleteFlag).ToList();
            }

            return GetQuery(text, deleteFlag).Skip(skip).Take(take).ToList();
        }

        public static Thuoc GetById(int id)
        {
            return dbContext.Thuocs.Where(p => p.Id.Equals(id)).FirstOrDefault<Thuoc>();
        }

        public static Thuoc GetByMa(string ma)
        {
            return dbContext.Thuocs.Where(p => p.Ma.Equals(ma)).FirstOrDefault<Thuoc>();
        }

        private static bool Insert(Thuoc data)
        {
            try
            {
                dbContext.Thuocs.Add(data);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Insert new data
        /// </summary>
        /// <param name="ten"></param>
        /// <param name="ghiChu"></param>
        /// <returns>Return id of the new data if success</returns>
        public static int? Insert(int idGroup, string ma, string ten,
            string donViTinh = "cc", string moTa = "")
        {
            int? res = null;

            try
            {
                Thuoc data = new Thuoc();
                data.IdGroup = idGroup;
                data.Ma = ma;
                data.Ten = ten;
                data.DonViTinh = donViTinh;
                data.MoTa = moTa;

                data.CreateBy = data.UpdateBy = CurrentUser.UserName;
                data.CreateDate = data.UpdateDate = DateTime.Now;

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

        public static bool Delete(Thuoc data)
        {
            try
            {
                if (data != null)
                {
                    data.UpdateBy = CurrentUser.UserName;
                    data.UpdateDate = DateTime.Now;
                    data.DeleteFlag = true;
                    dbContext.SaveChanges();

                    return true;
                }
            }
            catch
            {

            }

            //NewConnection();
            return false;
        }

        public static bool DeleteList(string ids)
        {
            bool res = true;

            try
            {
                BeginTransaction();

                if (!string.IsNullOrEmpty(ids))
                {
                    string[] idArr = ids.Split(new string[] { CommonConstants.DELIMITER_STRING }, StringSplitOptions.RemoveEmptyEntries);
                    int result = 0;

                    foreach (string id in idArr)
                    {
                        if (int.TryParse(id, out result))
                        {
                            Thuoc data = GetById(result);

                            if (!Delete(data))
                            {
                                res = false;
                                break;
                            }
                        }
                        else
                        {
                            res = false;
                            break;
                        }
                    }
                }
                else
                {
                    res = false;
                }
            }
            catch
            {
                res = false;
            }
            finally
            {
                EndTransaction(res);
            }

            return res;
        }

        public static bool Update(Thuoc data)
        {
            try
            {
                if (data != null)
                {
                    dbContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool Update(int id, object group, string ma, string ten,
            string donViTinh = "cc", string moTa = "")
        {
            bool res = false;

            try
            {
                Thuoc data = GetById(id);

                if (data != null)
                {
                    if (group is int)
                    {
                        data.ThuocGroup = ThuocGroupImp.GetById(ConvertUtil.ConvertToInt(group));
                    }
                    else
                    {
                        data.ThuocGroup = (ThuocGroup)group;
                    }

                    data.Ma = ma;
                    data.Ten = ten;
                    data.DonViTinh = donViTinh;
                    data.MoTa = moTa;

                    data.UpdateBy = CurrentUser.UserName;
                    data.UpdateDate = DateTime.Now;

                    res = Update(data);
                }
            }
            catch
            {

            }

            return res;
        }
    }
}
