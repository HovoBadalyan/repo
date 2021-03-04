using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwndWeb.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwndWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        [HttpGet("orders")]
        public List<Order> Get()
        {
            using NORTHWNDContext db = new
               NORTHWNDContext();
            return db.Orders.ToList();
        }

        [HttpGet("orders/{id}")]
        public Order Get([FromRoute] int id)
        {
            using NORTHWNDContext db = new
               NORTHWNDContext();
            return db.Orders.Find(id);
        }
    }
}
