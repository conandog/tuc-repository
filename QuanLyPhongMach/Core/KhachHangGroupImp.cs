using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Controller.Common;

namespace Core
{
    public class KhachHangGroupImp : Connection
    {
        private static IQueryable<KhachHangGroup> GetQuery(string text)
        {
            IQueryable<KhachHangGroup> query;
            query = dbContext.KhachHangGroups.Where(p => p.Ma.Contains(text)
                || p.Ten.Contains(text)
                );

            return query;
        }

        public static int GetCount(string text = "")
        {
            return GetQuery(text).Count();
        }

        public static List<KhachHangGroup> GetList(string text = "", int skip = 0, int take = 0)
        {
            if ((skip <= 0 && take <= 0) || (skip < 0 && take > 0) || (skip > 0 && take < 0))
            {
                return GetQuery(text).ToList();
            }

            return GetQuery(text).Skip(skip).Take(take).ToList();
        }

        public static KhachHangGroup GetById(int id)
        {
            return dbContext.KhachHangGroups.Where(p => p.Id == id).FirstOrDefault<KhachHangGroup>();
        }

        private static bool Insert(KhachHangGroup data)
        {
            try
            {
                dbContext.KhachHangGroups.Add(data);
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
        public static int? Insert(string ma, string ten, string moTa)
        {
            int? res = null;

            try
            {
                KhachHangGroup data = new KhachHangGroup();
                data.Ma = ma;
                data.Ten = ten;
                data.MoTa = moTa;

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

        public static bool Delete(KhachHangGroup data)
        {
            try
            {
                if (data != null)
                {
                    KhachHangGroup objDb = GetById(data.Id);

                    if (objDb != null)
                    {
                        dbContext.KhachHangGroups.Remove(objDb);
                        dbContext.SaveChanges();

                        return true;
                    }
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
                            KhachHangGroup data = GetById(result);

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

        public static bool Update(KhachHangGroup data)
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

        public static bool Update(int id, string ma, string ten, string moTa)
        {
            bool res = false;

            try
            {
                KhachHangGroup data = GetById(id);

                if (data != null)
                {
                    data.Ma = ma;
                    data.Ten = ten;
                    data.MoTa = moTa;
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
