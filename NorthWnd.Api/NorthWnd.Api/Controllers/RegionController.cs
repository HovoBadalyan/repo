using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.BusinessModels;

namespace NorthWnd.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionOperations region;
        public RegionController(IRegionOperations operations)
        {
            region = operations;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var res = region.GetAll();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var res = region.Get(id);
            return Ok(res);
        }


        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            region.Remove(id);
            return Ok();
        }


        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody] RegionViewModel model)
        {
            var res = region.Add(model);
            return Created("", res);
        }


        [Authorize]
        [HttpPut]
        public IActionResult Edit([FromBody] RegionViewModel model)
        {
            var res = region.Edit(model);
            return Ok(res);
        }



    }
}
