using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QLDayHocWebApi.Models
{
    public partial class Hoctap
    {
        public long Mahoctap { get; set; }
        public long? Magiangday { get; set; }
        public long? Masv { get; set; }
        public long? Magv { get; set; }
        public long? Mahp { get; set; }
        public string Ghichu { get; set; }
        public bool? Isdelete { get; set; }

        public virtual Giangday MagiangdayNavigation { get; set; }
        public virtual Giaovien MagvNavigation { get; set; }
        public virtual Sinhvien MasvNavigation { get; set; }
    }
}
