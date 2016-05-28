using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace QuanLyPhongMach.Model
{
    public class PetViewModel : Pet
    {
        public PetViewModel()
        {
            
        }

        public PetViewModel(Pet data)
        {
            Id = data.Id;
            IdGroup = data.IdGroup;
            IdKhachHang = data.IdKhachHang;
            Ten = data.Ten;
            GioiTinh = data.GioiTinh;
            DOB = data.DOB;
            TrongLuong = data.TrongLuong;
            GhiChu = data.GhiChu;

            KhachHang = data.KhachHang;
            PetGroup = data.PetGroup;
        }

        public static List<PetViewModel> GetListFromPet(List<Pet> listData)
        {
            List<PetViewModel> res = new List<PetViewModel>();

            foreach (Pet data in listData)
            {
                res.Add(new PetViewModel(data));
            }

            return res;
        }

        public int Tuoi
        {
            get
            {
                int age = 0;

                if (DOB.HasValue)
                {
                    age = DateTime.Today.Year - DOB.Value.Year;
                    age = DateTime.Today < DOB.Value.AddYears(age) ? age-- : age; 
                }

                return age;
            }
        }
    }
}
