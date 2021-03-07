using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string Address { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
