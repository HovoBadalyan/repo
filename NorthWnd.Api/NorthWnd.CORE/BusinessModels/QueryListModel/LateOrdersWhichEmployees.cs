using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWnd.CORE.BusinessModels.QueryListModel
{
    public class LateOrdersWhichEmployees
    {
        public int? EmployeeId { get; set; }
        public string LastName { get; set; }
        public int TotalLateOrders { get; set; }
    }
}
