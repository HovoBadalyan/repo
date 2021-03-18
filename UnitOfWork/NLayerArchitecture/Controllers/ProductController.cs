using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerArchitecure.Core.Abstractions.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerArchitecture.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductOperations productOperations;
        public ProductController(IProductOperations product)
        {
            productOperations = product;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
           var res= productOperations.GetProducts();
            return Ok(res);
        }
    }
}
