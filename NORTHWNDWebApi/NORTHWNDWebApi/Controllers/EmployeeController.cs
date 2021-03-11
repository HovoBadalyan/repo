using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NORTHWNDWebApi.Models.DB;
using NORTHWNDWebApi.NORTHWNDfilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NORTHWNDWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly NORTHWNDContext _dbContext;

        public EmployeeController(NORTHWNDContext context)
        {
            _dbContext = context;
        }

        //read
        [HttpGet]
        public IActionResult GetEmployee()
        {
            IEnumerable<Employee> employees;
            employees = _dbContext.Employees.ToList();
            return Ok(employees);

        }
        //read
        [HttpGet("{id}")]
        public IActionResult GetEmpid([FromRoute] int id)
        {
            Employee employee;
            employee = _dbContext.Employees.Find(id);
            if (employee == null)
            {
                return BadRequest();
            }
            return Ok(employee);
        }

        //create
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return Created("", employee);
        }

        //update
        [HttpPut]
        public IActionResult EditEmp([FromBody] EmployeeFilter filter)
        {
            var empedit = _dbContext.Employees.Find(filter.EmployeeId);
            if (empedit == null)
            {
                return BadRequest();
            }
            empedit.Address = filter.Address;
            empedit.BirthDate = filter.BirthDate;
            empedit.City = filter.City;
            empedit.Country = filter.Country;
            empedit.Extension = filter.Extension;
            empedit.FirstName = filter.FirstName;
            empedit.HireDate = filter.HireDate;
            empedit.HomePhone = filter.HomePhone;
            empedit.LastName = filter.LastName;
            empedit.Notes = filter.Notes;
            empedit.Photo = filter.Photo;
            empedit.PhotoPath = filter.PhotoPath;
            empedit.PostalCode = filter.PostalCode;
            empedit.Region = filter.Region;
            empedit.ReportsTo = filter.ReportsTo;
            empedit.Title = filter.Title;
            empedit.TitleOfCourtesy = filter.TitleOfCourtesy;
            _dbContext.Update(empedit);
            _dbContext.SaveChanges();
            return Ok();
        }

        //delete
        [HttpDelete("{id}")]
        public IActionResult RemoweEmployee([FromRoute] int id)
        {
            var emp = _dbContext.Employees.Find(id);
            if (emp == null)
            {
                return BadRequest();
            }
            _dbContext.Employees.Remove(emp);
            _dbContext.SaveChanges();
            return Ok();

        }



        [HttpGet("token")]
        public IActionResult GetEmp([FromQuery] EmployeeFilter filter)
        {
            IEnumerable<Employee> empl;
            var query = from employe in _dbContext.Employees
                        where (string.IsNullOrEmpty(filter.FirstName) || employe.FirstName.Contains(filter.FirstName)
                        && (string.IsNullOrEmpty(filter.Title) || employe.Title.Contains(filter.Title)
                        && (string.IsNullOrEmpty(filter.LastName) || employe.LastName.Contains(filter.LastName))))
                        select employe;
            if (filter.Skip.HasValue)
            {
                query = query.Skip(filter.Skip.Value);
            }
            query = query.Take(filter.Take.Value);
            empl = query.ToList();
            return Ok(empl);


        }
    }
}
