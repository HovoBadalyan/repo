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
    public class CategoryController : ControllerBase
    {
        private readonly NORTHWNDContext dbContext;

        public CategoryController(NORTHWNDContext context)
        {
            dbContext = context;
        }

        //get
        [HttpGet]
        public IActionResult GetCategory()
        {
            IEnumerable<Category> categories;
            categories = dbContext.Categories.ToList();
            return Ok(categories);
        }
        //get {id}
        [HttpGet("id")]
        public IActionResult GetCategoryid([FromRoute]int id)
        {
            Category category;
            category = dbContext.Categories.Find(id);
            if (category==null)
            {
                return BadRequest();
            }
            return Ok(category);
        }

        //post
        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
            return Created("", category);
        }


        //delet
        [HttpDelete("{id}")]
        public IActionResult RemoveCategory([FromRoute] int id)
        {
            var categ = dbContext.Categories.Find(id);
            if (categ==null)
            {
                return BadRequest();
            }
            dbContext.Categories.Remove(categ);
            dbContext.SaveChanges();
            return Ok();
        }


        //put edit
        [HttpPut]
        public IActionResult EditCategory([FromBody] CategoryFilter filter)
        {
            var cat = dbContext.Categories.Find(filter.CategoryId);
            if (cat==null)
            {
                return BadRequest();
            }
            
            cat.CategoryName = filter.CategoryName;
            cat.Description = filter.Description;
            cat.Picture = filter.Picture;
            dbContext.Update(cat);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetCateg([FromQuery] CategoryFilter filter)
        {
            IEnumerable<Category> categories;
            var query = from category in dbContext.Categories
                        where (string.IsNullOrEmpty(filter.CategoryName) || category.CategoryName.Contains(filter.CategoryName)
                        && (!filter.CategoryId.HasValue || category.CategoryId == filter.CategoryId))
                        select category;
            if (filter.Skip.HasValue)
            {
                query = query.Skip(filter.Skip.Value);
            }
            query=query.Take(filter.Take.Value);
            categories = query.ToList();
            return Ok(categories);

        }
    }
}
