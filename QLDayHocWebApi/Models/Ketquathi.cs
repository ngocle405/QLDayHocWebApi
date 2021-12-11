using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QLDayHocWebApi.Models
{
    public partial class Ketquathi
    {
        public long Makq { get; set; }
        public long? Masv { get; set; }
        public long? Mahp { get; set; }
        public int? Lanthi { get; set; }
        public DateTime? Ngaythi { get; set; }
        public string Ghichu { get; set; }
        public bool? Danhgia { get; set; }
        public double? Diemtb { get; set; }
        public double? Diemthuchanh { get; set; }
        public double? Diemlythuyet { get; set; }
        public long? Magv { get; set; }
        public long? Ma { get; set; }

        public virtual Hocphan MahpNavigation { get; set; }
        public virtual Sinhvien MasvNavigation { get; set; }
    }
}
