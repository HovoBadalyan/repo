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
    public class AccountTypeControllers : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAccType()
        {
            IEnumerable<AccountsType> accountTypes;
            using (var dbcontext = new DB2SlackContext())
            {
                accountTypes = dbcontext.AccountsTypes.ToList();
            }
            return Ok(accountTypes);
        }

        [HttpGet("{id}")]
        public IActionResult GetAccTypeId([FromRoute] int id)
        {
            AccountsType accountsType;
            using (var db = new DB2SlackContext())
            {
                accountsType = db.AccountsTypes.Find(id);
            }
            if (accountsType == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult AddAccType([FromBody] AccountsType accountsType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (var db=new DB2SlackContext())
            {
                db.AccountsTypes.Add(accountsType);
                db.SaveChanges();
            }
            return Created("",accountsType);

        }

        [HttpDelete("{id}")]
        public IActionResult RemoveAccType([FromRoute] int id )
        {
            using (var db=new DB2SlackContext())
            {
                var acctype = db.AccountsTypes.Find(id);
                if (acctype==null)
                {
                    return BadRequest();
                }
                db.AccountsTypes.Remove(acctype);
                db.SaveChanges();
                return Ok();
            }    
        }

        [HttpPut]
        public IActionResult EditAccType([FromBody] AccountsType accountsType)
        {
            using (var dbcontext = new DB2SlackContext())
            {
                var acctypetoedit = dbcontext.AccountsTypes.Find(accountsType.AccountTypeId);
                if (acctypetoedit == null)
                {
                    return BadRequest();
                }
                acctypetoedit.AccountTypeId = accountsType.AccountTypeId;

                dbcontext.Update(acctypetoedit);
                dbcontext.SaveChanges();

            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAccTypes([FromQuery] AccTypeFilter filter)
        {
            IEnumerable<AccountsType> accountsTypes;
            using (var dbContext = new DB2SlackContext())
            {

                var query = from account in dbContext.AccountsTypes
                            where (!filter.AccountTypeId.HasValue || account.AccountTypeId == filter.AccountTypeId)
                            select account;
                if (filter.Skip.HasValue)
                {
                    query = query.Skip(filter.Skip.Value);
                }
                query = query.Take(filter.Take.Value);
                accountsTypes = query.ToList();
            }
            return Ok();
        }

    }
}
