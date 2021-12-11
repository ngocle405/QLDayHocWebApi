using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QLDayHocWebApi.Models
{
    public partial class Baigiang
    {
        public long Mabg { get; set; }
        public string Tieude { get; set; }
        public string Noidung { get; set; }
        public long? Magiangday { get; set; }
        public DateTime? Ngaytao { get; set; }
        public string Nguoitao { get; set; }
        public string Filename { get; set; }
        public string Filelink { get; set; }
        public string Sotiet { get; set; }

        public virtual Giangday MagiangdayNavigation { get; set; }
    }
}
