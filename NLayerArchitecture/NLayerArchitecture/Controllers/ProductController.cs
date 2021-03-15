using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerArchitecure.Core.Abstractions.Operations;
using NLayerArchitecure.Core.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerArchitecture.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductOperations productOperations;
        public ProductController(IProductOperations product)
        {
            productOperations = product;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var res = productOperations.GetProducts();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetId([FromRoute]int id)
        {
            var res = productOperations.GetProductid(id);
            if (res==null)
            {
                return BadRequest();
            }
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveProduct([FromRoute]int id)
        {
            var res = productOperations.RemoveProduct(id);
            if (res==null)
            {
                return BadRequest();
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductViewModel productView)
        {
            var res = productOperations.AddProduct(productView);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Created("", res);
        }

        [HttpPut]
        public IActionResult EditProduct([FromBody] ProductViewModel productView)
        {
            var res = productOperations.UpdateProduct(productView);
            if (res == null)
                return BadRequest();
            return Ok(res);
        }
    }
}
