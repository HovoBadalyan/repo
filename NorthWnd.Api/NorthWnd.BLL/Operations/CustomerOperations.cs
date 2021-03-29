using Microsoft.Extensions.Logging;
using NorthWnd.CORE.Abstractions;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.BusinessModels.QueryListModel;
using System.Collections.Generic;

namespace NorthWnd.BLL.Operations
{
    public class CustomerOperations : ICustomerOperations
    {
        private readonly IRepositoryManager _repositories;
        private readonly ILogger<CustomerOperations> logger;

        public CustomerOperations(IRepositoryManager repositories, ILogger<CustomerOperations> _logger)
        {
            logger = _logger;
            _repositories = repositories;
        }


        public IEnumerable<Customerswithnoordersforempid4> Get4s()
        {
            logger.LogInformation("CustomersOperation --- Query N31");
            return _repositories.Customers.Get4s();
        }

        public IEnumerable<CustomerListbyRegion> GetCustomerlistbyregions()
        {
            logger.LogInformation("CustomerOperation --- Query N24");
            return _repositories.Customers.GetCustomerlistbyregions();
        }

        public IEnumerable<CustomerswithOrders> GetCustomerswithnoorders()
        {
            logger.LogInformation("CustomersOperation --- Query N30");
            return _repositories.Customers.GetCustomerswithnoorders();
        }

        public IEnumerable<HighValueCustomers> GetHighvaluecustomers()
        {
            logger.LogInformation("CustomersOperation --- Query N32");
            return _repositories.Customers.GetHighvaluecustomers();
        }

        public IEnumerable<HighValueCustomerswithdiscount> GetHighvaluecustomerswithdiscounts()
        {
            logger.LogInformation("CustomersOperation --- Query N34");
            return _repositories.Customers.GetHighvaluecustomerswithdiscounts();
        }

        public IEnumerable<TotalCustomers> GetTotalCustomers()
        {
            logger.LogInformation("CustomerOperation --- Query N21");
            return _repositories.Customers.GetTotalCustomers();
        }

        public IEnumerable<HighValueCustomers> Highvaluecustomerstotalorders()
        {
            logger.LogInformation("CustomersOperation --- Query N33");
            return _repositories.Customers.Highvaluecustomerstotalorders();
        }

    }
}
