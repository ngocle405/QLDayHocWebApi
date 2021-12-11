using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLDayHocWebApi.Models;
using QLDayHocWebApi.ViewModels.Common;
using QLDayHocWebApi.ViewModels.Giaovien;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
/* CREATEDBY: LÊ THANH NGỌC (27/11/2021)
 * XỬ LÝ NGHIỆP VỤ BÊN PHÍA GIÁO VIÊN :
 * 1.ĐĂNG NHẬP,ĐĂNG XUẤT
 * 2 LẤY THÔNG TIN GIÁO VIÊN,UPLOAD HỒ SƠ,UPLOAD PHOTOS
 * 3.KHI ẤN VÀO 'LỚP HỌC TRỰC TUYẾN'.
 * 3.(CHÍNH) Hiển thị các lớp học giảng dạy có mã giáo viên đó ( Khi ấn vào góc học tập,Thêm lớp,xóa lớp )
 * 4.THỰC HIỆN CHỨC NĂNG KHI TRUY CẬP LỚP (hiển thị các sinh viên trong lớp,bài giảng,tài liệu,bài tập,thảo luận)
 * 5.(chính)Khi ấn vào 1 lớp sẽ hiển thị thông tin lớp học gồm thông tin chung,giảng dạy,tài liệu,bài tập ,thảo luận
 * 
 * 
 * 
 * */
namespace QLDayHocWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrangGiaoViensController : ControllerBase
    {
        private readonly DA5_QLdayhocContext _context;
        private readonly IWebHostEnvironment _env;
        public TrangGiaoViensController(DA5_QLdayhocContext context, IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }
        #region 1.ĐĂNG NHẬP
        [HttpPost("login")]
        public IActionResult Login(giaovienViewModels gv)
        {
            var us = _context.Giaoviens.Where(x => x.Magv == gv.Magv && x.Matkhau == gv.Matkhau).FirstOrDefault();
            return Ok(us);
        }
        #endregion

        #region 2. LẤY ID GIÁO VIÊN , UPDATE THÔNG TIN , UPLOAD PHOTOS
        [HttpGet("ChiTietGiaoVien/{id}")]
        public IActionResult ChiTietGiaoVien(long id)
        {
            var giaovien = _context.Giaoviens.FirstOrDefault(x=>x.Magv==id);

            if (giaovien == null)
            {
                return NotFound();
            }
            return Ok(giaovien);
        }
        [HttpPut("UpdateGiaovien/{id}")]
        public IActionResult UpdateGiaovien(long id,Giaovien giaovien)
        {
            try
            {
                if (id == giaovien.Magv)
                {
                    _context.Giaoviens.Update(giaovien);
                    _context.SaveChanges();
                }
               
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return new JsonResult("Update thành công.");
        }
        [HttpPost("UploadPhotos")]
        public IActionResult UploadPhotos()
        {

            var httpRequest = Request.Form;

            var posted = httpRequest.Files[0];
            string filename = posted.FileName.ToString();
            var physicalPath = _env.ContentRootPath + "/Photos/Giaovien/" + Path.GetFileName(filename);

            using (var stream = new FileStream(physicalPath, FileMode.Create))
            {
                posted.CopyTo(stream);
            }
            return new JsonResult(filename);

        }

        
       
        #endregion

        #region 3. KHI ẤN VÀO HỌC TRỰC TUYẾN
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

        #region 4.(CHÍNH) Hiển thị các lớp học giảng dạy có mã giáo viên đó ( Khi ấn vào góc học tập,Thêm lớp,xóa lớp )
        // GET: api/Dayhocs/5
        [HttpGet("DanhSachLopGiangDayTrucTuyen/{id}")]
        public IActionResult DanhSachLopGiangDayTrucTuyen(long id)
        {
            var rs = from t1 in _context.Giangdays.Where(x => x.Magv == id && x.Isdelete != true)
                     join t2 in _context.Hocphans on t1.Mahp equals t2.Mahp
                     select new
                     {
                         t1.Magiangday,
                         t1.Magv,
                         t1.Malop,
                         t1.Mahp,
                         t1.Isdelete,
                         t1.Namhoc,
                         t1.Ghichu,
                         t2.Tenhp,
                     };
            return Ok(rs.ToList());
        }
        [HttpPost("ThemlopGiangDay")]
        public IActionResult ThemlopGiangDay(Giangday giangday)
        {
            try
            {
                _context.Giangdays.Add(giangday);
                 _context.SaveChanges();
                return new JsonResult("Đã thêm lớp học trực tuyến thành công");
            }
            catch (Exception ex)
            {
                return BadRequest("có lỗi xảy ra");
            }
        }

        // DELETE: api/Dayhocs/5
        [HttpDelete("DeleteGiangday/{id}")]
        public IActionResult DeleteGiangday(long id)
        {
            var giangday = _context.Giangdays.Find(id);
            giangday.Isdelete = true;
            if (giangday == null)
            {
                return NotFound();
            }

            _context.Giangdays.Update(giangday);
            _context.SaveChanges();

            return NoContent();
        }
        #endregion

        #region 5.(chính)Khi ấn vào 1 lớp sẽ hiển thị thông tin lớp học gồm thông tin chung,giảng dạy,tài liệu,bài tập ,thảo luận
        /// <summary>
        /// xem chi tiết lớp giảng dạy trực tuyến và thao tác trên lớp đó
        /// </summary>
        /// <param name="id">mã lớp giảng dạy</param>
        /// <returns>chi tiết lớp giảng dạy đó</returns>
        [HttpGet("XemChiTietLopGiangDay/{id}")]
        public IActionResult XemChiTietLopGiangDay(long id)
        {
            var rs = from t1 in _context.Giangdays.Where(x => x.Magiangday == id)
                     join t2 in _context.Hocphans on t1.Mahp equals t2.Mahp
                     select new
                     {
                         t1.Magiangday,
                         t1.Anhdaidien,
                         t1.Magv,
                         t1.Malop,
                         t1.Mahp,
                         t1.Namhoc,
                         t2.Tenhp,
                         t2.Code
                     };
            return Ok(rs.SingleOrDefault());
        }
        #endregion

        /// <summary>
        /// 5: THAO TÁC VỚI 1 LỚP HỌC GIẢNG DẠY/
        /// SAU KHI ĐÃ TRUY CẬP VÀO LỚP GIẢNG DẠY TRỰC TUYẾN SẼ THỰC HIỆN CACSC THAO TÁC :
        /// 5.1.THAO TÁC VỚI SINH VIÊN (hIỂN THỊ,THÊM SINH VIÊN VÀO LỚP)
        /// 5.2.THAO TÁC VỚI BÀI GIẢNG (THÊM , XÓA)
        /// 5.3.THAO TÁC VỚI TÀI LIỆU (THÊM,XÓA)
        /// 5.4.THAO TÁC VỚI BÀI TẬP (THÊM ,XÓA,XEM BÀI TẬP SINH VIÊN ĐÃ NỘP)
        /// 5.5.THAO TÁC VỚI THẢO LUẬN (THÊM ,XÓA)
        /// </summary>
       
        #region  5.2.giáo viến Thao tác với bài giảng( hiển thị,thêm ,xóa )
        //baigiang

        [HttpGet("DanhSachBaiGiang/{id}")]
        public IActionResult DanhSachBaiGiang(long id)
        {
            var rs = _context.Baigiangs.Where(x => x.Magiangday == id).ToList();
            return Ok(rs);
        }

        [HttpPost("ThemBaigiang")]
        public IActionResult PostBaigiang(Baigiang baigiang)
        {
            baigiang.Ngaytao = DateTime.Now;
            _context.Baigiangs.Add(baigiang);
            _context.SaveChanges();
            return new JsonResult("đã thêm bài giảng");
        }
        [HttpDelete("deletebaigiang/{id}")]
        public IActionResult deletebaigiang(long id)
        {
            var lophoc =  _context.Baigiangs.Find(id);
            if (lophoc == null)
            {
                return NotFound();
            }
            _context.Baigiangs.Remove(lophoc);
             _context.SaveChanges();
            return NoContent();
        }
        #endregion

        #region 5.3. GIÁO VIÊN THAO TÁC VỚI TÀI LIỆU (đầu vào  :mã giáo viên)
       
        [HttpGet("DanhSachTaiLieu/{id}")]
        public IActionResult DanhSachTaiLieu(long id)
        {
            var rs = _context.Tailieus.Where(x => x.Magiangday == id).ToList();
            return Ok( rs);
        }
       
        [HttpPost("ThemTaiLieu")]
        public IActionResult ThemTaiLieu(Tailieu tailieu)
        {
            tailieu.Ngaytao = DateTime.Now;
            if (tailieu.Filename == null)
            {
                tailieu.Filename = "không có nội dung tailieu";
            }
            _context.Tailieus.Add(tailieu);
            _context.SaveChanges();

            return new JsonResult("Đã thêm tài liệu thành công");
        }

        /// <summary>
        /// ADMIN  - xóa tài liệu
        /// </summary>
        /// <param name="id">id tài liệu</param>
        /// <returns>NULL</returns>
        // DELETE: api/Files/5
        [HttpDelete("DeleteTailieu/{id}")]
        public IActionResult DeleteTailieu(long id)
        {
            var file = _context.Tailieus.Find(id);
            if (file == null)
            {
                return NotFound();
            }

            _context.Tailieus.Remove(file);
            _context.SaveChanges();

            return NoContent();
        }

        private bool FileExists(long id)
        {
            return _context.Tailieus.Any(e => e.Matailieu == id);
        }
        
        [HttpPost("UploadTaiLieu")]

        public JsonResult SaveFile()
        {
            var httpRequest = Request.Form;
            try
            {
                var posted = httpRequest.Files[0];
                string filename = posted.FileName.ToString();
                var physicalPath = _env.ContentRootPath + "/Photos/tailieu/" + Path.GetFileName(filename);

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
        #endregion

        #region 5.4.GIÁO VIÊN THAO TÁC VỚI BÀI TẬP(đầu vào : mã giáo viên)
        
        [HttpGet("DanhSachBaiTap/{id}")]
        public IActionResult DanhSachBaiTap(long id)
        {
            var rs = _context.Baitaps.Where(x => x.Magiangday == id).ToList();
            return Ok(rs);
        }
      
        [HttpPost("ThemBaiTap")]
        public IActionResult ThemBaiTap(Baitap bt)
        {
            bt.Ngaytao = DateTime.Now;
            bt.Tieude = "đã đăng một bài tập";
            bt.Hethanluc = "23:59";
            if (bt.Filename == null)
            {
                bt.Filename = "không có nội dung bài tập";
            }
            _context.Baitaps.Add(bt);
             _context.SaveChanges();

            return new JsonResult("Đã thêm bài tập thành công");
        }

        // DELETE: api/Files/5
        [HttpDelete("DeleteBaitap/{id}")]
        public IActionResult DeleteFile(long id)
        {
            var file = _context.Baitaps.Find(id);
            if (file == null)
            {
                return NotFound();
            }

            _context.Baitaps.Remove(file);
             _context.SaveChanges();

            return NoContent();
        }
       
        [HttpPost("UploadBaiTap")]

        public JsonResult UploadBaiTap()
        {

            var httpRequest = Request.Form;
            try
            {

                var posted = httpRequest.Files[0];
                string filename = posted.FileName.ToString();
                var physicalPath = _env.ContentRootPath + "/Photos/baitap/" + Path.GetFileName(filename);

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
        #endregion

        #region 5.5 GIÁO VIÊN THAO TÁC VỚI THẢO LUẬN (ĐẦU VÀO :MÃ GIÁO VIÊN)
       
        [HttpGet("DanhSachThaoluan/{id}")]
        public IActionResult DanhSachThaoluan(long id)
        {
            var rs = _context.Thaoluans.Where(x => x.Magiangday == id).ToList();
            return Ok(rs);
        }
        
        [HttpPost("ThemThaoluan")]
        public IActionResult ThemThaoluan(Thaoluan Thaoluan)
        {
            Thaoluan.Ngaytao = DateTime.Now;
            _context.Thaoluans.Add(Thaoluan);
             _context.SaveChanges();
            return new JsonResult("đã thêm bài thảo luận");
        }
        [HttpDelete("DeleteThaoLuan/{id}")]
        public IActionResult DeleteThaoLuan(long id)
        {
            var file =  _context.Thaoluans.Find(id);
            if (file == null)
            {
                return NotFound();
            }

            _context.Thaoluans.Remove(file);
             _context.SaveChanges();

            return NoContent();
        }
        #endregion

        #region 6. load lớp học,load học phần phục vụ cho giáo viên thêm lớp học trực truyến
        /// <summary>
        /// createBy : Lê thanh ngọc (25/11/2021)
        /// mục đích : load lớp học,học phần cho phục vụ cho giáo viên thêm lớp học trực truyến.(lấy id và tên lớp);
        /// vị trí : giáo viên
        /// </summary>
        /// <returns></returns>
        
        [HttpGet("GetLophoc")]
        public IActionResult GetLophoc()
        {
            return  Ok( _context.Lophocs.ToList());
        }
       
        [HttpGet("GetHocphan")]
        public IActionResult GetHocphan()
        {
            return  Ok(_context.Hocphans.ToList());
        }
        #endregion

        #region 7. THAO TÁC VỚI SINH VIÊN (HIỂN THỊ SINH VIÊN CHƯA CÓ TRONG LỚP, HIỂN THỊ CÁC SINH VIÊN TRONG LỚP , THÊM SINH VIÊN VÀO LỚP TRỰC TUYẾN )

        //SINH VIÊN CHƯA CÓ TRONG LỚP
        [HttpPost("Sinhvienchuacotronglop")]
        public IActionResult Sinhvienduocthemvaolop(Dictionary<string, object> data)
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
                paginationViewModel.TotalItems = _context.Sinhviens.Where(x => x.Tensv.Contains(nameSearch)).Count();

                var model = _context.Sinhviens.ToList();
                string sortByName = "";
                if (data.ContainsKey("sortByName") && !string.IsNullOrEmpty(data["sortByName"].ToString().Trim()))
                    sortByName = data["sortByName"].ToString().Trim().ToLower();
                switch (sortByName)
                {
                    case "asc":
                        model = model.OrderBy(x => x.Tensv).ToList();
                        break;

                    case "desc":
                        model = model.OrderByDescending(x => x.Tensv).ToList();
                        break;
                }
                string sortByCreatedDate = "";
                if (data.ContainsKey("sortByCreatedDate") && !string.IsNullOrEmpty(data["sortByCreatedDate"].ToString().Trim()))
                    sortByCreatedDate = data["sortByCreatedDate"].ToString().Trim().ToLower();
                switch (sortByCreatedDate)
                {
                    case "asc":
                        model = model.OrderBy(x => x.Ngaysinh).ToList();
                        break;

                    case "desc":
                        model = model.OrderByDescending(x => x.Ngaysinh).ToList();
                        break;
                }
                paginationViewModel.Data = model.Where(x => x.Tensv.ToLower().IndexOf(nameSearch) >= 0).Skip((page - 1) * pageSize).Take(pageSize);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Ok(paginationViewModel); ;
        }
        //SINH VIÊN ĐÃ ĐƯỢC THÊM VÀO LỚP
        [HttpGet("Sinhvienduocthemvaolop/{id}")]
        public IActionResult Getgiangdaygiangday(long id)
        {
            var rs = from t1 in _context.Hoctaps.Where(x => x.Magiangday == id)//hien thị sv đã có trong lớp dạy
                     join t5 in _context.Sinhviens on t1.Masv equals t5.Masv
                     join t2 in _context.Giangdays on t1.Magiangday equals t2.Magiangday
                     join t3 in _context.Hocphans on t2.Mahp equals t3.Mahp
                     join t4 in _context.Lophocs on t2.Malop equals t4.Malop
                     select new
                     {
                         t1.Magiangday,
                         t1.Masv,
                         t1.Mahoctap,
                         t2.Malop,
                         t2.Mahp,
                         t3.Tenhp,
                         t4.Tenlop,
                         t5.Tensv,
                         t5.Anhdaidien,
                         t5.Chuyennganh,
                         t5.Ngaysinh
                     };
            return Ok(rs.ToList());
        }
        //
        [HttpPost("ThemSinhVienVaoLop")]
        public IActionResult add(Hoctap h)
        {
            //if (giangdayExists((long)h.Magiangday) && sinhvienExists((long)h.Masv))
            //{
            //    return new JsonResult("Sinh viên này đã tồn tại trong lớp học rồi .");
            //}
            //else
            //{
            try
            {
                _context.Hoctaps.Add(h);
                _context.SaveChanges();
                return new JsonResult("Đã thêm thành công sinh viên vào lớp.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //}
        }
        private bool sinhvienExists(long id)
        {
            return _context.Hoctaps.Any(e => e.Masv == id);
        }
        private bool giangdayExists(long id)
        {
            return _context.Hoctaps.Any(e => e.Magiangday == id);
        }
        #endregion

        #region 8. CHI TIẾT BÀI TẬP và DANH SÁCH BÀI TẬP SINH VIÊN ĐÃ NỘP
        /// <summary>
        /// danh sách bài tập đã nộp theo mã sinh viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpGet("ChiTietBaiTap/{id}")]
        public IActionResult ChiTietBaiTap(long id)
        {
            var rs = _context.Baitaps.Where(x => x.Mabt == id).FirstOrDefault();
            return Ok(rs);
        }

        //danh sách bài tập mà sinh viên đã nộp 
        
        [HttpGet("BaiTapDaNop/{id}")]
        public IActionResult baitapdanop(long id)
        {
            //load db nộp bài tập có mã bài tập đó
            var rs = _context.Nopbaitaps.Where(x => x.Mabt == id && x.Isdelete != true).ToList();
            return Ok(rs);
        }
        #endregion



        #region  9.CHI TIẾT SINH VIÊN ĐỂ LẤY ID(ADD)
        [HttpGet("ChiTietSinhVien/{id}")]
        public IActionResult ChiTietSinhVien(long id)
        {
            var sinhvien = _context.Sinhviens.FirstOrDefault(x => x.Masv == id);

            if (sinhvien == null)
            {
                return NotFound();
            }

            return Ok(sinhvien);
        }
        #endregion
    }
}
