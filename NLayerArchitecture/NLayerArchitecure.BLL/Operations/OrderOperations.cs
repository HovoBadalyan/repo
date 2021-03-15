using NLayerArchitecure.Core.Abstractions.Operations;
using NLayerArchitecure.Core.Abstractions.Repositories;
using NLayerArchitecure.Core.BusinessModels;
using NLayerArchitecure.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace NLayerArchitecure.BLL.Operations
{
    public class OrderOperations : IOrderOperations
    {
        private readonly IOrderRepository _orderRepository;

        public OrderOperations(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order AddOrder(OrderViewModel orderView)
        {
            Order order = new Order
            {
                CustomerId = orderView.CustomerId,
                EmployeeId = orderView.EmployeeId,
                OrderId = orderView.OrderId,
                ShipAddress = orderView.ShipAddress,
                ShipName = orderView.ShipName
            };
            _orderRepository.Add(order);
            _orderRepository.SaveChanges();
            return order;
        }

        public IEnumerable<InventoryListModel> GetInventoryList()
        {
            return _orderRepository.GetInventoryList();
        }

        public Order GetOrderid(int id)
        {
            var order = _orderRepository.Get(id);
            return order;
        }

        public IEnumerable<OrderViewModel> GetOrders()
        {
            var data = _orderRepository.GetAll();

            var result = data.Select(x => new OrderViewModel
            {
                CustomerId = x.CustomerId,
                EmployeeId = x.EmployeeId,
                OrderId = x.OrderId,
                ShipAddress = x.ShipAddress,
                ShipName = x.ShipName
            });
            return result;
        }

        public Order RemoveOrder(int id)
        {
            var order = _orderRepository.Get(id);
            _orderRepository.Remove(order);
            _orderRepository.SaveChanges();
            return order;
        }

        public Order UpdateOrder(OrderViewModel model)
        {
            Order ord = new Order
            {
                OrderId = model.OrderId
            };
            if (model.CustomerId != null)
            {
                ord.CustomerId = model.CustomerId;
            }
            if (model.EmployeeId!=null)
            {
                ord.CustomerId = model.CustomerId;
            }
            if (model.ShipAddress!=null)
            {
                ord.ShipAddress = model.ShipAddress;
            }
            if (model.ShipName!=null)
            {
                ord.ShipName = model.ShipName;
            }

            _orderRepository.Update(ord);
            _orderRepository.SaveChanges();
            return ord;
        }
    }
}
