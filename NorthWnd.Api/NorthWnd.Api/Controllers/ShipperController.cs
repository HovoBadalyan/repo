using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.BusinessModels;

namespace NorthWnd.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperOperations shipper;
        public ShipperController(IShipperOperations operations)
        {
            shipper = operations;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var res = shipper.GetAll();
            return Ok(res);
        }



        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var res = shipper.Get(id);
            return Ok(res);
        }


        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int  id)
        {
            shipper.Remove(id);
            return Ok();
        }


        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody] ShipperViewModel model)
        {
            var result = shipper.Add(model);
            return Created("", result);
        }


        [Authorize]
        [HttpPut]
        public IActionResult Edit([FromBody] ShipperViewModel model)
        {
            var result = shipper.Edit(model);
            return Ok(result);
        }

    }
}
