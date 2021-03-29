using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.BusinessModels;

namespace NorthWnd.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierOperations supplier;
        public SupplierController(ISupplierOperations operations)
        {
            supplier = operations;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var res = supplier.GetAll();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var res = supplier.Get(id);
            return Ok(res);
        }


        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            supplier.Remowe(id);
            return Ok();
        }


        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody] SupplierViewModel model)
        {
            var result = supplier.Add(model);
            return Created("", result);
        }


        [Authorize]
        [HttpPut]
        public IActionResult Edit([FromBody] SupplierViewModel model)
        {
            var result = supplier.Edit(model);
            return Ok(result);
        }
    }
}
