using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLayerArchitecure.Core.Abstractions.Operations;
using NLayerArchitecure.Core.BusinessModels;
using NLayerArchitecure.Core.Models;
using NLayerArchitecure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerArchitecture.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderOperations _orderOperations;

        public OrderController(IOrderOperations orderOperations)
        {
            _orderOperations = orderOperations;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _orderOperations.GetOrders();
            return Ok(result);
        }

        [HttpGet("inventory")]
        public IActionResult GetInventoryList()
        {
            var result = _orderOperations.GetInventoryList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderId([FromRoute]int id)
        {
            var res = _orderOperations.GetOrderid(id);
            if (res==null)
            {
                return BadRequest();
            }
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveOrder([FromRoute]int id)
        {
            var res = _orderOperations.RemoveOrder(id);
            if (res == null)
                return BadRequest();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateOrder([FromBody] OrderViewModel model)
        {
            var res = _orderOperations.UpdateOrder(model);
            if (res == null)
                return BadRequest();
            return Ok(res);
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] OrderViewModel model)
        {
            var res = _orderOperations.AddOrder(model);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Created("", res);
        }
    }
}
