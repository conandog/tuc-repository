using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonHang
{
    public class KhaoSat
    {
        public int tienKhaoSat { get; set; }
        public string noiKhaoSat { get; set; }

        public KhaoSat(int tienkhaosat, string noikhaosat)
        {
            this.tienKhaoSat = tienkhaosat;
            this.noiKhaoSat = noikhaosat;
        }
    }
}
