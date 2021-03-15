using NLayerArchitecure.Core.BusinessModels;
using NLayerArchitecure.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerArchitecure.Core.Abstractions.Operations
{
    public interface IShipperOperations
    {
        IEnumerable<ShipperViewModel> GetShippers();
        public Shipper GetShipperid(int id);
        public Shipper UpdateShipper(ShipperViewModel shipperView);
        public Shipper AddShipper(ShipperViewModel shipperView);
        public Shipper RemoveShipper(int id);
    }
}
