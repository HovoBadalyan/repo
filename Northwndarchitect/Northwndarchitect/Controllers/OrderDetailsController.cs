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
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsOperations order;
        public OrderDetailsController(IOrderDetailsOperations order)
        {
            this.order = order;
        }
        [HttpGet]
        public IActionResult GetOrderDetails()
        {
            var result = order.GetOrderDetailsViewModels();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetOrderDetailsId([FromRoute] int id)
        {
            var res = order.GetOrderDetailId(id);
            if (res==null)
            {
                return BadRequest();
            }
            return Ok(res);
        }
    }
}
