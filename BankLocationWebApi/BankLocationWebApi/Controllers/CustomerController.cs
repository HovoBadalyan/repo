﻿using BankLocationWebApi.Filter;
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
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCustomer()
        {
            List<Customer> customers;
            using (var dbcontext = new DB2SlackContext())
            {
                customers = dbcontext.Customers.ToList();
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetidCust([FromRoute] int id)
        {
            Customer customer;
            using (var dbcontext = new DB2SlackContext())
            {
                customer = dbcontext.Customers.Find(id);
            }
            if (customer == null)
            {
                return BadRequest();
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult AddCust([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (var dbcontext = new DB2SlackContext())
            {
                dbcontext.Customers.Add(customer);
                dbcontext.SaveChanges();
            }
            return Created("", customer);
        }

        [HttpPut]
        public IActionResult EditCust([FromBody] Customer customer)
        {
            using (var dbcontext = new DB2SlackContext())
            {
                var custtoedit = dbcontext.Customers.Find(customer.CustomerId);
                if (custtoedit == null)
                {
                    return BadRequest();
                }
                custtoedit.CustomerId = customer.CustomerId;
                custtoedit.ContactInfo = customer.ContactInfo;
                custtoedit.CustomerName = customer.CustomerName;
                dbcontext.Update(custtoedit);
                dbcontext.SaveChanges();
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetStudents([FromQuery] CustomerFilter filter)
        {
            IEnumerable<Customer> customers;
            using (var dbContext = new DB2SlackContext())
            {

                var query = from customer in dbContext.Customers
                            where (!filter.CustomerId.HasValue || customer.CustomerId == filter.CustomerId)
                            && (string.IsNullOrEmpty(filter.ContactInfo) || customer.ContactInfo.Contains(filter.ContactInfo)
                            && (string.IsNullOrEmpty(filter.CustomerName) || customer.CustomerName.Contains(filter.CustomerName)))
                            select customer;

                if (filter.Skip.HasValue)
                {
                    query = query.Skip(filter.Skip.Value);
                }
                query = query.Take(filter.Take.Value);

                customers = query.ToList();
            }
            return Ok();
        }
    }
}
