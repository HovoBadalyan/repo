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
    public class BillingAccountController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBillAcc()
        {
            List<BillingAccount>  billingAccounts;
            using (var dbcontext = new DB2SlackContext())
            {
                billingAccounts = dbcontext.BillingAccounts.ToList();
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetidBillAcc([FromRoute] int id)
        {
            BillingAccount billingAccount;
            using (var dbcontext = new DB2SlackContext())
            {
                billingAccount = dbcontext.BillingAccounts.Find(id);
            }
            if (billingAccount == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult AddBillAcc([FromBody] BillingAccount billingAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (var dbcontext = new DB2SlackContext())
            {
                dbcontext.BillingAccounts.Add(billingAccount);
                dbcontext.SaveChanges();
            }
            return Created("", billingAccount);
        }

        [HttpPut]
        public IActionResult EditBillAcc([FromBody] BillingAccount billingAccount)
        {
            using (var dbcontext = new DB2SlackContext())
            {
                var billacctoedit = dbcontext.BillingAccounts.Find(billingAccount.AccountId);
                if (billingAccount == null)
                {
                    return BadRequest();
                }
                billacctoedit.BillingId= billingAccount.BillingId;
                billacctoedit.BillAmount=billingAccount.BillAmount;                
                dbcontext.Update(billacctoedit);
                dbcontext.SaveChanges();
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetBillAccFilter([FromQuery] BilAccFilter filter)
        {
            IEnumerable<BillingAccount> billacc;
            using (var dbContext = new DB2SlackContext())
            {

                var query = from bill in dbContext.BillingAccounts
                            where (!filter.BillingId.HasValue || bill.BillingId == filter.BillingId)
                            &&(!filter.BillAmount.HasValue||bill.BillAmount==filter.BillAmount)
                            && (string.IsNullOrEmpty(filter.Comments) || bill.Comments.Contains(filter.Comments))
                            select bill;

                if (filter.Skip.HasValue)
                {
                    query = query.Skip(filter.Skip.Value);
                }
                query = query.Take(filter.Take.Value);

                billacc = query.ToList();
            }
            return Ok();
        }
    }
}
