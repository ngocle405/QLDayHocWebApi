using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QLDayHocWebApi.Models
{
    public partial class Sinhvien
    {
        public Sinhvien()
        {
            Hoctap = new HashSet<Hoctap>();
            Ketquathi = new HashSet<Ketquathi>();
            Nopbaitap = new HashSet<Nopbaitap>();
        }

        public long Masv { get; set; }
        public string Tensv { get; set; }
        public string Namnhaphoc { get; set; }
        public string Tentruongdh { get; set; }
        public long? Malop { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Diachinha { get; set; }
        public string Dienthoai { get; set; }
        public string Email { get; set; }
        public string Matkhau { get; set; }
        public string Anhdaidien { get; set; }
        public string Cmnd { get; set; }
        public string Dantoc { get; set; }
        public string Tongiao { get; set; }
        public bool? Gioitinh { get; set; }
        public string Chuyennganh { get; set; }
        public string Nganhhoc { get; set; }
        public string Hedaotao { get; set; }
        public string Nienkhoa { get; set; }
        public string Quoctich { get; set; }
        public bool? Isdelete { get; set; }
        public virtual Lophoc MalopNavigation { get; set; }
        public virtual ICollection<Hoctap> Hoctap { get; set; }
        public virtual ICollection<Ketquathi> Ketquathi { get; set; }
        public virtual ICollection<Nopbaitap> Nopbaitap { get; set; }
    }
}
