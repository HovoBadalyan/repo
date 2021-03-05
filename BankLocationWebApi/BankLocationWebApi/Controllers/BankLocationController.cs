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
            using (var db=new DB2SlackContext())
            {
               bankLocation=db.BankLocations.Find(id);
            }
            if (bankLocation==null)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
