using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using System.Collections.Generic;

namespace NorthWnd.CORE.Abstractions.Operations
{
    public interface IOrderOperations
    {
        IEnumerable<LateOrders> GetLateOrders();
        IEnumerable<LateOrdersWhichEmployees> GetWhichEmployees();
        IEnumerable<OrdersWithManyLineItems> GetOrderswithmanylineitems();
        IEnumerable<OrdersRandomAssortment> GetOrdersrandomassortments();
        IEnumerable<HighFreightOrders> GetHighfreightorders();
        IEnumerable<HighFreightOrders> GetHighfreightorders1996();
        IEnumerable<HighFreightOrders> GetHighfreight1996_1997();
        IEnumerable<InventoryListModel> GetInventoryList();
        IEnumerable<MonthEndOrders> GetMonthendorders();
        IEnumerable<OrderViewModel> GetAll();
        OrderViewModel Get(int id);
        void Remove(int id);
        Order Edit(OrderViewModel model);
        Order Add(OrderViewModel model);
    }
}
