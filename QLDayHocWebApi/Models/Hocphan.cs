using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QLDayHocWebApi.Models
{
    public partial class Hocphan
    {
        public Hocphan()
        {
            Giangday = new HashSet<Giangday>();
            Ketquathi = new HashSet<Ketquathi>();
        }

        public long Mahp { get; set; }
        public string Tenhp { get; set; }
        public string Code { get; set; }
        public int? Hocky { get; set; }
        public int? Tinhchat { get; set; }
        public int? Sotc { get; set; }
        public double? Heso { get; set; }
        public string Ghichu { get; set; }
        public string Nguoitao { get; set; }
        public string Tieude { get; set; }
        public bool? Isdelete { get; set; }

        public virtual ICollection<Giangday> Giangday { get; set; }
        public virtual ICollection<Ketquathi> Ketquathi { get; set; }
    }
}
