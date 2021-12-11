using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLDayHocWebApi.Models;
using QLDayHocWebApi.ViewModels.Common;
using QLDayHocWebApi.ViewModels.Sinhvien;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// - XỬ LÝ CÁC NGHIỆP VỤ BÊN PHÍA SINH VIÊN - CREATEBY : LÊ THANH NGỌC (03/12/2021)
/// - VÌ CÓ NHIỀU CHỨC NĂNG NÊN MÌNH PHẢI GÓI GỌN NÓ VÀO 1 CONTROLLER VÀ CHÚ THÍCH RÕ RÀNG ĐỂ KHÔNG BỊ NHẦM LẪN
/// 1.ĐĂNG NHẬP
/// 2.LẤY ID SINH VIÊN,UPDATE HỒ SƠ CÁ NHÂN ,UPLOAD PHOTOS
/// 3.ẤN VÀO GÓC HỌC TẬP
/// 4.THAO TÁC VỚI LỚP HỌC:BÀI GIẢNG,BÀI TẬP,TÀI LIỆU,THẢO LUẬN
/// 5.CHI TIẾT BÀI TẬP VÀ SINH VIÊN THÊM BÀI TẬP,Hủy bài tập VÀ DANH SÁCH BÀI TẬP ĐÃ NỘP
/// 6.SINH VIÊN CHỌN CHỨC NĂNG HỌC TRỰC TUYẾN
/// </summary>
namespace QLDayHocWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TrangSinhViensController : ControllerBase
    {
        private readonly DA5_QLdayhocContext _context;
        private readonly IWebHostEnvironment _env;
        public TrangSinhViensController(DA5_QLdayhocContext context, IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }
        #region 1 ĐĂNG NHẬP
        [HttpPost("login")]
        public IActionResult Login(sinhvienViewModels ad)
        {
            var us = _context.Sinhviens.Where(x => x.Masv == ad.Masv && x.Matkhau == ad.Matkhau).FirstOrDefault();
            return Ok(us);
        }
        #endregion

        #region 2. LẤY ID SINH VIÊN,UPDATE HỒ SƠ CÁ NHÂN ,UPLOAD PHOTOS
        [HttpGet("ChiTietSinhVien/{id}")]
        public IActionResult ChiTietSinhVien(long id)
        {
            var sinhvien =_context.Sinhviens.FirstOrDefault(x=>x.Masv==id);

            if (sinhvien == null)
            {
                return NotFound();
            }

            return Ok(sinhvien);
        }
        [HttpPut("UpdateHoSoCaNhan/{id}")]
        public IActionResult UpdateHoSoCaNhan(long? id, Sinhvien sinhvien)
        {
            if (id != sinhvien.Masv)
            {
                return new JsonResult("không tồn tại");
            }
            else
            {
                _context.Entry(sinhvien).State = EntityState.Modified;
                _context.SaveChangesAsync();
                return new JsonResult("Đã sửa thành công");
            }
        }

        [HttpPost("UploadPhotos")]
        public IActionResult UploadPhotos()
        {
            var httpRequest = Request.Form;
            var posted = httpRequest.Files[0];
            string filename = posted.FileName.ToString();
            var physicalPath = _env.ContentRootPath + "/Photos/sinhvien/" + Path.GetFileName(filename);
            using (var stream = new FileStream(physicalPath, FileMode.Create))
            {
                posted.CopyTo(stream);
            }
            return new JsonResult(filename);
        }
        //[HttpPut("UpdateSinhvien/{id}")]
        //public async Task<IActionResult> PutSinhvien(long id, Sinhvien sinhvien)
        //{
        //    if (id != sinhvien.Masv)
        //    {
        //        return BadRequest();
        //    }
        //    sinhvien.Quoctich = "Việt Nam";
        //    sinhvien.Tentruongdh = "Đại học SPKT Hưng Yên ";
        //    _context.Entry(sinhvien).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //       throw;
        //    }

        //    return new JsonResult("Đã sửa thành công");
        //}
        #endregion

        #region 3.ẤN VÀO GÓC HỌC TẬP
        //sinh viên khi ấn vào hóc học tập
        [HttpGet("gochoctap/{id}")]
        public IActionResult Joinlop(long id)
        {
            var rs = from t1 in _context.Hoctaps.Where(x => x.Masv == id)
                     join t5 in _context.Sinhviens on t1.Masv equals t5.Masv
                     join t2 in _context.Giangdays on t1.Magiangday equals t2.Magiangday
                     join t3 in _context.Hocphans on t2.Mahp equals t3.Mahp
                     join t4 in _context.Lophocs on t2.Malop equals t4.Malop
                     join t6 in _context.Giaoviens on t1.Magv equals t6.Magv
                     select new
                     {
                         t1.Magiangday,
                         t1.Masv,
                         t1.Mahoctap,
                         t2.Malop,
                         t2.Mahp,
                         t2.Tiethoc,
                         t2.Namhoc,
                         t2.Ghichu,
                         t3.Tenhp,
                         t4.Tenlop,
                         t5.Tensv,
                         t6.Tengv
                     };
            return Ok(rs.ToList());
        }
        #endregion


        #region 4.THAO TÁC VỚI LỚP HỌC:BÀI GIẢNG,BÀI TẬP,TÀI LIỆU,THẢO LUẬN
        [HttpGet("baigiangsinhvien/{id}")]
        public IActionResult baigiangsinhvien(long id)
        {
            var rs = from t1 in _context.Hoctaps.Where(x => x.Mahoctap == id)
                     join t2 in _context.Giangdays on t1.Magiangday equals t2.Magiangday
                     join t6 in _context.Baigiangs on t2.Magiangday equals t6.Magiangday
                     select new
                     {
                         t1.Magiangday,
                         t1.Masv,
                         t1.Mahoctap,
                         t2.Malop,
                         t2.Mahp,
                         //  t2.Tiethoc,
                         t2.Ghichu,
                         t2.Namhoc,

                         t6.Nguoitao,
                         t6.Tieude,
                         t6.Noidung,
                         t6.Ngaytao,
                         t6.Filelink,
                         t6.Sotiet

                     };
            return Ok(rs.ToList());
        }

        [HttpGet("tailieusinhvien/{id}")]
        public IActionResult tailieusinhvien(long id)
        {
            var rs = from t1 in _context.Hoctaps.Where(x => x.Mahoctap == id)
                     join t2 in _context.Giangdays on t1.Magiangday equals t2.Magiangday
                     join t6 in _context.Tailieus on t2.Magiangday equals t6.Magiangday
                     select new
                     {
                         t1.Magiangday,
                         t1.Masv,
                         t1.Mahoctap,
                         t2.Malop,
                         t2.Mahp,
                         t2.Tiethoc,
                         t2.Namhoc,
                         t2.Ghichu,
                         t6.Nguoitao,
                         t6.Tentailieu,
                         t6.Mota,
                         t6.Ngaytao,
                         t6.Filelink,
                         t6.Filename
                     };
            return Ok(rs.ToList());
        }
        [HttpGet("baitapsinhvien/{id}")]
        public IActionResult baitapsinhvien(long id)
        {
            var rs = from t1 in _context.Hoctaps.Where(x => x.Mahoctap == id)
                     join t2 in _context.Giangdays on t1.Magiangday equals t2.Magiangday
                     join t6 in _context.Baitaps on t2.Magiangday equals t6.Magiangday
                     select new
                     {
                         t1.Magiangday,
                         t1.Masv,
                         t1.Mahoctap,
                         t2.Malop,
                         t2.Mahp,
                         t2.Namhoc,
                         t6.Nguoitao,
                         t6.Tenbt,
                         t6.Ngaytao,
                         t6.Filelink,
                         t6.Filename,
                         t6.Mabt
                     };
            return Ok(rs.ToList());
        }
        [HttpGet("thaoluansinhvien/{id}")]
        public IActionResult thaoluansinhvien(long id)
        {
            var rs = from t1 in _context.Hoctaps.Where(x => x.Mahoctap == id)
                     join t2 in _context.Giangdays on t1.Magiangday equals t2.Magiangday
                     join t6 in _context.Thaoluans on t2.Magiangday equals t6.Magiangday
                     select new
                     {
                         t1.Magiangday,
                         t1.Masv,
                         t1.Mahoctap,
                         t2.Malop,
                         t2.Mahp,
                         t6.Nguoitao,
                         t6.Tieude,
                         t6.Noidung,
                         t6.Ngaytao,
                     };
            return Ok(rs.ToList());
        }
        #endregion

        #region 5. CHI TIẾT BÀI TẬP VÀ SINH VIÊN THÊM BÀI TẬP,Hủy bài tập VÀ DANH SÁCH BÀI TẬP ĐÃ NỘP
        [HttpGet("ChiTietBaiTap/{id}")]
        public IActionResult ChiTietBaiTap(long id)
        {
            var rs = _context.Baitaps.Where(x => x.Mabt == id).FirstOrDefault();
            return Ok(rs);
        }
        /// <summary>
        /// hiển thị bài tập sinh viên đã nộp
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BaiTapDaNop/{id}&&{masv}")]
        public IActionResult BaiTapDaNop(long id,long masv)
        {
            var rs = _context.Nopbaitaps.Where(x => x.Mabt == id && x.Masv == masv && x.Isdelete != true).ToList();
            return Ok(rs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        [HttpPost("ThemBaiTap")]
        public IActionResult thembaitap(Nopbaitap n)
        {
            try
            {
                n.Isdelete = false;
                n.Ngaytao = DateTime.Now;
                n.Tieude = "đã nộp 1 bài tập : ";
                _context.Nopbaitaps.Add(n);
                _context.SaveChanges();
                return new JsonResult("Đã nộp bài tập.");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [Route("SaveFile")]
        [HttpPost]

        public JsonResult SaveFile()
        {
            var httpRequest = Request.Form;
            try
            {
                var posted = httpRequest.Files[0];
                string filename = posted.FileName.ToString();
                var physicalPath = _env.ContentRootPath + "/Photos/Luubaitap/" + Path.GetFileName(filename);
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    posted.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("tiep tuc loi");
            }

        }
        [HttpDelete("HuyBaiTap/{id}")]
        public IActionResult HuyBaiTap(long id)
        {
            var nopbt = _context.Nopbaitaps.Find(id);
            if (nopbt == null)
            {
                return NotFound();
            }
            nopbt.Isdelete = true;
            _context.Nopbaitaps.Update(nopbt);
             _context.SaveChanges();

            return NoContent();
        }
        #endregion


        #region 6. SINH VIÊN CHỌN CHỨC NĂNG HỌC TRỰC TUYẾN
        [HttpPost("HocTrucTuyen")]
        public IActionResult HocTrucTuyen(Dictionary<string, object> data)
        {
            PaginationViewModel paginationViewModel = new PaginationViewModel();
            try
            {
                int page = int.Parse(data["page"].ToString());
                int pageSize = int.Parse(data["pageSize"].ToString());
                var nameSearch = "";
                if (data.ContainsKey("nameSearch") && !string.IsNullOrEmpty(data["nameSearch"].ToString().Trim()))
                    nameSearch = data["nameSearch"].ToString().Trim().ToLower();
                paginationViewModel.Page = page;
                paginationViewModel.PageSize = pageSize;
                paginationViewModel.TotalItems = _context.Giangdays.Where(x => x.Malop.ToString().Contains(nameSearch)).Count();

                var model = from t1 in _context.Giangdays.ToList()
                            join t2 in _context.Hocphans on t1.Mahp equals t2.Mahp
                            join t3 in _context.Giaoviens on t1.Magv equals t3.Magv
                            join t4 in _context.Lophocs on t1.Malop equals t4.Malop
                            select new
                            {
                                t1.Magiangday,
                                t1.Anhdaidien,
                                t1.Magv,
                                t1.Malop,
                                t1.Mahp,
                                t1.Namhoc,
                                t1.Ghichu,
                                t1.Tiethoc,
                                t2.Tenhp,
                                t2.Code,
                                t3.Tengv,
                                t4.Tenlop

                            };

                string sortByName = "";
                if (data.ContainsKey("sortByName") && !string.IsNullOrEmpty(data["sortByName"].ToString().Trim()))
                    sortByName = data["sortByName"].ToString().Trim().ToLower();
                switch (sortByName)
                {
                    case "asc":
                        model = model.OrderBy(x => x.Tenlop).ToList();
                        break;

                    case "desc":
                        model = model.OrderByDescending(x => x.Tenlop).ToList();
                        break;
                }
                //string sortByCreatedDate = "";
                //if (data.ContainsKey("sortByCreatedDate") && !string.IsNullOrEmpty(data["sortByCreatedDate"].ToString().Trim()))
                //    sortByCreatedDate = data["sortByCreatedDate"].ToString().Trim().ToLower();
                //switch (sortByCreatedDate)
                //{
                //    case "asc":
                //        model = model.OrderBy(x => x.Ngaytao).ToList();
                //        break;

                //    case "desc":
                //        model = model.OrderByDescending(x => x.Ngaytao).ToList();
                //        break;
                //}
                paginationViewModel.Data = model.Where(x => x.Malop.ToString().ToLower().IndexOf(nameSearch) >= 0).Skip((page - 1) * pageSize).Take(pageSize);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Ok(paginationViewModel);
        }
        #endregion
    }
}
