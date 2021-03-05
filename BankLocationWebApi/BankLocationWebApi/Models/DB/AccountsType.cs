using System;
using System.Collections.Generic;

#nullable disable

namespace BankLocationWebApi.Models.DB
{
    public partial class AccountsType
    {
        public AccountsType()
        {
            Accounts = new HashSet<Account>();
        }

        public int AccountTypeId { get; set; }
        public int AccountType { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
