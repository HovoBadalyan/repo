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
    public class RegionController : ControllerBase
    {
        private readonly NORTHWNDContext _dbContext;

        public RegionController(NORTHWNDContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult GetRegion()
        {
            IEnumerable<Region> regions;
            regions = _dbContext.Regions.ToList();
            return Ok(regions);
        }

        [HttpGet("{id}")]
        public IActionResult GetRegionId([FromRoute] int id)
        {
            Region region;
            region = _dbContext.Regions.Find(id);
            if (region == null)
            {
                return BadRequest();
            }
            return Ok(region);

        }

        [HttpPost]
        public IActionResult AddRegion([FromBody] Region filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dbContext.Regions.Add(filter);
            _dbContext.SaveChanges();
            return Created("", filter);
        }

        [HttpPut]
        public IActionResult EditRegion([FromBody] RegionFilter filter)
        {
            var regionedit = _dbContext.Regions.Find(filter.RegionId);
            if (regionedit == null)
            {
                return BadRequest();
            }
            regionedit.RegionDescription = filter.RegionDescription;
            _dbContext.Update(regionedit);
            _dbContext.SaveChanges();
            return Ok(regionedit);

        }

        [HttpDelete("{id}")]
        public IActionResult Remoweregionid([FromRoute] int id)
        {
            var region = _dbContext.Regions.Find(id);
            if (region == null)
            {
                return BadRequest();
            }
            _dbContext.Regions.Remove(region);
            _dbContext.SaveChanges();
            return Ok(region);
        }

        [HttpGet("token")]
        public IActionResult Gettoken([FromQuery] RegionFilter filter)
        {
            IEnumerable<Region> regions;
            var query = from region in _dbContext.Regions
                        where (string.IsNullOrEmpty(filter.RegionDescription) || region.RegionDescription.Contains(filter.RegionDescription)
                        && (!filter.RegionId.HasValue || region.RegionId == filter.RegionId))
                        select region;
            if (filter.Skip.HasValue)
            {
                query = query.Skip(filter.Skip.Value);
            }
            query = query.Take(filter.Take);

            regions = query.ToList();
            return Ok(regions);
        }

        
    }
}
