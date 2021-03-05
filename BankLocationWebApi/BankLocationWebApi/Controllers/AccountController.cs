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
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAccount()
        {
            IEnumerable<Account> accounts;
            using (var dbcontext = new DB2SlackContext())
            {
                accounts = dbcontext.Accounts.ToList();
            }
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public IActionResult GetidAcc([FromRoute] int id)
        {
            Account account;
            using (var dbcontext = new DB2SlackContext())
            {
                account = dbcontext.Accounts.Find(id);
            }
            if (account == null)
            {
                return BadRequest();
            }
            return Ok(account);

        }

        [HttpPost]
        public IActionResult AddAcc([FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (var dbcontext = new DB2SlackContext())
            {
                dbcontext.Accounts.Add(account);
                dbcontext.SaveChanges();
            }
            return Created("", account);
        }

        [HttpPut]
        public IActionResult EditAcc([FromBody] Account account)
        {
            using (var dbcontext = new DB2SlackContext())
            {
                var acctoedit = dbcontext.Accounts.Find(account.AccountId);
                if (acctoedit == null)
                {
                    return BadRequest();
                }
                acctoedit.AccountId = account.AccountId;
                acctoedit.AccountNumber = account.AccountNumber;
                acctoedit.AccountsTypeAccountType = account.AccountsTypeAccountType;
                acctoedit.AccountsTypeAccountTypeId = account.AccountsTypeAccountTypeId;
                acctoedit.AccountTypeId = account.AccountTypeId;
                acctoedit.Balance = account.Balance;
                acctoedit.BillingAccounts = account.BillingAccounts;
                acctoedit.CustomerId = account.CustomerId;
                acctoedit.CustomersCustomer = account.CustomersCustomer;
                acctoedit.CustomersCustomerId = account.CustomersCustomerId;
                dbcontext.Update(acctoedit);
                dbcontext.SaveChanges();

            }
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult RemoveAcc([FromRoute] int id)
        {
            using (var dbcontext = new DB2SlackContext())
            {
                var acc = dbcontext.Accounts.Find(id);
                if (acc==null)
                {
                    return BadRequest();
                }
                dbcontext.Accounts.Remove(acc);
                dbcontext.SaveChanges();
                return Ok();
            }
            
        }
    }
}
