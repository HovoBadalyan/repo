using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NORTHWNDWebApi.Models.DB;
using NORTHWNDWebApi.NORTHWNDfilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NORTHWNDWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly NORTHWNDContext _dbContext;

        public OrderController(NORTHWNDContext context)
        {
            _dbContext = context;
        }
        [HttpGet]
        public IActionResult GetOrder()
        {
            IEnumerable<Order> orders;
            orders = _dbContext.Orders.ToList();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderId([FromRoute] int id)
        {
            Order order;
            order = _dbContext.Orders.Find(id);
            if (order==null)
            {
                return BadRequest();
            }
            return Ok(order);
   
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] Order filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dbContext.Orders.Add(filter);
            _dbContext.SaveChanges();
            return Created("", filter);
        }

        [HttpPut]
        public IActionResult EditOrder([FromBody] OrderFilter filter)
        {
            var orderedit = _dbContext.Orders.Find(filter.OrderId);
            if (orderedit==null)
            {
                return BadRequest();
            }

            orderedit.OrderDate = filter.OrderDate;
            orderedit.ShipAddress = filter.ShipAddress;
            orderedit.ShipCity = filter.ShipCity;
            orderedit.ShipCountry = filter.ShipCountry;
            orderedit.ShipName = filter.ShipName;
            orderedit.ShippedDate = filter.ShippedDate;
            orderedit.ShipPostalCode = filter.ShipPostalCode;
            orderedit.ShipRegion = filter.ShipRegion;
            orderedit.ShipVia = filter.ShipVia;
            orderedit.RequiredDate = filter.RequiredDate;
            orderedit.Freight = filter.Freight;
            _dbContext.Update(orderedit);
            _dbContext.SaveChanges();
            return Ok(orderedit);

        }

        [HttpDelete("{id}")]
        public IActionResult RemoweOrderid([FromRoute]int id)
        {
            var order = _dbContext.Orders.Find(id);
            if (order== null)
            {
                return BadRequest();
            }
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
            return Ok(order);
        }

        [HttpGet("token")]
        public IActionResult Gettoken([FromQuery] OrderFilter filter)
        {
            IEnumerable<Order> orders;
            var query = from order in _dbContext.Orders
                        where (string.IsNullOrEmpty(filter.ShipName) || order.ShipName.Contains(filter.ShipName)
                        && (!filter.OrderId.HasValue || order.OrderId == filter.OrderId)
                        && (string.IsNullOrEmpty(filter.ShipCity) || order.ShipCity.Contains(filter.ShipCity)))
                        select order;
            if (filter.Skip.HasValue)
            {
                query = query.Skip(filter.Skip.Value);
            }
            query = query.Take(filter.Take);

            orders = query.ToList();
            return Ok(orders);
        }
    }
}
