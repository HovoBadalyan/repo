using NorthWnd.CORE.Abstractions.Repository;
using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NorthWnd.DAL.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(NORTHWNDContext context) : base(context)
        {

        }

        public IEnumerable<ProductsNeedReordering> GetProductsneedreorderings()
        {
            var query = from product in Context.Products
                        where product.UnitsInStock < product.ReorderLevel
                        orderby product.ProductId
                        select new ProductsNeedReordering
                        {
                            Productid = product.ProductId,
                            ProductName = product.ProductName,
                            UnitsInStock = product.UnitsInStock,
                            ReorderLevel = product.ReorderLevel
                        };
            return query.ToList();
                      
        }

        public IEnumerable<ProductsThatNeedReordering> GetProductsthatneedreorderings()
        {
            var query = from product in Context.Products
                        where (product.UnitsInStock + product.UnitsOnOrder) <= product.ReorderLevel
                        where product.Discontinued == false
                        orderby product.ProductId
                        select new ProductsThatNeedReordering
                        {
                            ProductId = product.ProductId,
                            ProductName = product.ProductName,
                            UnitsInStock = product.UnitsInStock,
                            UnitsOnOrder = product.UnitsOnOrder,
                            ReorderLevel = product.ReorderLevel,
                            Discontinued=product.Discontinued
                        };
            return query.ToList();
        }
    }
}
