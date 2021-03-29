using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWnd.CORE.BusinessModels.QueryListModel
{
    public class OrdersWithManyLineItems
    {
        public int OrderId { get; set; }
        public int TotalOrderDetails { get; set; }
    }
}
