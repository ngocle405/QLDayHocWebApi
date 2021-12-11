using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QLDayHocWebApi.Models
{
    public partial class Baitap
    {
        public Baitap()
        {
            Nopbaitap = new HashSet<Nopbaitap>();
        }

        public long Mabt { get; set; }
        public string Tenbt { get; set; }
        public DateTime? Ngaytao { get; set; }
        public string Filename { get; set; }
        public string Filelink { get; set; }
        public long? Magiangday { get; set; }
        public long? Magv { get; set; }
        public string Nguoitao { get; set; }
        public DateTime? Thoihan { get; set; }
        public string Hethanluc { get; set; }
        public string Tieude { get; set; }
        public long? Masv { get; set; }

        public virtual Giangday MagiangdayNavigation { get; set; }
        public virtual ICollection<Nopbaitap> Nopbaitap { get; set; }
    }
}
