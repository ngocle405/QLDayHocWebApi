using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QLDayHocWebApi.Models
{
    public partial class Thongbaogv
    {
        public long Matbgv { get; set; }
        public string Tieude { get; set; }
        public string Noidung { get; set; }
        public long? Magiangday { get; set; }
        public DateTime? Ngaytao { get; set; }
        public long? Malop { get; set; }
        public long? Magv { get; set; }

        public virtual Giangday MagiangdayNavigation { get; set; }
    }
}
