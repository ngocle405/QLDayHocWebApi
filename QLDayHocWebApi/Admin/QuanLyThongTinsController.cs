using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLDayHocWebApi.Models;
using QLDayHocWebApi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDayHocWebApi.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanLyThongTinsController : ControllerBase
    {
        private readonly DA5_QLdayhocContext _context;
        public QuanLyThongTinsController(DA5_QLdayhocContext context)
        {
            _context = context;
        }
        #region Quản Lý học Phần
        [HttpPost("DanhSachHocPhan")]
        public IActionResult DanhSachHocPhan(Dictionary<string, object> data)
        {
            // gọi các trường trong PaginationViewModel
            PaginationViewModel paginationViewModel = new PaginationViewModel();
            try
            {
                //ép kiểu cho page(trang),pagezise(độ dài trang)
                int page = int.Parse(data["page"].ToString());
                int pageSize = int.Parse(data["pageSize"].ToString());
                //khởi tạo tìm kiếm
                string nameSearch = "";
                //kiểm tra đầu vào
                if (data.ContainsKey("nameSearch") && !string.IsNullOrEmpty(data["nameSearch"].ToString().Trim()))
                    nameSearch = data["nameSearch"].ToString().Trim().ToLower();
                //build giá trị cho các trường
                paginationViewModel.Page = page;
                paginationViewModel.PageSize = pageSize;
                //trả ra kết quả
                paginationViewModel.TotalItems = _context.Hocphans.Where(x => x.Tenhp.ToLower().IndexOf(nameSearch) >= 0).Count();
                var model = _context.Hocphans.Where(x => x.Isdelete != true).ToList();//hiển thị danh sách học phần
                //tìm kiếm theo thứ tự
                string sortByName = "";
                if (data.ContainsKey("sortByName") && !string.IsNullOrEmpty(data["sortByName"].ToString().Trim()))
                    sortByName = data["sortByName"].ToString().Trim().ToLower();
                switch (sortByName)
                {
                    case "asc":
                        model = model.OrderBy(x => x.Tenhp).ToList();
                        break;

                    case "desc":
                        model = model.OrderByDescending(x => x.Tenhp).ToList();
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
                paginationViewModel.Data = model.Where(x => x.Tenhp.ToLower().IndexOf(nameSearch) >= 0).Skip((page - 1) * pageSize).Take(pageSize);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Ok(paginationViewModel);
        }
        [HttpGet("ChiTietHocPhan/{id}")]
        public IActionResult ChiTietHocPhan(int id)
        {
            var rs = _context.Hocphans.SingleOrDefault(x => x.Mahp == id);
            return Ok(rs);
        }
        /// <summary>
        /// admin:thêm học phần
        /// </summary>
        /// <param name="hp">đối tượng hp</param>
        /// <returns>danh sách học phần</returns>
        // POST api/<HocphansController>
        [HttpPost("ThemHocPhan")]
        public JsonResult ThemHocPhan(Hocphan hp)
        {
            try
            {
                var data = _context.Hocphans.Add(hp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            _context.SaveChanges();
            return new JsonResult("đã thêm thành công");
        }
        /// <summary>
        ///  admin:Sửa học phần
        /// </summary>
        /// <param name="id">id sinh viên</param>
        /// <param name="hp">đối tượng sv</param>
        /// <returns></returns>
        // PUT api/<HocphansController>/5
        [HttpPut("UpdateHocPhan/{id}")]
        public JsonResult UpdateHocPhan(long id, Hocphan hp)
        {
            if (id > 0)
            {
                _context.Hocphans.Update(hp);
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return new JsonResult("Đã sửa thành công.");
        }
        /// <summary>
        /// admin - xóa học phần
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<HocphansController>/5
        [HttpDelete("DeleteHocPhan/{id}")]
        public JsonResult DeleteHocPhan(long id)
        {
            var rs = _context.Hocphans.Find(id);
            rs.Isdelete = true;
            _context.Hocphans.Update(rs);
            _context.SaveChanges();
            return new JsonResult("đã xóa");
        }
        #endregion

        #region  QUẢN LÝ GIÁO VIÊN
        [HttpPost("DanhSachGiaoVien")]
        public IActionResult DanhSachGiaoVien(Dictionary<string, object> data)
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
                paginationViewModel.TotalItems = _context.Giaoviens.Where(x => x.Tengv.Contains(nameSearch)).Count();
                var model = _context.Giaoviens.ToList();
                string sortByName = "";
                if (data.ContainsKey("sortByName") && !string.IsNullOrEmpty(data["sortByName"].ToString().Trim()))
                    sortByName = data["sortByName"].ToString().Trim().ToLower();
                switch (sortByName)
                {
                    case "asc":
                        model = model.OrderBy(x => x.Tengv).ToList();
                        break;
                    case "desc":
                        model = model.OrderByDescending(x => x.Tengv).ToList();
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
                paginationViewModel.Data = model.Where(x => x.Tengv.ToLower().IndexOf(nameSearch) >= 0).Skip((page - 1) * pageSize).Take(pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Ok(paginationViewModel);
        }
        [HttpGet("ChiTietGiaoVien/{id}")]
        public async Task<ActionResult<Giaovien>> ChiTietGiaoVien(long id)
        {
            var giaovien = await _context.Giaoviens.FindAsync(id);

            if (giaovien == null)
            {
                return NotFound();
            }
            return giaovien;
        }

        /// <summary>
        /// Admin - Thêm mới giáo viên
        /// </summary>
        /// <param name="giaovien">đối tượng gv</param>
        /// <returns>danh sách giáo viên</returns>
        [HttpPost("ThemGiaoVien")]
        public async Task<ActionResult<Giaovien>> ThemGiaoVien(Giaovien giaovien)
        {
            //check trùng mã
            if (GiaovienExists(giaovien.Magv))
            {
                return new JsonResult("Mã giáo viên đã bị trùng vui lòng nhập lại .");
                //   return Conflict("");
            }
            else
            {
                giaovien.Anhdaidien = "anonymous.png";
                giaovien.Isdelete = false;

                _context.Giaoviens.Add(giaovien);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return new JsonResult("Đã thêm thành công .");
        }
        /// <summary>
        /// admin - xóa giáo viên
        /// </summary>
        /// <param name="id">id giáo viên</param>
        /// <returns>NULL</returns>
        // DELETE: api/Giaoviens/5
        [HttpDelete("DeleteGiaoVien/{id}")]
        public async Task<ActionResult<Giaovien>> DeleteGiaovien(long id)
        {
            var giaovien = await _context.Giaoviens.FindAsync(id);
            if (giaovien == null)
            {
                return NotFound();
            }

            _context.Giaoviens.Remove(giaovien);
            await _context.SaveChangesAsync();

            return giaovien;
        }
        //ktra mã trùng
        private bool GiaovienExists(long id)
        {
            return _context.Giaoviens.Any(e => e.Magv == id);
        }
        #endregion

        #region : QUẢN LÝ LỚP 
        [HttpPost("DanhSachLop")]
        public IActionResult DanhSachLop(Dictionary<string, object> data)
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
                paginationViewModel.TotalItems = _context.Lophocs.Where(x => x.Tenlop.Contains(nameSearch)).Count();

                var model = _context.Lophocs.Where(x => x.Isdelete != true).ToList();
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
                paginationViewModel.Data = model.Where(x => x.Tenlop.ToLower().IndexOf(nameSearch) >= 0).Skip((page - 1) * pageSize).Take(pageSize);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Ok(paginationViewModel);
        }


        // GET api/<LophocsController>/5
        [HttpGet("ChiTietLop/{id}")]
        public IActionResult ChiTietLop(long id)
        {
            var lophoc = _context.Lophocs.Find(id);

            if (lophoc == null)
            {
                return NotFound();
            }

            return Ok(lophoc);
        }



        // POST api/<LophocsController>
        [HttpPost("ThemLop")]
        public IActionResult ThemLop(Lophoc lophoc)
        {
            // ckeck null
           
            if (string.IsNullOrEmpty(lophoc.Tenlop))
                return new JsonResult("Bạn chưa nhập tên lớp.");
            if (string.IsNullOrEmpty(lophoc.Siso))
                return new JsonResult("Bạn chưa nhập sĩ số lớp.");
            if (string.IsNullOrEmpty(lophoc.Gvcn))
                return new JsonResult("Bạn chưa nhập GVCN.");
            if (string.IsNullOrEmpty(lophoc.Khoa))
                return new JsonResult("Bạn chưa nhập khoa.");

            lophoc.Isdelete = false;
            _context.Lophocs.Add(lophoc);
            try
            {
                _context.SaveChanges();
                return new JsonResult("Đã thêm thành công .");
            }
            catch
            {
                
                //ckeck trùng mã
                if (LophocExists(lophoc.Malop))
                {
                    return new JsonResult("Mã lớp đã bị trùng vui lòng nhập lại .");
                    //   return Conflict("");
                }
                return new JsonResult("Có lỗi xảy ra,vui lòng liên hệ với Dev:Lê Thanh Ngọc để được hỗ trợ.");
            }
        }
        /// <summary>
        /// admin - sửa lớp học
        /// </summary>
        /// <param name="id">id lớp</param>
        /// <param name="lophoc">obj lớp</param>
        /// <returns></returns>
        // PUT api/<LophocsController>/5
        [HttpPut("UpdateLop/{id}")]
        public JsonResult PutLophoc(long id, Lophoc lophoc)
        {
            _context.Entry(lophoc).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return new JsonResult("Update thành công.");
        }

        // DELETE api/<LophocsController>/5
        [HttpDelete("DeleteLop/{id}")]
        public async Task<ActionResult<Lophoc>> DeleteLophoc(long id)
        {
            var lophoc = await _context.Lophocs.FindAsync(id);
            if (lophoc == null)
            {
                return NotFound();
            }
            lophoc.Isdelete = true;
            _context.Lophocs.Update(lophoc);
            await _context.SaveChangesAsync();
            return lophoc;
        }
        //ktra mã trùng

        private bool LophocExists(long id)
        {
            return _context.Lophocs.Any(e => e.Malop == id);
        }
        #endregion

        #region QUẢN LÝ SINH VIÊN
        [HttpPost("DanhSachSinhVien")]
        public IActionResult DanhSachSinhVien(Dictionary<string, object> data)
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

                var model = _context.Sinhviens.Where(x => x.Isdelete != true).ToList();
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
            return Ok(paginationViewModel);
        }
        /// <summary>
        /// xem chi tiết sinh viên
        /// </summary>
        /// <param name="id">ID của sinh viên</param>
        /// <returns>danh sách sv</returns>
        // GET: api/Sinhviens/5
        [HttpGet("ChiTietSinhVien/{id}")]
        public async Task<ActionResult<Sinhvien>> ChiTietSinhVien(long id)
        {
            var sinhvien = await _context.Sinhviens.FindAsync(id);

            if (sinhvien == null)
            {
                return NotFound();
            }

            return sinhvien;
        }

        /// <summary>
        /// update sinh viên
        /// </summary>
        /// <param name="id">mã sinh viên</param>
        /// <param name="sinhvien">đối tượng sinh viên</param>
        /// <returns>danh sách sinh viên đã sửa</returns>
        // PUT: api/Sinhviens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateSinhVien/{id}")]
        public async Task<IActionResult> UpdateSinhVien(long id, Sinhvien sinhvien)
        {
            if (id != sinhvien.Masv)
            {
                return BadRequest();
            }
            sinhvien.Quoctich = "Việt Nam";
            sinhvien.Tentruongdh = "Đại học SPKT Hưng Yên ";
            _context.Entry(sinhvien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SinhvienExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("Đã sửa thành công");
        }

        /// <summary>
        /// thêm mới 1 sinh viên
        /// </summary>
        /// <param name="sinhvien">đối tượng sinh viên</param>
        /// <returns>danh sách sinh viên đã thêm</returns>

        [HttpPost("ThemSinhVien")]
        public async Task<ActionResult<Sinhvien>> ThemSinhVien(Sinhvien sinhvien)
        {
            sinhvien.Quoctich = "Việt Nam";
            sinhvien.Tentruongdh = "Đại học SPKT Hưng Yên ";
            sinhvien.Anhdaidien = "anonymous.png";
            _context.Sinhviens.Add(sinhvien);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                //check trùng mã
                if (SinhvienExists(sinhvien.Masv))
                {
                    return new JsonResult("Mã sinh viên đã tồn tại.");
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("Đã thêm thành công");
        }
        /// <summary>
        /// xóa 1 sinh viên
        /// </summary>
        /// <param name="id">mã sinh viên</param>
        /// <returns>null</returns>
        // DELETE: api/Sinhviens/5
        [HttpDelete("DeleteSinhvien/{id}")]
        public async Task<IActionResult> DeleteSinhvien(long id)
        {
            var sinhvien = await _context.Sinhviens.FindAsync(id);
            if (sinhvien == null)
            {
                return NotFound();
            }
            sinhvien.Isdelete = true;
            _context.Sinhviens.Update(sinhvien);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        /// <summary>
        /// check trùng mã
        /// </summary>
        /// <param name="id">mã sinh viên</param>
        /// <returns></returns>
        private bool SinhvienExists(long id)
        {
            return _context.Sinhviens.Any(e => e.Masv == id);
        }
        #endregion

        #region : QUẢN LÝ TÀI LIỆU GIÁO VIÊN ĐÃ UPLOAD
        [HttpPost("DanhSachTaiLieu")]
        public IActionResult Pagination(Dictionary<string, object> data)
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
                paginationViewModel.TotalItems = _context.Tailieus.Where(x => x.Tentailieu.Contains(nameSearch)).Count();

                var model = _context.Tailieus.ToList();
                string sortByName = "";
                if (data.ContainsKey("sortByName") && !string.IsNullOrEmpty(data["sortByName"].ToString().Trim()))
                    sortByName = data["sortByName"].ToString().Trim().ToLower();
                switch (sortByName)
                {
                    case "asc":
                        model = model.OrderBy(x => x.Tentailieu).ToList();
                        break;

                    case "desc":
                        model = model.OrderByDescending(x => x.Tentailieu).ToList();
                        break;
                }
                string sortByCreatedDate = "";
                if (data.ContainsKey("sortByCreatedDate") && !string.IsNullOrEmpty(data["sortByCreatedDate"].ToString().Trim()))
                    sortByCreatedDate = data["sortByCreatedDate"].ToString().Trim().ToLower();
                switch (sortByCreatedDate)
                {
                    case "asc":
                        model = model.OrderBy(x => x.Ngaytao).ToList();
                        break;

                    case "desc":
                        model = model.OrderByDescending(x => x.Ngaytao).ToList();
                        break;
                }
                paginationViewModel.Data = model.Where(x => x.Tentailieu.ToLower().IndexOf(nameSearch) >= 0).Skip((page - 1) * pageSize).Take(pageSize);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Ok(paginationViewModel);
        }
        [HttpDelete("DeleteTailieu/{id}")]
        public async Task<IActionResult> DeleteTailieu(long id)
        {
            var file = await _context.Tailieus.FindAsync(id);
            if (file == null)
            {
                return NotFound();
            }

            _context.Tailieus.Remove(file);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region QUẢN LÝ LỚP HỌC TRỰC TUYẾN CỦA GIÁO VIÊN

        #endregion

        #region LOAD LỚP HỌC
        [Route("GetLophoc")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lophoc>>> GetLophoc()
        {
            return await _context.Lophocs.ToListAsync();
        }
        #endregion
    }
}
