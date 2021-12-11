using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QLDayHocWebApi.Models
{
    public partial class Giaovien
    {
        public Giaovien()
        {
            Hoctap = new HashSet<Hoctap>();
        }

        public long Magv { get; set; }
        public string Tengv { get; set; }
        public string Totnghieptruong { get; set; }
        public DateTime? Ngaytotnghiep { get; set; }
        public long? Makhoa { get; set; }
        public string Chucdanhkythuat { get; set; }
        public string Bangcap { get; set; }
        public string Trinhdohocvan { get; set; }
        public string Dienthoai { get; set; }
        public string Email { get; set; }
        public string Soyeulylich { get; set; }
        public string Diachi { get; set; }
        public string Matkhau { get; set; }
        public string Anhdaidien { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Dantoc { get; set; }
        public string Tongiao { get; set; }
        public string Cmnd { get; set; }
        public bool? Status { get; set; }
        public string Kynang { get; set; }
        public string Quoctich { get; set; }
        public bool? Isdelete { get; set; }
        public string Chuyennganh { get; set; }

        public virtual ICollection<Hoctap> Hoctap { get; set; }
    }
}
