using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWnd.CORE.BusinessModels.QueryListModel
{
    public class MonthEndOrders
    {
        public int? EmployeeID { get; set; }
        public int? OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
