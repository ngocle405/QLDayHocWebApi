USE [master]
GO
/****** Object:  Database [ShopquanaoMVC]    Script Date: 26/7/2021 23:17:10 PM ******/
CREATE DATABASE [ShopquanaoMVC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopquanaoMVC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ShopquanaoMVC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopquanaoMVC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ShopquanaoMVC_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ShopquanaoMVC] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopquanaoMVC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopquanaoMVC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopquanaoMVC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopquanaoMVC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShopquanaoMVC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopquanaoMVC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET RECOVERY FULL 
GO
ALTER DATABASE [ShopquanaoMVC] SET  MULTI_USER 
GO
ALTER DATABASE [ShopquanaoMVC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopquanaoMVC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopquanaoMVC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopquanaoMVC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopquanaoMVC] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShopquanaoMVC', N'ON'
GO
ALTER DATABASE [ShopquanaoMVC] SET QUERY_STORE = OFF
GO
USE [ShopquanaoMVC]
GO
/****** Object:  Table [dbo].[adminCP]    Script Date: 26/7/2021 23:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[adminCP](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hoten] [nvarchar](255) NULL,
	[pass] [varchar](50) NULL,
	[tendangnhap] [varchar](50) NULL,
	[email] [varchar](250) NULL,
	[status] [int] NULL,
	[diachi] [nvarchar](50) NULL,
	[img] [nvarchar](250) NULL,
	[hocvan] [nvarchar](250) NULL,
	[gioitinh] [nvarchar](50) NULL,
	[congviec] [nvarchar](50) NULL,
	[sothich] [nvarchar](max) NULL,
	[mota] [nvarchar](max) NULL,
	[tuoi] [int] NULL,
	[dienthoai] [varchar](50) NULL,
 CONSTRAINT [PK_adminCP] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[anhminhhoa]    Script Date: 26/7/2021 23:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[anhminhhoa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[masp] [int] NULL,
	[img] [nvarchar](255) NULL,
 CONSTRAINT [PK_anhminhhoa] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chitietdonhang]    Script Date: 26/7/2021 23:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitietdonhang](
	[mact] [int] IDENTITY(1,1) NOT NULL,
	[madh] [int] NULL,
	[masp] [int] NULL,
	[giaban] [int] NULL,
	[soluong] [int] NULL,
	[ngaydat] [date] NULL,
 CONSTRAINT [PK_chitietdonhang] PRIMARY KEY CLUSTERED 
(
	[mact] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chitietphieunhap]    Script Date: 26/7/2021 23:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitietphieunhap](
	[mactp] [int] IDENTITY(1,1) NOT NULL,
	[tensp] [nvarchar](50) NULL,
	[soluong] [int] NULL,
	[dongia] [int] NULL,
	[giakm] [int] NULL,
	[gianhap] [int] NULL,
	[ngaytao] [date] NULL,
	[maphieu] [int] NULL,
 CONSTRAINT [PK_chitietphieunhap] PRIMARY KEY CLUSTERED 
(
	[mactp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[danhmuc]    Script Date: 26/7/2021 23:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[danhmuc](
	[madanhmuc] [int] IDENTITY(1,1) NOT NULL,
	[tendanhmuc] [nvarchar](255) NULL,
	[ghichu] [nvarchar](255) NULL,
 CONSTRAINT [PK_danhmuc] PRIMARY KEY CLUSTERED 
(
	[madanhmuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[donhang]    Script Date: 26/7/2021 23:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[donhang](
	[madh] [int] IDENTITY(1,1) NOT NULL,
	[makh] [int] NULL,
	[tenkh] [nvarchar](50) NULL,
	[email] [varchar](50) NULL,
	[dienthoai] [varchar](50) NULL,
	[diachi] [nvarchar](max) NULL,
	[tongtien] [int] NULL,
	[ngaytao] [date] NULL,
	[status] [int] NULL,
	[ghichu] [nvarchar](max) NULL,
 CONSTRAINT [PK_donhang] PRIMARY KEY CLUSTERED 
(
	[madh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hangsanxuat]    Script Date: 26/7/2021 23:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hangsanxuat](
	[mahsx] [int] IDENTITY(1,1) NOT NULL,
	[tenhsx] [nvarchar](255) NULL,
	[diachi] [nvarchar](50) NULL,
	[ghichu] [nvarchar](max) NULL,
 CONSTRAINT [PK_hangsanxuat] PRIMARY KEY CLUSTERED 
(
	[mahsx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khachhang]    Script Date: 26/7/2021 23:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khachhang](
	[makh] [int] IDENTITY(1,1) NOT NULL,
	[tenkh] [nvarchar](50) NULL,
	[email] [varchar](max) NULL,
	[pass] [varchar](50) NULL,
	[diachi] [nvarchar](50) NULL,
	[dienthoai] [varchar](50) NULL,
	[sotiendamua] [int] NULL,
	[status] [bit] NULL,
	[ngaytao] [date] NULL,
	[img] [nvarchar](255) NULL,
 CONSTRAINT [PK_khachhang] PRIMARY KEY CLUSTERED 
(
	[makh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lienhe]    Script Date: 26/7/2021 23:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lienhe](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenkh] [nvarchar](50) NULL,
	[email] [varchar](50) NULL,
	[noidung] [nvarchar](max) NULL,
	[ngaygui] [date] NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_lienhe] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhacungcap]    Script Date: 26/7/2021 23:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhacungcap](
	[mancc] [int] IDENTITY(1,1) NOT NULL,
	[tenncc] [nvarchar](255) NULL,
	[diachi] [nvarchar](255) NULL,
	[dienthoai] [nvarchar](250) NULL,
	[ghichu] [nvarchar](max) NULL,
 CONSTRAINT [PK_nhacungcap] PRIMARY KEY CLUSTERED 
(
	[mancc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[phieunhaphang]    Script Date: 26/7/2021 23:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phieunhaphang](
	[maphieu] [int] IDENTITY(1,1) NOT NULL,
	[mancc] [int] NULL,
	[ngaytao] [date] NULL,
	[ghichu] [nvarchar](max) NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_phieunhaphang] PRIMARY KEY CLUSTERED 
(
	[maphieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sanpham]    Script Date: 26/7/2021 23:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sanpham](
	[masp] [int] IDENTITY(1,1) NOT NULL,
	[madanhmuc] [int] NULL,
	[mancc] [int] NULL,
	[mahsx] [int] NULL,
	[tensp] [nvarchar](255) NULL,
	[giaban] [int] NULL,
	[gianhap] [int] NULL,
	[giakm] [int] NULL,
	[chatlieu] [nvarchar](255) NULL,
	[chieudai] [nvarchar](50) NULL,
	[kieudang] [nvarchar](255) NULL,
	[mausac] [nvarchar](50) NULL,
	[guitu] [nvarchar](50) NULL,
	[uudiem] [nvarchar](255) NULL,
	[size] [nvarchar](50) NULL,
	[soluong] [int] NULL,
	[baohanh] [nvarchar](max) NULL,
	[camket] [nvarchar](max) NULL,
	[noidung] [nvarchar](max) NULL,
	[hinhanh] [nvarchar](max) NULL,
	[ngaytao] [date] NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_sanpham] PRIMARY KEY CLUSTERED 
(
	[masp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tintuc]    Script Date: 26/7/2021 23:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tintuc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tieude] [nvarchar](max) NULL,
	[noidung] [nvarchar](max) NULL,
	[ngaydang] [date] NULL,
	[status] [int] NULL,
	[img1] [nvarchar](250) NULL,
	[img2] [nvarchar](250) NULL,
	[img3] [nvarchar](max) NULL,
 CONSTRAINT [PK_tintuc] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[anhminhhoa]  WITH CHECK ADD  CONSTRAINT [FK_anhminhhoa_sanpham] FOREIGN KEY([masp])
REFERENCES [dbo].[sanpham] ([masp])
GO
ALTER TABLE [dbo].[anhminhhoa] CHECK CONSTRAINT [FK_anhminhhoa_sanpham]
GO
ALTER TABLE [dbo].[chitietdonhang]  WITH CHECK ADD  CONSTRAINT [FK_chitietdonhang_donhang] FOREIGN KEY([madh])
REFERENCES [dbo].[donhang] ([madh])
GO
ALTER TABLE [dbo].[chitietdonhang] CHECK CONSTRAINT [FK_chitietdonhang_donhang]
GO
ALTER TABLE [dbo].[chitietdonhang]  WITH CHECK ADD  CONSTRAINT [FK_chitietdonhang_sanpham] FOREIGN KEY([masp])
REFERENCES [dbo].[sanpham] ([masp])
GO
ALTER TABLE [dbo].[chitietdonhang] CHECK CONSTRAINT [FK_chitietdonhang_sanpham]
GO
ALTER TABLE [dbo].[chitietphieunhap]  WITH CHECK ADD  CONSTRAINT [FK_chitietphieunhap_phieunhaphang] FOREIGN KEY([maphieu])
REFERENCES [dbo].[phieunhaphang] ([maphieu])
GO
ALTER TABLE [dbo].[chitietphieunhap] CHECK CONSTRAINT [FK_chitietphieunhap_phieunhaphang]
GO
ALTER TABLE [dbo].[donhang]  WITH CHECK ADD  CONSTRAINT [FK_donhang_khachhang] FOREIGN KEY([makh])
REFERENCES [dbo].[khachhang] ([makh])
GO
ALTER TABLE [dbo].[donhang] CHECK CONSTRAINT [FK_donhang_khachhang]
GO
ALTER TABLE [dbo].[phieunhaphang]  WITH CHECK ADD  CONSTRAINT [FK_phieunhaphang_nhacungcap] FOREIGN KEY([mancc])
REFERENCES [dbo].[nhacungcap] ([mancc])
GO
ALTER TABLE [dbo].[phieunhaphang] CHECK CONSTRAINT [FK_phieunhaphang_nhacungcap]
GO
ALTER TABLE [dbo].[sanpham]  WITH CHECK ADD  CONSTRAINT [FK_sanpham_danhmuc] FOREIGN KEY([madanhmuc])
REFERENCES [dbo].[danhmuc] ([madanhmuc])
GO
ALTER TABLE [dbo].[sanpham] CHECK CONSTRAINT [FK_sanpham_danhmuc]
GO
ALTER TABLE [dbo].[sanpham]  WITH CHECK ADD  CONSTRAINT [FK_sanpham_hangsanxuat] FOREIGN KEY([mahsx])
REFERENCES [dbo].[hangsanxuat] ([mahsx])
GO
ALTER TABLE [dbo].[sanpham] CHECK CONSTRAINT [FK_sanpham_hangsanxuat]
GO
ALTER TABLE [dbo].[sanpham]  WITH CHECK ADD  CONSTRAINT [FK_sanpham_nhacungcap] FOREIGN KEY([mancc])
REFERENCES [dbo].[nhacungcap] ([mancc])
GO
ALTER TABLE [dbo].[sanpham] CHECK CONSTRAINT [FK_sanpham_nhacungcap]
GO
USE [master]
GO
ALTER DATABASE [ShopquanaoMVC] SET  READ_WRITE 
GO
