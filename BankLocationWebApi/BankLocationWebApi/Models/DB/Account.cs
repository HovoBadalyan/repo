using System;
using System.Collections.Generic;

#nullable disable

namespace BankLocationWebApi.Models.DB
{
    public partial class Account
    {
        public Account()
        {
            BillingAccounts = new HashSet<BillingAccount>();
        }

        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public int AccountTypeId { get; set; }
        public int AccountNumber { get; set; }
        public int Balance { get; set; }
        public int? CustomersCustomerId { get; set; }
        public int? AccountsTypeAccountTypeId { get; set; }

        public virtual AccountsType AccountsTypeAccountType { get; set; }
        public virtual Customer CustomersCustomer { get; set; }
        public virtual ICollection<BillingAccount> BillingAccounts { get; set; }
    }
}
