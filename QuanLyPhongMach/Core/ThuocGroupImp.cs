using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Controller.Common;

namespace Core
{
    public class ThuocGroupImp : Connection
    {
        private static IQueryable<ThuocGroup> GetQuery(string text)
        {
            IQueryable<ThuocGroup> query;
            query = dbContext.ThuocGroups.Where(p => p.Ma.Contains(text) ||
                p.Ten.Contains(text)
                );

            return query;
        }

        public static int GetCount(string text = "")
        {
            return GetQuery(text).Count();
        }

        public static List<ThuocGroup> GetList(string text = "", int skip = 0, int take = 0)
        {
            if ((skip <= 0 && take <= 0) || (skip < 0 && take > 0) || (skip > 0 && take < 0))
            {
                return GetQuery(text).ToList();
            }

            return GetQuery(text).Skip(skip).Take(take).ToList();
        }

        public static ThuocGroup GetById(int id)
        {
            return dbContext.ThuocGroups.Where(p => p.Id == id).FirstOrDefault<ThuocGroup>();
        }

        private static bool Insert(ThuocGroup data)
        {
            try
            {
                dbContext.ThuocGroups.Add(data);
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
        public static int? Insert(User user, string ma, string ten)
        {
            int? res = null;

            try
            {
                ThuocGroup data = new ThuocGroup();
                data.Ma = ma;
                data.Ten = ten;

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

        public static bool Delete(ThuocGroup data, User user)
        {
            try
            {
                if (data != null)
                {
                    ThuocGroup objDb = GetById(data.Id);

                    if (objDb != null)
                    {
                        dbContext.ThuocGroups.Remove(objDb);
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

        public static bool DeleteList(string ids, User user)
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
                            ThuocGroup data = GetById(result);

                            if (!Delete(data, user))
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

        public static bool Update(ThuocGroup data, User user)
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

        public static bool Update(User user, int id, string ma, string ten)
        {
            bool res = false;

            try
            {
                ThuocGroup data = GetById(id);

                if (data != null)
                {
                    data.Ma = ma;
                    data.Ten = ten;
                    res = Update(data, user);
                }
            }
            catch
            {
                
            }

            return res;
        }
    }
}
