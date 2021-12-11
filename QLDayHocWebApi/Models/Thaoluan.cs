using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QLDayHocWebApi.Models
{
    public partial class Thaoluan
    {
        public long Id { get; set; }
        public string Tieude { get; set; }
        public string Noidung { get; set; }
        public DateTime? Ngaytao { get; set; }
        public string Nguoitao { get; set; }
        public long? Magiangday { get; set; }

        public virtual Giangday MagiangdayNavigation { get; set; }
    }
}
