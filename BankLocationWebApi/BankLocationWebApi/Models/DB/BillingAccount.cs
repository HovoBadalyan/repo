using System;
using System.Collections.Generic;

#nullable disable

namespace BankLocationWebApi.Models.DB
{
    public partial class BillingAccount
    {
        public int BillingId { get; set; }
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public int BillAmount { get; set; }
        public string Comments { get; set; }
        public int? CustomersCustomerId { get; set; }
        public int? AccountsAccountId { get; set; }

        public virtual Account AccountsAccount { get; set; }
        public virtual Customer CustomersCustomer { get; set; }
    }
}
