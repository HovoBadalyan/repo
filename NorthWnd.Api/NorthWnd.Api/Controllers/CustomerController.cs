using Microsoft.AspNetCore.Mvc;
using NorthWnd.CORE.Abstractions.Operations;

namespace NorthWnd.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerOperations customer;
        public CustomerController(ICustomerOperations _customer)
        {
            customer = _customer;
        }



        [HttpGet("totalcustomers")]
        public IActionResult Get21()
        {
            var res = customer.GetTotalCustomers();
            return Ok(res);
        }



        [HttpGet("customerswithnoorders")]
        public IActionResult Get30()
        {
          var result=customer.GetCustomerswithnoorders();
            return Ok(result);
        }

        [HttpGet("Customerlistbyregions")]
        public IActionResult Get24()
        {
            var res = customer.GetCustomerlistbyregions();
            return Ok(res);
        }

        [HttpGet("customers_no_orders_empid4")]
        public IActionResult Get31()
        {
            var res = customer.Get4s();
            return Ok(res);
        }

        [HttpGet("Highvaluecustomers")]
        public IActionResult Get32()
        {
            var res = customer.GetHighvaluecustomers();
            return Ok(res);
        }

        [HttpGet("Highvaluecustomerstotalorders")]
        public IActionResult Get33()
        {
            var res = customer.Highvaluecustomerstotalorders();
            return Ok(res);
        }


        [HttpGet("Highvaluecustomerswithdiscounts")]
        public IActionResult Get34()
        {
            var res = customer.GetHighvaluecustomerswithdiscounts();
            return Ok(res);
        }

    }
}
