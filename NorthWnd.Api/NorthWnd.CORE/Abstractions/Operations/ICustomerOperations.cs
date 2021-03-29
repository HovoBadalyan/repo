using NorthWnd.CORE.BusinessModels.QueryListModel;
using System.Collections.Generic;

namespace NorthWnd.CORE.Abstractions.Operations
{
    public interface ICustomerOperations
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
