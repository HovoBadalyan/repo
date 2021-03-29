using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.Entities;
using System.Collections.Generic;

namespace NorthWnd.CORE.Abstractions.Operations
{
    public interface ISupplierOperations
    {
        IEnumerable<SupplierViewModel> GetAll();
        SupplierViewModel Get(int id);
        void Remowe(int id);
        Supplier Add(SupplierViewModel model);
        Supplier Edit(SupplierViewModel model);

    }
}
