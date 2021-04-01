using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.BusinessModels;

namespace NorthWnd.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsOperations orderDetails;
        public OrderDetailsController(IOrderDetailsOperations operations)
        {
            orderDetails = operations;
        }

        [HttpGet]
        public IActionResult GetOrdDetails()
        {
            var res = orderDetails.GetAll();
            return Ok(res);
        }


        [HttpGet("{id}")]
        public IActionResult GetOrdDetail([FromRoute] int id)
        {
            var res = orderDetails.Get(id);
            return Ok(res);
        }


        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody] OrderDetailsViewModel model)
        {
            var result = orderDetails.Add(model);
            return Created("", result);
        }

        [Authorize]
        [HttpPut]
        public IActionResult Edit([FromBody] OrderDetailsViewModel model)
        {
            var result = orderDetails.Edit(model);
            return Ok(result);
        }


        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            orderDetails.Remove(id);
            return Ok();
        }


        [HttpGet("OrdersDoubleEntry")]
        public IActionResult OrdersDoubleEntry()
        {
            var res = orderDetails.GetDoubleEntries();
            return Ok(res);
        } 
        
        
        [HttpGet("OrdersDoubleEntryDetails")]
        public IActionResult OrdersDoubleEntryDetails()
        {
            var res = orderDetails.GetDoubleEntriesDetails();
            return Ok(res);
        }

    }
}
