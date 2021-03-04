using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwndWeb.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwndWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        [HttpGet("emps")]
        public List<Employee> Get()
        {
            using NORTHWNDContext db = new
               NORTHWNDContext();
            return db.Employees.ToList();
        }
    }
}
