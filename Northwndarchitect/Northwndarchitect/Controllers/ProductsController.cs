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
    public class ProductsController : ControllerBase
    {
        private readonly IProductOperations product;
        public ProductsController(IProductOperations product)
        {
            this.product = product;     
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var res = product.GetProducts();
            return Ok(res);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductid([FromRoute] int id)
        {
            var res = product.GetProductId(id);
            if (res==null)
            {
                return BadRequest();
            }
            return Ok(res);
        }
    }
}
