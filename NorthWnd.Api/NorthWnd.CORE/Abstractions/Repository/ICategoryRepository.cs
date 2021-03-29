using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using System.Collections.Generic;

namespace NorthWnd.CORE.Abstractions.Repository
{
    public interface ICategoryRepository:IRepositoryBase <Category>
    {
        IEnumerable<CategoryandTotalProducts> GetCategoryandtotalProducts();
      
    }
}
