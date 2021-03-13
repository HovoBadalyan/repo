using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwndarchitect.API.Entities;
using Northwndarchitect.CORE.Abstractions.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwndarchitect.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerOperations context;

        public CustomerController(ICustomerOperations context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetCustomer()
        {
            var res = context.GetModels();
            return Ok(res);
        }
        [HttpGet("{id}")]
        public IActionResult GetCustId([FromRoute] string id)
        {
            var res = context.GetCustomerId(id);
            if (res == null)
                return BadRequest();
            return Ok(res);
        }
        
       
    }
}
