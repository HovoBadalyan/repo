using Northwndarchitect.API.Entities;
using Northwndarchitect.CORE.Abstractions.Operations;
using Northwndarchitect.CORE.BusinesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwndarchitect.BLL.Operations
{
    public class CustomerOperations : ICustomerOperations
    {
        private readonly NORTHWNDContext context;
        public CustomerOperations(NORTHWNDContext _context)
        {
            context = _context;
        }


        public IEnumerable<CustomerViewModel> GetModels()
        {
            var data = context.Customers.ToList();
            var result = data.Select(x => new CustomerViewModel
            {
                Address=x.Address,
                City=x.City,
                CompanyName=x.CompanyName,
                ContactName=x.ContactName,
                ContactTitle=x.ContactTitle,
                Country=x.Country,
                CustomerId=x.CustomerId,
                Fax=x.Fax,
                Phone=x.Phone,
                PostalCode=x.PostalCode,
                Region=x.Region
            });
            return result;
        } 
        public Customer GetCustomerId(string id)
        {
            var res = context.Customers.Find(id);
            return res;
        }
    }
}
