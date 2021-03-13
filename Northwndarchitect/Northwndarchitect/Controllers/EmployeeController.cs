using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwndarchitect.CORE.Abstractions.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwndarchitect.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeOperations employee;
        public EmployeeController(IEmployeeOperations employee)
        {
            this.employee = employee;
        }
        [HttpGet]
        public IActionResult GetEmployee()
        {
            var result = employee.GetEmployees();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployeeid([FromRoute] int id)
        {
            var res = employee.GetEmpId(id);
            if (res == null)
                return BadRequest();
            return Ok(res);
        }
    }
}
