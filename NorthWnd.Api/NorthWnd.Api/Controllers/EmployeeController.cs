using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.BusinessModels;

namespace NorthWnd.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeOperations employee;
        public EmployeeController(IEmployeeOperations operations)
        {
            employee = operations;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var res = employee.GetAll();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var res = employee.Get(id);
            return Ok(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            employee.Remove(id);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody] EmployeeViewModel model)
        {
            var res = employee.Add(model);
            return Created("", res);
        }

        [Authorize]
        [HttpPut]
        public IActionResult Edit([FromBody] EmployeeViewModel model)
        {
            var res = employee.Edit(model);
            return Ok(res);
        }
    }
}
