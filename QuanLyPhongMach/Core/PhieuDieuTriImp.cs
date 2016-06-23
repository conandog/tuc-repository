using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Controller.Common;

namespace Core
{
    public class PhieuDieuTriImp : Connection
    {
        private static IQueryable<PhieuDieuTri> GetQuery(string text, bool? deleteFlag = false)
        {
            IQueryable<PhieuDieuTri> query;
            query = dbContext.PhieuDieuTris.Where(p => p.Ma.Contains(text)
                || p.Pet.Ten.Contains(text)
                || p.Pet.KhachHang.Ten.Contains(text)
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

        public static List<PhieuDieuTri> GetList(string text = "", bool? deleteFlag = false, int skip = 0, int take = 0)
        {
            if ((skip <= 0 && take <= 0) || (skip < 0 && take > 0) || (skip > 0 && take < 0))
            {
                return GetQuery(text, deleteFlag).ToList();
            }

            return GetQuery(text, deleteFlag).Skip(skip).Take(take).ToList();
        }

        public static PhieuDieuTri GetById(int id)
        {
            return dbContext.PhieuDieuTris.Where(p => p.Id.Equals(id)).FirstOrDefault<PhieuDieuTri>();
        }

        public static PhieuDieuTri GetByMa(string ma)
        {
            return dbContext.PhieuDieuTris.Where(p => p.Ma.Equals(ma)).FirstOrDefault<PhieuDieuTri>();
        }

        public static PhieuDieuTri GetLastByIdPet(int idPet)
        {
            return dbContext.PhieuDieuTris.Where(p => p.IdPet.Equals(idPet)).OrderByDescending(p => p.CreateDate).FirstOrDefault<PhieuDieuTri>();
        }

        private static bool Insert(PhieuDieuTri data)
        {
            try
            {
                dbContext.PhieuDieuTris.Add(data);
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
        public static int? Insert(int idPet, string ma, long tongTien,
            bool isKhamBenh, bool isChich_UongThuoc, bool isTruyenDichTinhMach, string khac = "", string trieuChung = "",
            double? trongLuong = null, string nhietDo = "", string loiDanDo = "")
        {
            int? res = null;

            try
            {
                PhieuDieuTri data = new PhieuDieuTri();
                data.IdPet = idPet;
                data.Ma = String.IsNullOrEmpty(ma) ? (CommonConstants.DEFAULT_PREFIX_CODE_PDT + GetList().LastOrDefault<PhieuDieuTri>().Id.ToString()) : ma;
                data.TrongLuong = trongLuong;
                data.NhietDo = nhietDo;
                data.TrieuChung = trieuChung;
                data.IsKhamBenh = isKhamBenh;
                data.IsChich_UongThuoc = isChich_UongThuoc;
                data.IsKhamBenh = isKhamBenh;
                data.IsTruyenDichTinhMach = isTruyenDichTinhMach;
                data.Khac = khac;
                data.LoiDanDo = loiDanDo;
                data.TongTien = tongTien;

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

        public static bool Delete(PhieuDieuTri data)
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
                            PhieuDieuTri data = GetById(result);

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

        public static bool Update(PhieuDieuTri data)
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

        public static bool Update(int id, object pet, string ma, long tongTien,
            bool isKhamBenh, bool isChich_UongThuoc, bool isTruyenDichTinhMach, string khac = "", string trieuChung = "", 
            double? trongLuong = null, string nhietDo = "", string loiDanDo = "")
        {
            bool res = false;

            try
            {
                PhieuDieuTri data = GetById(id);

                if (data != null)
                {
                    if (pet is int)
                    {
                        data.Pet = PetImp.GetById(ConvertUtil.ConvertToInt(pet));
                    }
                    else
                    {
                        data.Pet = pet as Pet;
                    }

                    data.Ma = String.IsNullOrEmpty(ma) ? (CommonConstants.DEFAULT_PREFIX_CODE_PDT + id.ToString()) : ma;
                    data.TrongLuong = trongLuong;
                    data.NhietDo = nhietDo;
                    data.TrieuChung = trieuChung;
                    data.IsKhamBenh = isKhamBenh;
                    data.IsChich_UongThuoc = isChich_UongThuoc;
                    data.IsKhamBenh = isKhamBenh;
                    data.IsTruyenDichTinhMach = isTruyenDichTinhMach;
                    data.Khac = khac;
                    data.LoiDanDo = loiDanDo;
                    data.TongTien = tongTien;

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
