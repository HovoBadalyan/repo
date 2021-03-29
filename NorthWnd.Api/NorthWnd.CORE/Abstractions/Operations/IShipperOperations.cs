using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using System.Collections.Generic;

namespace NorthWnd.CORE.Abstractions.Operations
{
    public interface IShipperOperations
    {
        IEnumerable<ShipperViewModel> GetAll();
        ShipperViewModel Get(int id);
        void Remove(int id);
        Shipper Add(ShipperViewModel model);
        Shipper Edit(ShipperViewModel model);
        

    }
}
