using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Controller.Common;
using CryptoFunction;

namespace Core
{
    public class UserImp : Connection
    {
        private static IQueryable<User> GetQuery(string text)
        {
            IQueryable<User> query;
            query = dbContext.Users.Where(p => p.Ten.Contains(text) ||
                p.GhiChu.Contains(text)
                );

            return query;
        }

        public static int GetCount(string text = "")
        {
            return GetQuery(text).Count();
        }

        public static List<User> GetList(string text = "", int skip = 0, int take = 0)
        {
            if ((skip <= 0 && take <= 0) || (skip < 0 && take > 0) || (skip > 0 && take < 0))
            {
                return GetQuery(text).ToList();
            }

            return GetQuery(text).Skip(skip).Take(take).ToList();
        }

        public static User GetById(int id)
        {
            return dbContext.Users.Where(p => p.Id.Equals(id)).FirstOrDefault<User>();
        }

        public static User GetByUserName(string userName)
        {
            return dbContext.Users.Where(p => p.UserName.Equals(userName)).FirstOrDefault<User>();
        }

        private static bool Insert(User data)
        {
            try
            {
                dbContext.Users.Add(data);
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
        public static int? Insert(User user, int idGroup, string ten, string userName, string password, string gioiTinh = "Nam",
            DateTime? DOB = null, string CMND = "", DateTime? ngayCap = null, string noiCap = "",
            string diaChi = "", string dienThoai = "", string email = "", string ghiChu = "")
        {
            int? res = null;

            try
            {
                User data = new User();
                data.IdGroup = idGroup;
                data.Ten = ten;
                data.UserName = userName;
                data.Password = Crypto.EncryptText(password);
                data.GioiTinh = gioiTinh;
                data.DOB = DOB;
                data.NgayCap = ngayCap;
                data.CMND = CMND;
                data.NoiCap = noiCap;
                data.DiaChi = diaChi;
                data.DienThoai = dienThoai;
                data.Email = email;
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

        public static bool Delete(User data, User user)
        {
            try
            {
                if (data != null)
                {
                    User objDb = GetById(data.Id);

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
                            User data = GetById(result);

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

        public static bool Update(User data, User user)
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

        public static bool Update(User user, int id, object idGroup, string ten, string userName, string password, string gioiTinh = "Nam",
            DateTime? DOB = null, string CMND = "", DateTime? ngayCap = null, string noiCap = "",
            string diaChi = "", string dienThoai = "", string email = "", string ghiChu = "")
        {
            bool res = false;

            try
            {
                User data = GetById(id);

                if (data != null)
                {
                    if (idGroup is int)
                    {
                        data.UserGroup = UserGroupImp.GetById(ConvertUtil.ConvertToInt(idGroup));
                    }
                    else
                    {
                        data.UserGroup = (UserGroup)idGroup;
                    }

                    data.Ten = ten;
                    data.UserName = userName;
                    data.Password = Crypto.EncryptText(password);
                    data.GioiTinh = gioiTinh;
                    data.DOB = DOB;
                    data.NgayCap = ngayCap;
                    data.CMND = CMND;
                    data.NoiCap = noiCap;
                    data.DiaChi = diaChi;
                    data.DienThoai = dienThoai;
                    data.Email = email;
                    data.GhiChu = ghiChu;

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
