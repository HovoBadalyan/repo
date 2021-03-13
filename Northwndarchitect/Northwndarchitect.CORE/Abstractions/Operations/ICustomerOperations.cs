using Northwndarchitect.API.Entities;
using Northwndarchitect.CORE.BusinesModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwndarchitect.CORE.Abstractions.Operations
{
    public interface ICustomerOperations
    {
        IEnumerable<CustomerViewModel> GetModels();
        public Customer GetCustomerId(string id);
        
    }
}
