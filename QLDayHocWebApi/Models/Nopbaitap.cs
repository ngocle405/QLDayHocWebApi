using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QLDayHocWebApi.Models
{
    public partial class Nopbaitap
    {
        public long Id { get; set; }
        public string Tieude { get; set; }
        public string Noidung { get; set; }
        public string Filename { get; set; }
        public string Filelink { get; set; }
        public DateTime? Ngaytao { get; set; }
        public string Nguoitao { get; set; }
        public long? Mabt { get; set; }
        public long? Mahoctap { get; set; }
        public bool? Isdelete { get; set; }
        public long? Masv { get; set; }

        public virtual Baitap MabtNavigation { get; set; }
        public virtual Sinhvien MasvNavigation { get; set; }
    }
}
