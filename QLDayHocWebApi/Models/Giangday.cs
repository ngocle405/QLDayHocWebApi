using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QLDayHocWebApi.Models
{
    public partial class Giangday
    {
        public Giangday()
        {
            Baigiang = new HashSet<Baigiang>();
            Baitap = new HashSet<Baitap>();
            Hoctap = new HashSet<Hoctap>();
            Tailieu = new HashSet<Tailieu>();
            Thaoluan = new HashSet<Thaoluan>();
            Thongbaogv = new HashSet<Thongbaogv>();
        }

        public long Magiangday { get; set; }
        public long? Magv { get; set; }
        public long? Malop { get; set; }
        public long? Mahp { get; set; }
        public bool? Status { get; set; }
        public string Ghichu { get; set; }
        public DateTime? Ngayhoc { get; set; }
        public string Namhoc { get; set; }
        public string Anhdaidien { get; set; }
        public bool? Isdelete { get; set; }
        public string Tiethoc { get; set; }

        public virtual Hocphan MahpNavigation { get; set; }
        public virtual Lophoc MalopNavigation { get; set; }
        public virtual ICollection<Baigiang> Baigiang { get; set; }
        public virtual ICollection<Baitap> Baitap { get; set; }
        public virtual ICollection<Hoctap> Hoctap { get; set; }
        public virtual ICollection<Tailieu> Tailieu { get; set; }
        public virtual ICollection<Thaoluan> Thaoluan { get; set; }
        public virtual ICollection<Thongbaogv> Thongbaogv { get; set; }
    }
}
