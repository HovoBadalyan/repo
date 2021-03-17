using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerArchitecure.Core.BusinessModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
    }
}
