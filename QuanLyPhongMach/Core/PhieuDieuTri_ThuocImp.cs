using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Controller.Common;

namespace Core
{
    public class PhieuDieuTri_ThuocImp : Connection
    {
        private static IQueryable<PhieuDieuTri_Thuoc> GetQuery(string text)
        {
            IQueryable<PhieuDieuTri_Thuoc> query;
            query = dbContext.PhieuDieuTri_Thuoc.Where(p => p.Thuoc.Ma.Contains(text)
                || p.Thuoc.Ten.Contains(text)
                );

            return query;
        }

        public static int GetCount(string text = "")
        {
            return GetQuery(text).Count();
        }

        public static List<PhieuDieuTri_Thuoc> GetList(string text = "", int skip = 0, int take = 0)
        {
            if ((skip <= 0 && take <= 0) || (skip < 0 && take > 0) || (skip > 0 && take < 0))
            {
                return GetQuery(text).ToList();
            }

            return GetQuery(text).Skip(skip).Take(take).ToList();
        }

        public static PhieuDieuTri_Thuoc GetById(int id)
        {
            return dbContext.PhieuDieuTri_Thuoc.Where(p => p.Id.Equals(id)).FirstOrDefault<PhieuDieuTri_Thuoc>();
        }

        private static bool Insert(PhieuDieuTri_Thuoc data)
        {
            try
            {
                dbContext.PhieuDieuTri_Thuoc.Add(data);
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
        public static int? Insert(int idPhieuDieuTri, int idThuoc, string duongCap, double lieuLuong)
        {
            int? res = null;

            try
            {
                PhieuDieuTri_Thuoc data = new PhieuDieuTri_Thuoc();
                data.IdPhieuDieuTri = idPhieuDieuTri;
                data.IdThuoc = idThuoc;
                data.DuongCap = duongCap;
                data.LieuLuong = lieuLuong;

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

        public static bool Delete(PhieuDieuTri_Thuoc data)
        {
            try
            {
                if (data != null)
                {
                    dbContext.PhieuDieuTri_Thuoc.Remove(data);
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
                            PhieuDieuTri_Thuoc data = GetById(result);

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

        public static bool Update(PhieuDieuTri_Thuoc data)
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

        public static bool Update(int id, object phieuDieuTri, object thuoc, string duongCap, double lieuLuong)
        {
            bool res = false;

            try
            {
                PhieuDieuTri_Thuoc data = GetById(id);

                if (data != null)
                {
                    if (phieuDieuTri is int)
                    {
                        data.PhieuDieuTri = PhieuDieuTriImp.GetById(ConvertUtil.ConvertToInt(phieuDieuTri));
                    }
                    else
                    {
                        data.PhieuDieuTri = phieuDieuTri as PhieuDieuTri;
                    }

                    if (thuoc is int)
                    {
                        data.Thuoc = ThuocImp.GetById(ConvertUtil.ConvertToInt(thuoc));
                    }
                    else
                    {
                        data.Thuoc = thuoc as Thuoc;
                    }

                    data.DuongCap = duongCap;
                    data.LieuLuong = lieuLuong;

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
