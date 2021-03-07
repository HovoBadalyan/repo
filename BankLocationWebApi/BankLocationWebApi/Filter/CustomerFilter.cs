using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankLocationWebApi.Filter
{
    public class CustomerFilter
    {
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ContactInfo { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
