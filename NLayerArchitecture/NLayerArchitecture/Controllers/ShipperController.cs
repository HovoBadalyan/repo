using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerArchitecure.Core.Abstractions.Operations;
using NLayerArchitecure.Core.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerArchitecture.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperOperations shipperOperations;
        public ShipperController(IShipperOperations shipper)
        {
            shipperOperations = shipper;
        }

        [HttpGet]
        public IActionResult GetShippers()
        {
            var data = shipperOperations.GetShippers();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetShipperId([FromRoute] int id)
        {
            var data = shipperOperations.GetShipperid(id);
            if (data == null)
                return BadRequest();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveShipper([FromRoute] int id)
        {
            var data = shipperOperations.RemoveShipper(id);
            if (data == null)
                return BadRequest();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult AddShipper([FromBody] ShipperViewModel shipperView)
        {
            var res = shipperOperations.AddShipper(shipperView);
            if (!ModelState.IsValid)
                return BadRequest();
            return Created("", res);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ShipperViewModel shipperView)
        {
            var res = shipperOperations.UpdateShipper(shipperView);
            if (res == null)
                return BadRequest();
            return Ok(res);
        }

    }
}
