using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWnd.CORE.BusinessModels.QueryListModel
{
    public class HighValueCustomerswithdiscount
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public decimal TotalsWithtDiscount { get; set; }
        public decimal TotalWithoutDiscount { get; set; }
    }
}
