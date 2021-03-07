using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankLocationWebApi.Filter
{
    public class AccFilter
    {
        public int? AccountId { get; set; }
        public int? AccountNumber { get; set; }
        public int? Balance { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
