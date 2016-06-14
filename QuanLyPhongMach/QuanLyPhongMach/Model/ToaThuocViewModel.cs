using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace QuanLyPhongMach.Model
{
    public class ToaThuocViewModel : PhieuDieuTri_Thuoc
    {
        public ToaThuocViewModel()
        {

        }

        public ToaThuocViewModel(PhieuDieuTri_Thuoc data)
        {
            Thuoc = data.Thuoc;
            DuongCap = data.DuongCap;
            LieuLuong = data.LieuLuong;
        }

        public static List<ToaThuocViewModel> GetListFromToaThuoc(List<PhieuDieuTri_Thuoc> listData)
        {
            List<ToaThuocViewModel> res = new List<ToaThuocViewModel>();

            foreach (PhieuDieuTri_Thuoc data in listData)
            {
                res.Add(new ToaThuocViewModel(data));
            }

            return res;
        }

        public int STT { get; set; }
    }
}
