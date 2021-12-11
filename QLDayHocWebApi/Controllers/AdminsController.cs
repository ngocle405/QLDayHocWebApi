using Microsoft.AspNetCore.Mvc;
using QLDayHocWebApi.Models;
using QLDayHocWebApi.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/// <summary>
/// bảng admin
/// createBy:Lê thanh ngọc (24/11/2021)
/// </summary>
namespace QLDayHocWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly DA5_QLdayhocContext _context;
        public AdminsController(DA5_QLdayhocContext context)
        {
            _context = context;
        }
        // GET: api/<AdminsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username">username</param>
        ///<param name="password">password</param>
        /// <returns>trả ra thông tin admin</returns>
        [HttpPost("login")]
        public IActionResult Login(adminViewModels ad)
        {
            var us = _context.Admincps.Where(x => x.Username == ad.Username && x.Password == ad.Password).FirstOrDefault();
            return Ok(us);
        }
        // GET api/<AdminsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdminsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
