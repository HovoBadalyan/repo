using NLayerArchitecure.Core.BusinessModels;
using NLayerArchitecure.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerArchitecure.Core.Abstractions.Operations
{
    public interface IOrderOperations
    {
        IEnumerable<InventoryListModel> GetInventoryList();
        IEnumerable<OrderViewModel> GetOrders();
        public Order GetOrderid(int id);
        public Order UpdateOrder(OrderViewModel orderView);
        public Order AddOrder(OrderViewModel orderView);
        public Order RemoveOrder(int id);
        
    }
}
