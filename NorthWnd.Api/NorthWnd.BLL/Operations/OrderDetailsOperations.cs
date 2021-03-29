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
    public class OrderDetailsOperations : IOrderDetailsOperations
    {
        private readonly IRepositoryManager repository;
        private readonly ILogger<OrderDetailsOperations> logger;
        public OrderDetailsOperations(IRepositoryManager manager, ILogger<OrderDetailsOperations> _logger)
        {
            logger = _logger;
            repository = manager;
        }

        public OrderDetail Add(OrderDetailsViewModel model)
        {
            logger.LogInformation("OrderDetailsOparation --- Add method started");

            OrderDetail order = new OrderDetail
            {
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                UnitPrice = model.UnitPrice,
                Quantity = model.Quantity,
                Discount = model.Discount
            };
            repository.OrderDetails.Add(order);
            repository.SaveChanges();

            logger.LogInformation("OrderDetailsOparation --- Add method finished");

            return order;
        }

        public OrderDetail Edit(OrderDetailsViewModel model)
        {
            logger.LogInformation("OrderDetailsOparation --- Edit method started");

            OrderDetail order = new OrderDetail
            {
                OrderId = model.OrderId,
            };

            order.ProductId = model.ProductId;
            order.Discount = model.Discount;
            order.Quantity = model.Quantity;
            order.UnitPrice = model.UnitPrice;

            repository.OrderDetails.Update(order);
            repository.SaveChanges();

            logger.LogInformation("OrderDetailsOparation --- Edit method finished");

            return order;
        }

        public OrderDetailsViewModel Get(int id)
        {
            logger.LogInformation("OrderDetailsOparation --- Get method started");

            var res = repository.OrderDetails.Get(id) ?? throw new LogicException("wrong OrderDetails ID");

            logger.LogInformation("OrderDetailsOparation --- Get method finished");

            return new OrderDetailsViewModel
            {
                Discount = res.Discount,
                OrderId = res.OrderId,
                ProductId = res.ProductId,
                Quantity = res.Quantity,
                UnitPrice = res.UnitPrice
            };
        }

        public IEnumerable<OrderDetailsViewModel> GetAll()
        {
            logger.LogInformation("OrderDetailsOparation --- GetAll method started");

            var data = repository.OrderDetails.GetAll();
            var result = data.Select(x => new OrderDetailsViewModel
            {
                OrderId = x.OrderId,
                Discount = x.Discount,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice

            });

            logger.LogInformation("OrderDetailsOparation --- GetAll method finished");

            return result;
        }

        public IEnumerable<OrdersAccidentalDoubleEntry> GetDoubleEntries()
        {
            logger.LogInformation("OrderDetailsOperation --- Query N38");
            return repository.OrderDetails.GetDoubleEntries();
        }

        public IEnumerable<OrdersAccidentalDoubleEntryDetails> GetDoubleEntriesDetails()
        {
            logger.LogInformation("OrderDetailsOperation --- Query N39");
            return repository.OrderDetails.GetDoubleEntriesDetails();
        }

        public void Remove(int id)
        {
            logger.LogInformation("OrderDetailsOparation --- Remove method started");

            var res = repository.OrderDetails.Get(id);
            repository.OrderDetails.Remove(res);
            repository.SaveChanges();

            logger.LogInformation("OrderDetailsOparation --- Remove method finished");
        }
    }
}
