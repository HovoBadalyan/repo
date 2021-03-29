using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWnd.CORE.BusinessModels.QueryListModel
{
    public class HighValueCustomers
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public int OrderId { get; set; }
        public decimal OrderIdTotalOrderAmount { get; set; }
    }
}
