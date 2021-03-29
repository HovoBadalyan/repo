using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWnd.CORE.Abstractions.Repository
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        IEnumerable<LateOrders> GetLateOrders();
        IEnumerable<InventoryListModel> GetInventoryList();
        IEnumerable<HighFreightOrders> GetHighfreightorders();
        IEnumerable<HighFreightOrders> GetHighfreightorders1996();
        IEnumerable<HighFreightOrders> GetHighfreight1996_1997();
        IEnumerable<MonthEndOrders> GetMonthendorders();
        IEnumerable<OrdersWithManyLineItems> GetOrderswithmanylineitems();
        IEnumerable<OrdersRandomAssortment> GetOrdersrandomassortments();
        IEnumerable<LateOrdersWhichEmployees> whichEmployees();

    }
}
