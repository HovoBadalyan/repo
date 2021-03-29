using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWnd.CORE.Abstractions.Repository
{
   public interface ICustomerRepository:IRepositoryBase<Customer>
    {
        IEnumerable<CustomerswithOrders> GetCustomerswithnoorders();
        IEnumerable<TotalCustomers> GetTotalCustomers();

        IEnumerable<CustomerListbyRegion> GetCustomerlistbyregions();
        IEnumerable<Customerswithnoordersforempid4> Get4s();
        IEnumerable<HighValueCustomers> GetHighvaluecustomers();
        IEnumerable<HighValueCustomers> Highvaluecustomerstotalorders();
        IEnumerable<HighValueCustomerswithdiscount> GetHighvaluecustomerswithdiscounts();
    }
}
