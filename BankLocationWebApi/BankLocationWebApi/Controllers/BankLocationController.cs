using BankLocationWebApi.Filter;
using BankLocationWebApi.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankLocationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankLocationController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBankLoc()
        {
            List<BankLocation> bankLocations;
            using (var dbcontext = new DB2SlackContext())
            {
                bankLocations = dbcontext.BankLocations.ToList();
            }
            return Ok();
        }


        [HttpGet("{id}")]
        public IActionResult GetId([FromRoute] int id)
        {
            BankLocation bankLocation;
            using (var db = new DB2SlackContext())
            {
                bankLocation = db.BankLocations.Find(id);
            }
            if (bankLocation == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult AddBankLoc([FromBody] BankLocation bankLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (var dbcontext = new DB2SlackContext())
            {
                dbcontext.BankLocations.Add(bankLocation);
                dbcontext.SaveChanges();
            }
            return Created("", bankLocation);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveBankLoc([FromRoute] int id)
        {
            using (var dbcontext = new DB2SlackContext())
            {
                var bankloc = dbcontext.BankLocations.Find(id);
                if (bankloc == null)
                {
                    return BadRequest();
                }
                dbcontext.BankLocations.Remove(bankloc);
                dbcontext.SaveChanges();
                return Ok();
            }
        }
        [HttpPut]
        public IActionResult EditBankLoc([FromBody] BankLocation bankLocation)
        {
            using (var dbcontext = new DB2SlackContext())
            {
                var banktoedit = dbcontext.BankLocations.Find(bankLocation.BranchId);
                if (banktoedit == null)
                {
                    return BadRequest();
                }
                banktoedit.BranchId = bankLocation.BranchId;
                banktoedit.Address = bankLocation.Address;
                
                    dbcontext.Update(banktoedit);
                dbcontext.SaveChanges();

            }
            return Ok();

        }

        [HttpGet]
        public IActionResult GetStudents([FromQuery] BankLocFilter filter)
        {
            IEnumerable<BankLocation> bankloc;
            using (var dbContext = new DB2SlackContext())
            {

                var query = from bank in dbContext.BankLocations
                            where (!filter.BranchId.HasValue || bank.BranchId == filter.BranchId)
                            && (string.IsNullOrEmpty(filter.Address) || bank.Address.Contains(filter.Address))
                            select bank;

                if (filter.Skip.HasValue)
                {
                    query = query.Skip(filter.Skip.Value);
                }
                query = query.Take(filter.Take.Value);

                bankloc = query.ToList();
            }
            return Ok();
        }
    }
}
