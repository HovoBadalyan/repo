using NorthWnd.CORE.Abstractions.Repository;
using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthWnd.DAL.Repositories
{
    public class OrderDetailsRepository : RepositoryBase<OrderDetail>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(NORTHWNDContext context) : base(context)
        {
        }



        //38
        public IEnumerable<OrdersAccidentalDoubleEntry> GetDoubleEntries()
        {
            var query = from orddet in Context.OrderDetails
                        where orddet.Quantity >= 60
                        group orddet by new { orddet.OrderId, orddet.Quantity } into g
                        where g.Count() > 1
                        select new OrdersAccidentalDoubleEntry
                        {
                            OrderId = g.Key.OrderId
                        };
            return query.ToList();
        }



        //39
        public IEnumerable<OrdersAccidentalDoubleEntryDetails> GetDoubleEntriesDetails()
        {
            var query = from order in Context.OrderDetails
                        where order.Quantity >= 60
                        group order by new { order.OrderId, order.Quantity } into g
                        where g.Count() >1
                        select g.Key.OrderId;
            var res = from order in Context.OrderDetails
                      where query.Contains(order.OrderId)
                      select new OrdersAccidentalDoubleEntryDetails
                      {
                          OrderId = order.OrderId,
                          Discount = order.Discount,
                          ProductId = order.ProductId,
                          Quantity = order.Quantity,
                          UnitPrice = order.UnitPrice
                      };
            return res.ToList();
        }
    }
}
