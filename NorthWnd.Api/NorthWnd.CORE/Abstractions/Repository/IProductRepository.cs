using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using System;
using System.Collections.Generic;

namespace NorthWnd.CORE.Abstractions.Repository
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<ProductsNeedReordering> GetProductsneedreorderings();
        IEnumerable<ProductsThatNeedReordering> GetProductsthatneedreorderings();
    }
}
