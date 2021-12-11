using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QLDayHocWebApi.Models
{
    public partial class Khoahoc
    {
        public long Makhoahoc { get; set; }
        public string Tenkhoahoc { get; set; }
        public string Muctieukhoahoc { get; set; }
        public string Hocky { get; set; }
        public int? Sotinchi { get; set; }
        public int? Giolythuyet { get; set; }
        public int? Giothuchanh { get; set; }
        public string Mota { get; set; }
    }
}
