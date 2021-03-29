using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using System.Collections.Generic;

namespace NorthWnd.CORE.Abstractions.Operations
{
    public interface IProductOperations
    {
        IEnumerable<ProductsNeedReordering> GetProductsneedreorderings();
        IEnumerable<ProductsThatNeedReordering> GetProductsthatneedreorderings();
        IEnumerable<ProductViewModel> GetAll();
        ProductViewModel Get(int id);
        void Remove(int id);
        Product Add(ProductViewModel model);
        Product Edit(ProductViewModel model);

    }
}
