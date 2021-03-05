using System;
using System.Collections.Generic;

#nullable disable

namespace BankLocationWebApi.Models.DB
{
    public partial class BankLocation
    {
        public BankLocation()
        {
            Customers = new HashSet<Customer>();
        }

        public int BranchId { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
