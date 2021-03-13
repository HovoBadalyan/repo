using Northwndarchitect.API.Entities;
using Northwndarchitect.CORE.BusinesModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwndarchitect.CORE.Abstractions.Operations
{
    public interface IOrderDetailsOperations
    {
        IEnumerable<OrderDetailsViewModel> GetOrderDetailsViewModels();
        public OrderDetail GetOrderDetailId(int id);
    }
}
