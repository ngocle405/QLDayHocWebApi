using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QLDayHocWebApi.Models
{
    public partial class Lophoc
    {
        public Lophoc()
        {
            Giangday = new HashSet<Giangday>();
            Sinhvien = new HashSet<Sinhvien>();
        }

        public long Malop { get; set; }
        public string Tenlop { get; set; }
        public string Siso { get; set; }
        public string Gvcn { get; set; }
        public string Khoa { get; set; }
        public bool? Isdelete { get; set; }

        public virtual ICollection<Giangday> Giangday { get; set; }
        public virtual ICollection<Sinhvien> Sinhvien { get; set; }
    }
}
