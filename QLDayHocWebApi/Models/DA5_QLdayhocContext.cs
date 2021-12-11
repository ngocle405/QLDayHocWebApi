using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QLDayHocWebApi.Models
{
    public partial class DA5_QLdayhocContext : DbContext
    {
        public DA5_QLdayhocContext()
        {
        }

        public DA5_QLdayhocContext(DbContextOptions<DA5_QLdayhocContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admincp> Admincps { get; set; }
        public virtual DbSet<Baigiang> Baigiangs { get; set; }
        public virtual DbSet<Baitap> Baitaps { get; set; }
        public virtual DbSet<Giangday> Giangdays { get; set; }
        public virtual DbSet<Giaovien> Giaoviens { get; set; }
        public virtual DbSet<Hocphan> Hocphans { get; set; }
        public virtual DbSet<Hoctap> Hoctaps { get; set; }
        public virtual DbSet<Ketquathi> Ketquathis { get; set; }
        public virtual DbSet<Khoahoc> Khoahocs { get; set; }
        public virtual DbSet<Lophoc> Lophocs { get; set; }
        public virtual DbSet<Nopbaitap> Nopbaitaps { get; set; }
        public virtual DbSet<Sinhvien> Sinhviens { get; set; }
        public virtual DbSet<Tailieu> Tailieus { get; set; }
        public virtual DbSet<Thaoluan> Thaoluans { get; set; }
        public virtual DbSet<Thongbaogv> Thongbaogvs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Name=DA5_QLdayhoc");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admincp>(entity =>
            {
                entity.ToTable("admincp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Baigiang>(entity =>
            {
                entity.HasKey(e => e.Mabg);

                entity.ToTable("baigiang");

                entity.Property(e => e.Mabg).HasColumnName("mabg");

                entity.Property(e => e.Filelink).HasColumnName("filelink");

                entity.Property(e => e.Filename).HasColumnName("filename");

                entity.Property(e => e.Magiangday).HasColumnName("magiangday");

                entity.Property(e => e.Ngaytao)
                    .HasColumnName("ngaytao")
                    .HasColumnType("date");

                entity.Property(e => e.Nguoitao)
                    .HasColumnName("nguoitao")
                    .HasMaxLength(50);

                entity.Property(e => e.Noidung).HasColumnName("noidung");

                entity.Property(e => e.Sotiet)
                    .HasColumnName("sotiet")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tieude).HasColumnName("tieude");

                entity.HasOne(d => d.MagiangdayNavigation)
                    .WithMany(p => p.Baigiang)
                    .HasForeignKey(d => d.Magiangday)
                    .HasConstraintName("FK_baigiang_giangday");
            });

            modelBuilder.Entity<Baitap>(entity =>
            {
                entity.HasKey(e => e.Mabt);

                entity.ToTable("baitap");

                entity.Property(e => e.Mabt).HasColumnName("mabt");

                entity.Property(e => e.Filelink).HasColumnName("filelink");

                entity.Property(e => e.Filename).HasColumnName("filename");

                entity.Property(e => e.Hethanluc).HasColumnName("hethanluc");

                entity.Property(e => e.Magiangday).HasColumnName("magiangday");

                entity.Property(e => e.Magv).HasColumnName("magv");

                entity.Property(e => e.Masv).HasColumnName("masv");

                entity.Property(e => e.Ngaytao)
                    .HasColumnName("ngaytao")
                    .HasColumnType("date");

                entity.Property(e => e.Nguoitao)
                    .HasColumnName("nguoitao")
                    .HasMaxLength(50);

                entity.Property(e => e.Tenbt)
                    .HasColumnName("tenbt")
                    .HasMaxLength(50);

                entity.Property(e => e.Thoihan)
                    .HasColumnName("thoihan")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tieude)
                    .HasColumnName("tieude")
                    .HasMaxLength(50);

                entity.HasOne(d => d.MagiangdayNavigation)
                    .WithMany(p => p.Baitap)
                    .HasForeignKey(d => d.Magiangday)
                    .HasConstraintName("FK_baitap_giangday");
            });

            modelBuilder.Entity<Giangday>(entity =>
            {
                entity.HasKey(e => e.Magiangday);

                entity.ToTable("giangday");

                entity.Property(e => e.Magiangday).HasColumnName("magiangday");

                entity.Property(e => e.Anhdaidien).HasColumnName("anhdaidien");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("ghichu")
                    .HasMaxLength(250);

                entity.Property(e => e.Isdelete).HasColumnName("isdelete");

                entity.Property(e => e.Magv).HasColumnName("magv");

                entity.Property(e => e.Mahp).HasColumnName("mahp");

                entity.Property(e => e.Malop).HasColumnName("malop");

                entity.Property(e => e.Namhoc)
                    .HasColumnName("namhoc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ngayhoc)
                    .HasColumnName("ngayhoc")
                    .HasColumnType("date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tiethoc)
                    .HasColumnName("tiethoc")
                    .HasMaxLength(50);

                entity.HasOne(d => d.MahpNavigation)
                    .WithMany(p => p.Giangday)
                    .HasForeignKey(d => d.Mahp)
                    .HasConstraintName("FK_giangday_hocphan");

                entity.HasOne(d => d.MalopNavigation)
                    .WithMany(p => p.Giangday)
                    .HasForeignKey(d => d.Malop)
                    .HasConstraintName("FK_giangday_lophoc");
            });

            modelBuilder.Entity<Giaovien>(entity =>
            {
                entity.HasKey(e => e.Magv);

                entity.ToTable("giaovien");

                entity.Property(e => e.Magv)
                    .HasColumnName("magv")
                    .ValueGeneratedNever();

                entity.Property(e => e.Anhdaidien).HasColumnName("anhdaidien");

                entity.Property(e => e.Bangcap)
                    .HasColumnName("bangcap")
                    .HasMaxLength(250);

                entity.Property(e => e.Chucdanhkythuat)
                    .HasColumnName("chucdanhkythuat")
                    .HasMaxLength(250);

                entity.Property(e => e.Chuyennganh).HasColumnName("chuyennganh");

                entity.Property(e => e.Cmnd)
                    .HasColumnName("cmnd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dantoc)
                    .HasColumnName("dantoc")
                    .HasMaxLength(50);

                entity.Property(e => e.Diachi)
                    .HasColumnName("diachi")
                    .HasMaxLength(50);

                entity.Property(e => e.Dienthoai)
                    .HasColumnName("dienthoai")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Isdelete).HasColumnName("isdelete");

                entity.Property(e => e.Kynang)
                    .HasColumnName("kynang")
                    .HasMaxLength(250);

                entity.Property(e => e.Makhoa).HasColumnName("makhoa");

                entity.Property(e => e.Matkhau)
                    .HasColumnName("matkhau")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("ngaysinh")
                    .HasColumnType("date");

                entity.Property(e => e.Ngaytotnghiep)
                    .HasColumnName("ngaytotnghiep")
                    .HasColumnType("date");

                entity.Property(e => e.Quoctich)
                    .HasColumnName("quoctich")
                    .HasMaxLength(50);

                entity.Property(e => e.Soyeulylich).HasColumnName("soyeulylich");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tengv)
                    .HasColumnName("tengv")
                    .HasMaxLength(50);

                entity.Property(e => e.Tongiao)
                    .HasColumnName("tongiao")
                    .HasMaxLength(50);

                entity.Property(e => e.Totnghieptruong)
                    .HasColumnName("totnghieptruong")
                    .HasMaxLength(250);

                entity.Property(e => e.Trinhdohocvan)
                    .HasColumnName("trinhdohocvan")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Hocphan>(entity =>
            {
                entity.HasKey(e => e.Mahp);

                entity.ToTable("hocphan");

                entity.Property(e => e.Mahp).HasColumnName("mahp");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ghichu).HasColumnName("ghichu");

                entity.Property(e => e.Heso).HasColumnName("heso");

                entity.Property(e => e.Hocky).HasColumnName("hocky");

                entity.Property(e => e.Isdelete).HasColumnName("isdelete");

                entity.Property(e => e.Nguoitao)
                    .HasColumnName("nguoitao")
                    .HasMaxLength(50);

                entity.Property(e => e.Sotc).HasColumnName("sotc");

                entity.Property(e => e.Tenhp)
                    .HasColumnName("tenhp")
                    .HasMaxLength(50);

                entity.Property(e => e.Tieude).HasColumnName("tieude");

                entity.Property(e => e.Tinhchat).HasColumnName("tinhchat");
            });

            modelBuilder.Entity<Hoctap>(entity =>
            {
                entity.HasKey(e => e.Mahoctap);

                entity.ToTable("hoctap");

                entity.Property(e => e.Mahoctap).HasColumnName("mahoctap");

                entity.Property(e => e.Ghichu).HasColumnName("ghichu");

                entity.Property(e => e.Isdelete).HasColumnName("isdelete");

                entity.Property(e => e.Magiangday).HasColumnName("magiangday");

                entity.Property(e => e.Magv).HasColumnName("magv");

                entity.Property(e => e.Mahp).HasColumnName("mahp");

                entity.Property(e => e.Masv).HasColumnName("masv");

                entity.HasOne(d => d.MagiangdayNavigation)
                    .WithMany(p => p.Hoctap)
                    .HasForeignKey(d => d.Magiangday)
                    .HasConstraintName("FK_hoctap_giangday");

                entity.HasOne(d => d.MagvNavigation)
                    .WithMany(p => p.Hoctap)
                    .HasForeignKey(d => d.Magv)
                    .HasConstraintName("FK_hoctap_giaovien");

                entity.HasOne(d => d.MasvNavigation)
                    .WithMany(p => p.Hoctap)
                    .HasForeignKey(d => d.Masv)
                    .HasConstraintName("FK_hoctap_sinhvien");
            });

            modelBuilder.Entity<Ketquathi>(entity =>
            {
                entity.HasKey(e => e.Makq);

                entity.ToTable("ketquathi");

                entity.Property(e => e.Makq).HasColumnName("makq");

                entity.Property(e => e.Danhgia).HasColumnName("danhgia");

                entity.Property(e => e.Diemlythuyet).HasColumnName("diemlythuyet");

                entity.Property(e => e.Diemtb).HasColumnName("diemtb");

                entity.Property(e => e.Diemthuchanh).HasColumnName("diemthuchanh");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("ghichu")
                    .HasMaxLength(250);

                entity.Property(e => e.Lanthi).HasColumnName("lanthi");

                entity.Property(e => e.Ma).HasColumnName("ma");

                entity.Property(e => e.Magv).HasColumnName("magv");

                entity.Property(e => e.Mahp).HasColumnName("mahp");

                entity.Property(e => e.Masv).HasColumnName("masv");

                entity.Property(e => e.Ngaythi)
                    .HasColumnName("ngaythi")
                    .HasColumnType("date");

                entity.HasOne(d => d.MahpNavigation)
                    .WithMany(p => p.Ketquathi)
                    .HasForeignKey(d => d.Mahp)
                    .HasConstraintName("FK_ketquathi_hocphan");

                entity.HasOne(d => d.MasvNavigation)
                    .WithMany(p => p.Ketquathi)
                    .HasForeignKey(d => d.Masv)
                    .HasConstraintName("FK_ketquathi_sinhvien");
            });

            modelBuilder.Entity<Khoahoc>(entity =>
            {
                entity.HasKey(e => e.Makhoahoc);

                entity.ToTable("khoahoc");

                entity.Property(e => e.Makhoahoc).HasColumnName("makhoahoc");

                entity.Property(e => e.Giolythuyet).HasColumnName("giolythuyet");

                entity.Property(e => e.Giothuchanh).HasColumnName("giothuchanh");

                entity.Property(e => e.Hocky)
                    .HasColumnName("hocky")
                    .HasMaxLength(50);

                entity.Property(e => e.Mota).HasColumnName("mota");

                entity.Property(e => e.Muctieukhoahoc)
                    .HasColumnName("muctieukhoahoc")
                    .HasMaxLength(250);

                entity.Property(e => e.Sotinchi).HasColumnName("sotinchi");

                entity.Property(e => e.Tenkhoahoc)
                    .HasColumnName("tenkhoahoc")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Lophoc>(entity =>
            {
                entity.HasKey(e => e.Malop);

                entity.ToTable("lophoc");

                entity.Property(e => e.Malop)
                    .HasColumnName("malop")
                    .ValueGeneratedNever();

                entity.Property(e => e.Gvcn)
                    .HasColumnName("gvcn")
                    .HasMaxLength(50);

                entity.Property(e => e.Isdelete).HasColumnName("isdelete");

                entity.Property(e => e.Khoa)
                    .HasColumnName("khoa")
                    .HasMaxLength(50);

                entity.Property(e => e.Siso)
                    .HasColumnName("siso")
                    .HasMaxLength(50);

                entity.Property(e => e.Tenlop)
                    .HasColumnName("tenlop")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Nopbaitap>(entity =>
            {
                entity.ToTable("nopbaitap");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Filelink).HasColumnName("filelink");

                entity.Property(e => e.Filename).HasColumnName("filename");

                entity.Property(e => e.Isdelete).HasColumnName("isdelete");

                entity.Property(e => e.Mabt).HasColumnName("mabt");

                entity.Property(e => e.Mahoctap).HasColumnName("mahoctap");

                entity.Property(e => e.Masv).HasColumnName("masv");

                entity.Property(e => e.Ngaytao)
                    .HasColumnName("ngaytao")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nguoitao)
                    .HasColumnName("nguoitao")
                    .HasMaxLength(50);

                entity.Property(e => e.Noidung).HasColumnName("noidung");

                entity.Property(e => e.Tieude).HasColumnName("tieude");

                entity.HasOne(d => d.MabtNavigation)
                    .WithMany(p => p.Nopbaitap)
                    .HasForeignKey(d => d.Mabt)
                    .HasConstraintName("FK_nopbaitap_baitap");

                entity.HasOne(d => d.MasvNavigation)
                    .WithMany(p => p.Nopbaitap)
                    .HasForeignKey(d => d.Masv)
                    .HasConstraintName("FK_nopbaitap_sinhvien");
            });

            modelBuilder.Entity<Sinhvien>(entity =>
            {
                entity.HasKey(e => e.Masv);

                entity.ToTable("sinhvien");

                entity.Property(e => e.Masv)
                    .HasColumnName("masv")
                    .ValueGeneratedNever();
                entity.Property(e => e.Isdelete).HasColumnName("isdelete");
                entity.Property(e => e.Anhdaidien).HasColumnName("anhdaidien");

                entity.Property(e => e.Chuyennganh)
                    .HasColumnName("chuyennganh")
                    .HasMaxLength(50);

                entity.Property(e => e.Cmnd)
                    .HasColumnName("cmnd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dantoc)
                    .HasColumnName("dantoc")
                    .HasMaxLength(50);

                entity.Property(e => e.Diachinha)
                    .HasColumnName("diachinha")
                    .HasMaxLength(50);

                entity.Property(e => e.Dienthoai)
                    .HasColumnName("dienthoai")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Gioitinh).HasColumnName("gioitinh");

                entity.Property(e => e.Hedaotao)
                    .HasColumnName("hedaotao")
                    .HasMaxLength(50);

                entity.Property(e => e.Malop).HasColumnName("malop");

                entity.Property(e => e.Matkhau)
                    .HasColumnName("matkhau")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Namnhaphoc)
                    .HasColumnName("namnhaphoc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nganhhoc)
                    .HasColumnName("nganhhoc")
                    .HasMaxLength(50);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("ngaysinh")
                    .HasColumnType("date");

                entity.Property(e => e.Nienkhoa)
                    .HasColumnName("nienkhoa")
                    .HasMaxLength(50);

                entity.Property(e => e.Quoctich)
                    .HasColumnName("quoctich")
                    .HasMaxLength(50);

                entity.Property(e => e.Tensv)
                    .HasColumnName("tensv")
                    .HasMaxLength(50);

                entity.Property(e => e.Tentruongdh)
                    .HasColumnName("tentruongdh")
                    .HasMaxLength(50);

                entity.Property(e => e.Tongiao)
                    .HasColumnName("tongiao")
                    .HasMaxLength(50);

                entity.HasOne(d => d.MalopNavigation)
                    .WithMany(p => p.Sinhvien)
                    .HasForeignKey(d => d.Malop)
                    .HasConstraintName("FK_sinhvien_lophoc");
            });

            modelBuilder.Entity<Tailieu>(entity =>
            {
                entity.HasKey(e => e.Matailieu);

                entity.ToTable("tailieu");

                entity.Property(e => e.Matailieu).HasColumnName("matailieu");

                entity.Property(e => e.Filelink).HasColumnName("filelink");

                entity.Property(e => e.Filename).HasColumnName("filename");

                entity.Property(e => e.Isdelete).HasColumnName("isdelete");

                entity.Property(e => e.Magiangday).HasColumnName("magiangday");

                entity.Property(e => e.Mota).HasColumnName("mota");

                entity.Property(e => e.Ngaytao)
                    .HasColumnName("ngaytao")
                    .HasColumnType("date");

                entity.Property(e => e.Nguoitao)
                    .HasColumnName("nguoitao")
                    .HasMaxLength(50);

                entity.Property(e => e.Tentailieu)
                    .HasColumnName("tentailieu")
                    .HasMaxLength(50);

                entity.HasOne(d => d.MagiangdayNavigation)
                    .WithMany(p => p.Tailieu)
                    .HasForeignKey(d => d.Magiangday)
                    .HasConstraintName("FK_tailieu_giangday");
            });

            modelBuilder.Entity<Thaoluan>(entity =>
            {
                entity.ToTable("thaoluan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Magiangday).HasColumnName("magiangday");

                entity.Property(e => e.Ngaytao)
                    .HasColumnName("ngaytao")
                    .HasColumnType("date");

                entity.Property(e => e.Nguoitao)
                    .HasColumnName("nguoitao")
                    .HasMaxLength(50);

                entity.Property(e => e.Noidung).HasColumnName("noidung");

                entity.Property(e => e.Tieude).HasColumnName("tieude");

                entity.HasOne(d => d.MagiangdayNavigation)
                    .WithMany(p => p.Thaoluan)
                    .HasForeignKey(d => d.Magiangday)
                    .HasConstraintName("FK_thaoluan_giangday");
            });

            modelBuilder.Entity<Thongbaogv>(entity =>
            {
                entity.HasKey(e => e.Matbgv);

                entity.ToTable("thongbaogv");

                entity.Property(e => e.Matbgv).HasColumnName("matbgv");

                entity.Property(e => e.Magiangday).HasColumnName("magiangday");

                entity.Property(e => e.Magv).HasColumnName("magv");

                entity.Property(e => e.Malop).HasColumnName("malop");

                entity.Property(e => e.Ngaytao)
                    .HasColumnName("ngaytao")
                    .HasColumnType("date");

                entity.Property(e => e.Noidung).HasColumnName("noidung");

                entity.Property(e => e.Tieude).HasColumnName("tieude");

                entity.HasOne(d => d.MagiangdayNavigation)
                    .WithMany(p => p.Thongbaogv)
                    .HasForeignKey(d => d.Magiangday)
                    .HasConstraintName("FK_thongbaogv_giangday");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
