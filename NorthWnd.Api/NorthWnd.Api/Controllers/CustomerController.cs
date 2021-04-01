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
        public IActionResult Totalcustomers()
        {
            var res = customer.GetTotalCustomers();
            return Ok(res);
        }



        [HttpGet("customerswithnoorders")]
        public IActionResult Customerswithnoorders()
        {
          var result=customer.GetCustomerswithnoorders();
            return Ok(result);
        }

        [HttpGet("Customerlistbyregions")]
        public IActionResult Customerlistbyregions()
        {
            var res = customer.GetCustomerlistbyregions();
            return Ok(res);
        }

        [HttpGet("customers_no_orders_empid4")]
        public IActionResult Customers_no_orders_empid4()
        {
            var res = customer.Get4s();
            return Ok(res);
        }

        [HttpGet("Highvaluecustomers")]
        public IActionResult Highvaluecustomers()
        {
            var res = customer.GetHighvaluecustomers();
            return Ok(res);
        }

        [HttpGet("Highvaluecustomerstotalorders")]
        public IActionResult Highvaluecustomerstotalorders()
        {
            var res = customer.Highvaluecustomerstotalorders();
            return Ok(res);
        }


        [HttpGet("Highvaluecustomerswithdiscounts")]
        public IActionResult Highvaluecustomerswithdiscounts()
        {
            var res = customer.GetHighvaluecustomerswithdiscounts();
            return Ok(res);
        }

    }
}
