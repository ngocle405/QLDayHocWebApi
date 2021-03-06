USE [master]
GO
/****** Object:  Database [DA5_QLdayhoc]    Script Date: 06/11/2021 5:43:30 CH ******/
CREATE DATABASE [DA5_QLdayhoc]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DA5_QLdayhoc', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\DA5_QLdayhoc.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DA5_QLdayhoc_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\DA5_QLdayhoc_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DA5_QLdayhoc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DA5_QLdayhoc] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET ARITHABORT OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DA5_QLdayhoc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DA5_QLdayhoc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DA5_QLdayhoc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DA5_QLdayhoc] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET RECOVERY FULL 
GO
ALTER DATABASE [DA5_QLdayhoc] SET  MULTI_USER 
GO
ALTER DATABASE [DA5_QLdayhoc] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DA5_QLdayhoc] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DA5_QLdayhoc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DA5_QLdayhoc] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DA5_QLdayhoc] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DA5_QLdayhoc', N'ON'
GO
USE [DA5_QLdayhoc]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 06/11/2021 5:43:30 CH ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
/****** Object:  Table [dbo].[admincp]    Script Date: 06/11/2021 5:43:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[admincp](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [PK_admincp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[baigiai]    Script Date: 06/11/2021 5:43:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[baigiai](
	[mabaigiai] [bigint] IDENTITY(1,1) NOT NULL,
	[magv] [bigint] NULL,
	[mavande] [bigint] NULL,
	[thoigiantraloi] [date] NULL,
 CONSTRAINT [PK_baigiai] PRIMARY KEY CLUSTERED 
(
	[mabaigiai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[baigiang]    Script Date: 06/11/2021 5:43:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[baigiang](
	[mabg] [bigint] IDENTITY(1,1) NOT NULL,
	[tieude] [nvarchar](max) NULL,
	[noidung] [nvarchar](max) NULL,
	[magiangday] [bigint] NULL,
	[ngaytao] [date] NULL,
	[nguoitao] [nvarchar](50) NULL,
	[filename] [nvarchar](max) NULL,
	[filelink] [nvarchar](max) NULL,
 CONSTRAINT [PK_baigiang] PRIMARY KEY CLUSTERED 
(
	[mabg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[baitap]    Script Date: 06/11/2021 5:43:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[baitap](
	[mabt] [bigint] IDENTITY(1,1) NOT NULL,
	[tenbt] [nvarchar](50) NULL,
	[ngaytao] [date] NULL,
	[filename] [nvarchar](max) NULL,
	[filelink] [nvarchar](max) NULL,
	[magiangday] [bigint] NULL,
	[magv] [bigint] NULL,
 CONSTRAINT [PK_baitap] PRIMARY KEY CLUSTERED 
(
	[mabt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cauhoikiemtra]    Script Date: 06/11/2021 5:43:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cauhoikiemtra](
	[macauhoi] [bigint] IDENTITY(1,1) NOT NULL,
	[makhoahoc] [bigint] NULL,
	[diemkienthuc] [nvarchar](50) NULL,
	[phanchuong] [nvarchar](50) NULL,
	[loaicauhoikiemtra] [nvarchar](50) NULL,
	[tentieude] [nvarchar](110) NULL,
	[noidungcauhoi] [nvarchar](max) NULL,
	[cautraloi] [nvarchar](max) NULL,
 CONSTRAINT [PK_cauhoikiemtra] PRIMARY KEY CLUSTERED 
(
	[macauhoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[giangday]    Script Date: 06/11/2021 5:43:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[giangday](
	[magiangday] [bigint] IDENTITY(1,1) NOT NULL,
	[magv] [bigint] NULL,
	[malop] [bigint] NULL,
	[mahp] [bigint] NULL,
	[status] [bit] NULL,
	[ghichu] [nvarchar](250) NULL,
	[ngayhoc] [date] NULL,
	[namhoc] [varchar](50) NULL,
	[anhdaidien] [nvarchar](max) NULL,
	[isdelete] [bit] NULL,
 CONSTRAINT [PK_giangday] PRIMARY KEY CLUSTERED 
(
	[magiangday] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[giaovien]    Script Date: 06/11/2021 5:43:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[giaovien](
	[magv] [bigint] NOT NULL,
	[tengv] [nvarchar](50) NULL,
	[totnghieptruong] [nvarchar](250) NULL,
	[ngaytotnghiep] [date] NULL,
	[makhoa] [bigint] NULL,
	[chucdanhkythuat] [nvarchar](250) NULL,
	[bangcap] [nvarchar](250) NULL,
	[trinhdohocvan] [nvarchar](250) NULL,
	[dienthoai] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[soyeulylich] [nvarchar](max) NULL,
	[diachi] [nvarchar](50) NULL,
	[matkhau] [varchar](50) NULL,
	[anhdaidien] [nvarchar](max) NULL,
	[ngaysinh] [date] NULL,
	[dantoc] [nvarchar](50) NULL,
	[tongiao] [nvarchar](50) NULL,
	[cmnd] [varchar](50) NULL,
	[status] [bit] NULL,
	[kynang] [nvarchar](250) NULL,
	[quoctich] [nvarchar](50) NULL,
 CONSTRAINT [PK_giaovien] PRIMARY KEY CLUSTERED 
(
	[magv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[hocphan]    Script Date: 06/11/2021 5:43:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[hocphan](
	[mahp] [bigint] NOT NULL,
	[tenhp] [nvarchar](50) NULL,
	[hocky] [int] NULL,
	[tinhchat] [int] NULL,
	[sotc] [int] NULL,
	[sotclythuyet] [int] NULL,
	[sotcthuchanh] [int] NULL,
	[heso] [float] NULL,
	[ghichu] [nvarchar](250) NULL,
	[nguoitao] [nvarchar](50) NULL,
	[code] [varchar](50) NULL,
	[isdelete] [bit] NULL,
	[tieude] [nvarchar](max) NULL,
 CONSTRAINT [PK_hocphan] PRIMARY KEY CLUSTERED 
(
	[mahp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ketquathi]    Script Date: 06/11/2021 5:43:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ketquathi](
	[makq] [bigint] IDENTITY(1,1) NOT NULL,
	[masv] [bigint] NULL,
	[mahp] [bigint] NULL,
	[lanthi] [int] NULL,
	[ngaythi] [date] NULL,
	[diemthi] [float] NULL,
	[ghichu] [nvarchar](250) NULL,
	[danhgia] [bit] NULL,
 CONSTRAINT [PK_ketquathi] PRIMARY KEY CLUSTERED 
(
	[makq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[khoahoc]    Script Date: 06/11/2021 5:43:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khoahoc](
	[makhoahoc] [bigint] IDENTITY(1,1) NOT NULL,
	[tenkhoahoc] [nvarchar](50) NULL,
	[muctieukhoahoc] [nvarchar](250) NULL,
	[hocky] [nvarchar](50) NULL,
	[sotinchi] [int] NULL,
	[giolythuyet] [int] NULL,
	[giothuchanh] [int] NULL,
	[mota] [nvarchar](max) NULL,
 CONSTRAINT [PK_khoahoc] PRIMARY KEY CLUSTERED 
(
	[makhoahoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[lophoc]    Script Date: 06/11/2021 5:43:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lophoc](
	[malop] [bigint] NOT NULL,
	[tenlop] [nvarchar](50) NULL,
	[siso] [nvarchar](50) NULL,
	[gvcn] [nvarchar](50) NULL,
	[khoa] [nvarchar](50) NULL,
	[isdelete] [bigint] NULL,
 CONSTRAINT [PK_lophoc] PRIMARY KEY CLUSTERED 
(
	[malop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sinhvien]    Script Date: 06/11/2021 5:43:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sinhvien](
	[masv] [bigint] NOT NULL,
	[tensv] [nvarchar](50) NULL,
	[namnhaphoc] [varchar](50) NULL,
	[tentruongdh] [nvarchar](50) NULL,
	[malop] [bigint] NULL,
	[ngaysinh] [date] NULL,
	[diachinha] [nvarchar](50) NULL,
	[dienthoai] [varchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[matkhau] [varchar](50) NULL,
	[anhdaidien] [nvarchar](max) NULL,
	[cmnd] [varchar](50) NULL,
	[dantoc] [nvarchar](50) NULL,
	[tongiao] [nvarchar](50) NULL,
	[gioitinh] [bit] NULL,
	[chuyennganh] [nvarchar](50) NULL,
	[nganhhoc] [nvarchar](50) NULL,
	[hedaotao] [nvarchar](50) NULL,
	[nienkhoa] [nvarchar](50) NULL,
	[quoctich] [nvarchar](50) NULL,
 CONSTRAINT [PK_sinhvien] PRIMARY KEY CLUSTERED 
(
	[masv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tailieu]    Script Date: 06/11/2021 5:43:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tailieu](
	[matailieu] [bigint] IDENTITY(1,1) NOT NULL,
	[tentailieu] [nvarchar](50) NULL,
	[ngaytao] [date] NULL,
	[filename] [nvarchar](max) NULL,
	[filelink] [nvarchar](max) NULL,
	[nguoitao] [nvarchar](50) NULL,
	[magiangday] [bigint] NULL,
	[isdelete] [bit] NULL,
	[mota] [nvarchar](max) NULL,
 CONSTRAINT [PK_tailieu] PRIMARY KEY CLUSTERED 
(
	[matailieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[thaoluan]    Script Date: 06/11/2021 5:43:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thaoluan](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[tieude] [nvarchar](max) NULL,
	[noidung] [nvarchar](max) NULL,
	[ngaytao] [date] NULL,
	[nguoitao] [nvarchar](50) NULL,
	[magiangday] [bigint] NULL,
 CONSTRAINT [PK_thaoluan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[thongbaogv]    Script Date: 06/11/2021 5:43:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thongbaogv](
	[matbgv] [bigint] IDENTITY(1,1) NOT NULL,
	[tieude] [nvarchar](max) NULL,
	[noidung] [nvarchar](max) NULL,
	[magiangday] [bigint] NULL,
	[ngaytao] [date] NULL,
	[malop] [bigint] NULL,
	[magv] [bigint] NULL,
 CONSTRAINT [PK_thongbaogv] PRIMARY KEY CLUSTERED 
(
	[matbgv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[baigiai]  WITH CHECK ADD  CONSTRAINT [FK_baigiai_giaovien] FOREIGN KEY([magv])
REFERENCES [dbo].[giaovien] ([magv])
GO
ALTER TABLE [dbo].[baigiai] CHECK CONSTRAINT [FK_baigiai_giaovien]
GO
ALTER TABLE [dbo].[baigiang]  WITH CHECK ADD  CONSTRAINT [FK_baigiang_giangday] FOREIGN KEY([magiangday])
REFERENCES [dbo].[giangday] ([magiangday])
GO
ALTER TABLE [dbo].[baigiang] CHECK CONSTRAINT [FK_baigiang_giangday]
GO
ALTER TABLE [dbo].[baitap]  WITH CHECK ADD  CONSTRAINT [FK_baitap_giangday] FOREIGN KEY([magiangday])
REFERENCES [dbo].[giangday] ([magiangday])
GO
ALTER TABLE [dbo].[baitap] CHECK CONSTRAINT [FK_baitap_giangday]
GO
ALTER TABLE [dbo].[cauhoikiemtra]  WITH CHECK ADD  CONSTRAINT [FK_cauhoikiemtra_khoahoc] FOREIGN KEY([makhoahoc])
REFERENCES [dbo].[khoahoc] ([makhoahoc])
GO
ALTER TABLE [dbo].[cauhoikiemtra] CHECK CONSTRAINT [FK_cauhoikiemtra_khoahoc]
GO
ALTER TABLE [dbo].[giangday]  WITH CHECK ADD  CONSTRAINT [FK_giangday_hocphan] FOREIGN KEY([mahp])
REFERENCES [dbo].[hocphan] ([mahp])
GO
ALTER TABLE [dbo].[giangday] CHECK CONSTRAINT [FK_giangday_hocphan]
GO
ALTER TABLE [dbo].[giangday]  WITH CHECK ADD  CONSTRAINT [FK_giangday_lophoc] FOREIGN KEY([malop])
REFERENCES [dbo].[lophoc] ([malop])
GO
ALTER TABLE [dbo].[giangday] CHECK CONSTRAINT [FK_giangday_lophoc]
GO
ALTER TABLE [dbo].[ketquathi]  WITH CHECK ADD  CONSTRAINT [FK_ketquathi_hocphan] FOREIGN KEY([mahp])
REFERENCES [dbo].[hocphan] ([mahp])
GO
ALTER TABLE [dbo].[ketquathi] CHECK CONSTRAINT [FK_ketquathi_hocphan]
GO
ALTER TABLE [dbo].[ketquathi]  WITH CHECK ADD  CONSTRAINT [FK_ketquathi_sinhvien] FOREIGN KEY([masv])
REFERENCES [dbo].[sinhvien] ([masv])
GO
ALTER TABLE [dbo].[ketquathi] CHECK CONSTRAINT [FK_ketquathi_sinhvien]
GO
ALTER TABLE [dbo].[sinhvien]  WITH CHECK ADD  CONSTRAINT [FK_sinhvien_lophoc] FOREIGN KEY([malop])
REFERENCES [dbo].[lophoc] ([malop])
GO
ALTER TABLE [dbo].[sinhvien] CHECK CONSTRAINT [FK_sinhvien_lophoc]
GO
ALTER TABLE [dbo].[tailieu]  WITH CHECK ADD  CONSTRAINT [FK_tailieu_giangday] FOREIGN KEY([magiangday])
REFERENCES [dbo].[giangday] ([magiangday])
GO
ALTER TABLE [dbo].[tailieu] CHECK CONSTRAINT [FK_tailieu_giangday]
GO
ALTER TABLE [dbo].[thaoluan]  WITH CHECK ADD  CONSTRAINT [FK_thaoluan_giangday] FOREIGN KEY([magiangday])
REFERENCES [dbo].[giangday] ([magiangday])
GO
ALTER TABLE [dbo].[thaoluan] CHECK CONSTRAINT [FK_thaoluan_giangday]
GO
ALTER TABLE [dbo].[thongbaogv]  WITH CHECK ADD  CONSTRAINT [FK_thongbaogv_giangday] FOREIGN KEY([magiangday])
REFERENCES [dbo].[giangday] ([magiangday])
GO
ALTER TABLE [dbo].[thongbaogv] CHECK CONSTRAINT [FK_thongbaogv_giangday]
GO
USE [master]
GO
ALTER DATABASE [DA5_QLdayhoc] SET  READ_WRITE 
GO
