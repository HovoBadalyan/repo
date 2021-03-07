using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankLocationWebApi.Filter
{
    public class BankLocFilter
    {
        public int? BranchId { get; set; }
        public string Address { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
