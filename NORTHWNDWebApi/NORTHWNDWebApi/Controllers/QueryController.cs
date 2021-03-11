using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NORTHWNDWebApi.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NORTHWNDWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly NORTHWNDContext dbContext;

        public QueryController(NORTHWNDContext context)
        {
            dbContext = context;
        }

        [HttpGet("20")]
        public IActionResult action()
        {
            var res = (from c in dbContext.Categories
                       join p in dbContext.Products
                       on c.CategoryId equals p.CategoryId
                       group c by c.CategoryName into g
                       select new
                       {
                           catname = g.Key,
                           total = g.Count()
                       }).OrderByDescending(x => x.total);
            return Ok(res);

        }
        [HttpGet("21")]
        public IActionResult onlyproblem21()
        {
            var res = (from c in dbContext.Customers
                       group c by c.City into g
                       select new
                       {
                           city = g.Key,
                           country = g.Key,
                           totalcustomer = g.Count()
                       }).OrderByDescending(x => x.totalcustomer);

            return Ok(res);
        }

        [HttpGet("22")]
        public IActionResult onlyproblem22()
        {
            var query = (from p in dbContext.Products
                         where p.UnitsInStock < p.ReorderLevel
                         select new
                         {
                             PorductId = p.ProductId,
                             ProductName = p.ProductName,
                             UnitsInStock = p.UnitsInStock,
                             ReorderLevel = p.ReorderLevel
                         }).ToList();
            return Ok(query);
        }
        [HttpGet("23")]
        public IActionResult onlyproblem23()
        {
            var query = (from p in dbContext.Products
                         where (p.UnitsInStock + p.UnitsOnOrder) <= p.ReorderLevel && p.Discontinued == false
                         select new
                         {
                             ProductId = p.ProductId,
                             ProductName = p.ProductName,
                             UnitsInStock = p.UnitsInStock,
                             UnitsOnOrder = p.UnitsOnOrder,
                             ReorderLevel = p.ReorderLevel,
                             Discontinued = p.Discontinued
                         }).ToList();
            return Ok(query);
        }
        [HttpGet("24")]
        public IActionResult onlyproblem24()
        {

            return Ok();
        }
        [HttpGet("25")]
        public IActionResult onlyproblem25()
        {
            var query = (from o in dbContext.Orders
                         group o by o.ShipCountry into g
                         select new
                         {
                             ShipCountry = g.Key,
                             AveragFreight = g.Average(x => x.Freight)
                         }).OrderByDescending(x => x.AveragFreight).Take(3);
            return Ok(query);

        }
        [HttpGet("26")]
        public IActionResult onlyproblem26()
        {
            var query = (from o in dbContext.Orders
                         //where o.OrderDate.ToString("yyyy/mm/dd") > "2015/00/00"
                         group o by o.ShipCountry into g
                         select new
                         {
                             ShipCountry = g.Key,
                             AveragFreight = g.Average(x => x.Freight)
                         }).OrderByDescending(x => x.AveragFreight).Take(3);
            return Ok(query);
        }
        [HttpGet("27")]
        public IActionResult onlyproblem27()
        {

            return Ok();
        }
        [HttpGet("28")]
        public IActionResult onlyproblem28()
        {

            return Ok();
        }
        [HttpGet("29")]
        public IActionResult onlyproblem29()
        {

            return Ok();
        }
        [HttpGet("30")]
        public IActionResult onlyproblem30()
        {

            return Ok();
        }
    }
}
