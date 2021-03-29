using NorthWnd.CORE.Abstractions.Repository;
using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NorthWnd.DAL.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(NORTHWNDContext context) : base(context)
        { }
        public IEnumerable<CategoryandTotalProducts> GetCategoryandtotalProducts()
        {
            var query = (from category in Context.Categories
                         join product in Context.Products on category.CategoryId equals product.CategoryId
                         group category by category.CategoryName into g
                         select new CategoryandTotalProducts
                         {
                             CategoryName = g.Key,
                             TotalProducts = g.Count()
                         }).OrderByDescending(x=>x.TotalProducts);
            return query.ToList();
        }

    
    }
}
