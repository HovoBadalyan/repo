using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BankLocationWebApi.Models.DB
{
    public partial class Customer
    {
        public Customer()
        {
            Accounts = new HashSet<Account>();
            BillingAccounts = new HashSet<BillingAccount>();
        }

        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public string ContactInfo { get; set; }
        public int? BankLocationsBranchId { get; set; }

        public virtual BankLocation BankLocationsBranch { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<BillingAccount> BillingAccounts { get; set; }
    }
}
