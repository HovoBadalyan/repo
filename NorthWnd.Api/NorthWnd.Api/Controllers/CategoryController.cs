using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.BusinessModels;

namespace NorthWnd.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryOperations category;
        public CategoryController(ICategoryOperations _category)
        {
            category = _category;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var res = category.GetAll();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var res = category.Get(id);
            return Ok(res);
        }


        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute]int id)
        {
            category.Remove(id);
            return Ok();
        }
        

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody] CategoryViewModel model)
        {
            var res = category.Add(model);
            return Created("", res);
        }

        [Authorize]
        [HttpPut]
        public IActionResult Edit([FromBody] CategoryViewModel model)
        {
            var res = category.Edit(model);
            return Ok(res);
        }


        [HttpGet("CategoryandtotalProducts")]
        public IActionResult CategoryandtotalProducts()
        {
            var res = category.GetCategoryandtotalProducts();
            return Ok(res);
        }

    }
}
