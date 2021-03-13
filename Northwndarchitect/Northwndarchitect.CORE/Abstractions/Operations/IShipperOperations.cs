using Northwndarchitect.API.Entities;
using Northwndarchitect.CORE.BusinesModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Northwndarchitect.CORE.Abstractions.Operations
{
    public interface IShipperOperations
    {
        IEnumerable<ShipperViewModel> GetShippers();
        public Shipper GetShipperId(int id);
        //delete 
        //public Shipper RemoweShipper(int id);
    }
}
