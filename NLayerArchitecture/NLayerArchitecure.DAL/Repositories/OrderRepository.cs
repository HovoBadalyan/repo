using Microsoft.EntityFrameworkCore;
using NLayerArchitecure.Core.Abstractions.Repositories;
using NLayerArchitecure.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NLayerArchitecure.Core.BusinessModels;

namespace NLayerArchitecure.DAL.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(NORTHWNDContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<InventoryListModel> GetInventoryList()
        {
            var query = from order in Context.Orders
                        join employee in Context.Employees on order.EmployeeId equals employee.EmployeeId
                        join orderDetail in Context.OrderDetails on order.OrderId equals orderDetail.OrderId
                        join product in Context.Products on orderDetail.ProductId equals product.ProductId
                        orderby order.OrderId, product.ProductId
                        select new InventoryListModel
                        {
                            EmployeeId = employee.EmployeeId,
                            LastName = employee.LastName,
                            OrderId = order.OrderId,
                            ProductName = product.ProductName,
                            Quantity = orderDetail.Quantity
                        };

            return query.ToList();
        }
    }
}
