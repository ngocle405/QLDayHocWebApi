using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QLDayHocWebApi.Models
{
    public partial class Tailieu
    {
        public long Matailieu { get; set; }
        public string Tentailieu { get; set; }
        public DateTime? Ngaytao { get; set; }
        public string Filename { get; set; }
        public string Filelink { get; set; }
        public string Nguoitao { get; set; }
        public long? Magiangday { get; set; }
        public bool? Isdelete { get; set; }
        public string Mota { get; set; }

        public virtual Giangday MagiangdayNavigation { get; set; }
    }
}
