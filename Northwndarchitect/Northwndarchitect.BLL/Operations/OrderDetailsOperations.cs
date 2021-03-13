using Northwndarchitect.API.Entities;
using Northwndarchitect.CORE.Abstractions.Operations;
using Northwndarchitect.CORE.BusinesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwndarchitect.BLL.Operations
{
    public class OrderDetailsOperations : IOrderDetailsOperations
    {
        private readonly NORTHWNDContext context;
        public OrderDetailsOperations(NORTHWNDContext orderDetails)
        {
            context = orderDetails;
        }

        

        public IEnumerable<OrderDetailsViewModel> GetOrderDetailsViewModels()
        {
            var data = context.OrderDetails.ToList();
            var res = data.Select(x => new OrderDetailsViewModel
            {
                Discount=x.Discount,
                OrderId=x.OrderId,
                ProductId=x.ProductId,
                Quantity=x.Quantity,
                UnitPrice=x.UnitPrice
            });
            return res;
        }
        public OrderDetail GetOrderDetailId(int id)
        {
            var result=context.OrderDetails.Find(id);
            return result;
        }
    }
}
