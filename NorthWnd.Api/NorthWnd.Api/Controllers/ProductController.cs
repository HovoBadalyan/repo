using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.BusinessModels;

namespace NorthWnd.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductOperations product;
        public ProductController(IProductOperations operations)
        {
            product = operations;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var res = product.GetAll();
            return Ok(res);
        }


        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var res = product.Get(id);
            return Ok(res);
        }


        [Authorize (Roles ="Admin")]
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            product.Remove(id);
            return Ok();
        }


        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody] ProductViewModel model)
        {
            var res = product.Add(model);
            return Created("", res);
        }


        [Authorize]
        [HttpPut]
        public IActionResult Edit([FromBody] ProductViewModel model)
        {
            var res = product.Edit(model);
            return Ok(res);
        }


        [HttpGet("Productsneedreorderings")]
        public IActionResult Productsneedreorderings()
        {
            var res = product.GetProductsneedreorderings();
            return Ok(res);
        }

        [HttpGet("Productsthatneedreorderings")]
        public IActionResult Productsthatneedreorderings()
        {
            var res = product.GetProductsthatneedreorderings();
            return Ok(res);
        }
    }
}
