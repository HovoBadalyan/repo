using Microsoft.Extensions.Logging;
using NorthWnd.CORE.Abstractions;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using NorthWnd.CORE.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace NorthWnd.BLL.Operations
{
    public class OrderOperations : IOrderOperations
    {
        private readonly IRepositoryManager _repositories;
        private readonly ILogger<OrderOperations> _logger;

        public OrderOperations(IRepositoryManager repositories, ILogger<OrderOperations> logger)
        {
            _logger = logger;
            _repositories = repositories;
        }

        public Order Add(OrderViewModel model)
        {
            _logger.LogInformation("OrderOperations --- Add method started");
            Order order = new Order
            {
                CustomerId=model.CustomerId,
                EmployeeId=model.EmployeeId,
                ShipAddress=model.ShipAddress,
                ShipName=model.ShipName,
                OrderId=model.OrderId
            };
            _repositories.Orders.Add(order);
            _repositories.SaveChanges();
            _logger.LogInformation("OrderOperations --- Add method finished");
            return order;
        }

        public Order Edit(OrderViewModel model)
        {
            _logger.LogInformation("OrderOperations --- Edit method started");
            Order order = new Order
            {
                OrderId = model.OrderId
            };
            order.CustomerId = model.CustomerId ;
            order.EmployeeId = model.EmployeeId;
            order.ShipAddress = model.ShipAddress;
            order.ShipName = model.ShipName;

            _repositories.Orders.Update(order);
            _repositories.SaveChanges();
            _logger.LogInformation("OrderOperations --- Edit method finished");
            return order;

        }

        public IEnumerable<InventoryListModel> GetInventoryList()
        {
            _logger.LogInformation("OrderOperation --- Query N29");
            return _repositories.Orders.GetInventoryList();
        }

        public OrderViewModel Get(int id)
        {
            _logger.LogInformation("OrderOperations --- GetOrder method started");

            var order = _repositories.Orders.Get(id) ?? throw new LogicException("Wrong Order Id");

            _logger.LogInformation("OrderOperations --- GetOrder method finished");

            return new OrderViewModel
            {
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                OrderId = order.OrderId,
                ShipAddress = order.ShipAddress,
                ShipName = order.ShipName
            };
        }


        public IEnumerable<OrderViewModel> GetAll()
        {
            _logger.LogInformation("OrderOperations --- GetAll method started");

            var data = _repositories.Orders.GetAll();

            var result = data.Select(x => new OrderViewModel
            {
                CustomerId = x.CustomerId,
                EmployeeId = x.EmployeeId,
                OrderId = x.OrderId,
                ShipAddress = x.ShipAddress,
                ShipName = x.ShipName
            });

            _logger.LogInformation("OrderOperations --- GetAll method finished");

            return result;
        }


        public void Remove(int id)
        {
            _logger.LogInformation("OrderOperations --- Remove method started");

            var res =_repositories.Orders.Get(id);
            _repositories.Orders.Remove(res);
            _repositories.SaveChanges();

            _logger.LogInformation("OrderOperations --- Remove method finished");
        }

        public void Test()
        {
            using var transaction = _repositories.BeginTransaction();
            try
            {
                //add
                //remove
                //delete
                _repositories.SaveChanges();
                transaction.Commit();
            }
            catch (System.Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public IEnumerable<HighFreightOrders> GetHighfreightorders()
        {
            _logger.LogInformation("OrderOperation --- Query N25");
            return _repositories.Orders.GetHighfreightorders();
        }

        public IEnumerable<HighFreightOrders> GetHighfreightorders1996()
        {
            _logger.LogInformation("OrderOperation --- Query N26");
            return _repositories.Orders.GetHighfreightorders1996();
        }

        public IEnumerable<HighFreightOrders> GetHighfreight1996_1997()
        {
            _logger.LogInformation("OrderOperation --- Query N27");
            return _repositories.Orders.GetHighfreight1996_1997();
        }

        public IEnumerable<MonthEndOrders> GetMonthendorders()
        {
            _logger.LogInformation("OrderOperation --- Query N35");
            return _repositories.Orders.GetMonthendorders();
        }

        public IEnumerable<OrdersWithManyLineItems> GetOrderswithmanylineitems()
        {
            _logger.LogInformation("OrderOperation --- Query N36");
            return _repositories.Orders.GetOrderswithmanylineitems();
        }

        public IEnumerable<OrdersRandomAssortment> GetOrdersrandomassortments()
        {
            _logger.LogInformation("OrderOperation --- Query N37");
            return _repositories.Orders.GetOrdersrandomassortments();
        }

        public IEnumerable<LateOrders> GetLateOrders()
        {
            _logger.LogInformation("OrderOperation --- Query N41");
            return _repositories.Orders.GetLateOrders();
        }

        public IEnumerable<LateOrdersWhichEmployees> GetWhichEmployees()
        {
            _logger.LogInformation("OrderOperation --- Query N42");
            return _repositories.Orders.whichEmployees();
        }
    }
}
