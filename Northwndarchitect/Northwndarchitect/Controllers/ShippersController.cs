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
    public class ShippersController : ControllerBase
    {
        private readonly IShipperOperations shipper;
        public ShippersController(IShipperOperations shipper)
        {
            this.shipper = shipper;
        }
        
        [HttpGet]
        public IActionResult GetShippers()
        {
            var res = shipper.GetShippers();
            return Ok(res);
        }
        [HttpGet("{id}")]
        public IActionResult GetShipersId([FromRoute]int id)
        {
            var res = shipper.GetShipperId(id);
            if (res==null)
            {
                return BadRequest();
            }
            return Ok(res);
        }
    }
}
