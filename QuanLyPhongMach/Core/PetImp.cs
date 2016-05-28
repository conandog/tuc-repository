using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Controller.Common;

namespace Core
{
    public class PetImp : Connection
    {
        private static IQueryable<Pet> GetQuery(string text)
        {
            IQueryable<Pet> query;
            query = dbContext.Pets.Where(p => p.Ten.Contains(text) ||
                p.GhiChu.Contains(text)
                );

            return query;
        }

        public static int GetCount(string text = "")
        {
            return GetQuery(text).Count();
        }

        public static List<Pet> GetList(string text = "", int skip = 0, int take = 0)
        {
            if ((skip <= 0 && take <= 0) || (skip < 0 && take > 0) || (skip > 0 && take < 0))
            {
                return GetQuery(text).ToList();
            }

            return GetQuery(text).Skip(skip).Take(take).ToList();
        }

        public static Pet GetById(int id)
        {
            return dbContext.Pets.Where(p => p.Id.Equals(id)).FirstOrDefault<Pet>();
        }

        private static bool Insert(Pet data)
        {
            try
            {
                dbContext.Pets.Add(data);
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
        public static int? Insert(User user, int idGroup, int idKhachHang, string ten,
            string gioiTinh = "Đực", DateTime? DOB = null, string ghiChu = "")
        {
            int? res = null;

            try
            {
                Pet data = new Pet();
                data.Id = 1;
                data.IdGroup = idGroup;
                data.IdKhachHang = idKhachHang;
                data.Ten = ten;
                data.GioiTinh = gioiTinh;
                data.DOB = DOB;
                data.GhiChu = ghiChu;

                data.CreateBy = data.UpdateBy = user.UserName;
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

        public static bool Delete(Pet data, User user)
        {
            try
            {
                if (data != null)
                {
                    Pet objDb = GetById(data.Id);

                    if (objDb != null)
                    {
                        data.UpdateBy = user.UserName;
                        data.UpdateDate = DateTime.Now;

                        objDb.DeleteFlag = true;
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
                            Pet data = GetById(result);

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

        public static bool Update(Pet data, User user)
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

        public static bool Update(User user, int id, object idGroup, object khachHang, string ten,
            string gioiTinh = "Đực", DateTime? DOB = null, string ghiChu = "")
        {
            bool res = false;

            try
            {
                Pet data = GetById(id);

                if (data != null)
                {
                    if (idGroup is int)
                    {
                        data.PetGroup = PetGroupImp.GetById(ConvertUtil.ConvertToInt(idGroup));
                    }
                    else
                    {
                        data.PetGroup = (PetGroup)idGroup;
                    }

                    if (khachHang is int)
                    {
                        data.KhachHang = KhachHangImp.GetById(ConvertUtil.ConvertToInt(khachHang));
                    }
                    else
                    {
                        data.KhachHang = (KhachHang)khachHang;
                    }

                    data.Ten = ten;
                    data.GioiTinh = gioiTinh;
                    data.DOB = DOB;
                    data.GhiChu = ghiChu; ;

                    data.UpdateBy = user.UserName;
                    data.UpdateDate = DateTime.Now;

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
