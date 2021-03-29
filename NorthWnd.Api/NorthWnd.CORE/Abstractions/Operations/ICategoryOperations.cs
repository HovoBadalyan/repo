using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using System.Collections.Generic;
namespace NorthWnd.CORE.Abstractions.Operations
{
    public interface ICategoryOperations
    {
        IEnumerable<CategoryandTotalProducts> GetCategoryandtotalProducts();
        IEnumerable<CategoryViewModel> GetAll();
        CategoryViewModel Get(int id);
        void Remove(int id);
        Category Edit(CategoryViewModel model);
        Category Add(CategoryViewModel model);
    }
}
