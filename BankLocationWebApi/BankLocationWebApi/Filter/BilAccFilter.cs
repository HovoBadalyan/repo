using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankLocationWebApi.Filter
{
    public class BilAccFilter
    {
        public int? BillingId { get; set; }
        public int? BillAmount { get; set; }
        public string Comments { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
