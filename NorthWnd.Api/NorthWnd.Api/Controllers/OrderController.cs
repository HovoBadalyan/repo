using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.BusinessModels;

namespace NorthWnd.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
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
            var result = _orderOperations.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _orderOperations.Get(id);
            return Ok(result);
        }



        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody] OrderViewModel model)
        {
            var res = _orderOperations.Add(model);
            return Created("", res);
        }

        [Authorize]
        [HttpPut]
        public IActionResult Edit([FromBody] OrderViewModel model)
        {
            var res = _orderOperations.Edit(model);
            return Ok(res);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            _orderOperations.Remove(id);
            return Ok();
        }


        [HttpGet("inventory")]
        public IActionResult GetInventoryList()
        {
            var result = _orderOperations.GetInventoryList();
            return Ok(result);
        }

        [HttpGet("Highfreightorders")]
        public IActionResult GetHighFreight()
        {
            var res = _orderOperations.GetHighfreightorders();
            return Ok(res);
        }

        [HttpGet("Highfreightorders1996")]
        public IActionResult GetHighFreight1996()
        {
            var res = _orderOperations.GetHighfreightorders1996();
            return Ok(res);
        }

        [HttpGet("Highfreight1996_1997")]
        public IActionResult Get27()
        {
            var res = _orderOperations.GetHighfreight1996_1997();
            return Ok(res);
        }


        [HttpGet("Monthendorders")]
        public IActionResult GetMonthEndOrders()
        {
            var res=_orderOperations.GetMonthendorders();
            return Ok(res);
        }


        [HttpGet("Orderswithmanylineitems")]
        public IActionResult GetOrdersWithManLine()
        {
            var res = _orderOperations.GetOrderswithmanylineitems();
            return Ok(res);
        }


        [HttpGet("Ordersrandomassortments")]
        public IActionResult GetOrdersRandom()
        {
            var res = _orderOperations.GetOrdersrandomassortments();
            return Ok(res);
        }


        [HttpGet("LateOrders")]
        public IActionResult GetLateOrders()
        {
            var res = _orderOperations.GetLateOrders();
            return Ok(res);
        }


        [HttpGet("whichEmployees")]
        public IActionResult GetLateOrdersWichEmployee()
        {
            var res = _orderOperations.GetWhichEmployees();
            return Ok(res);
        }
    }
}
