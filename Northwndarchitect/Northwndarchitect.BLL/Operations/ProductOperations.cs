using Northwndarchitect.API.Entities;
using Northwndarchitect.CORE.Abstractions.Operations;
using Northwndarchitect.CORE.BusinesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwndarchitect.BLL.Operations
{
    public class ProductOperations:IProductOperations
    {
        private readonly NORTHWNDContext context;
        public ProductOperations(NORTHWNDContext context )
        {
            this.context = context;
        }


        public IEnumerable<ProductViewModel> GetProducts()
        {
            var data = context.Products.ToList();
            var res = data.Select(x => new ProductViewModel
            {
                ProductId = x.ProductId,
                CategoryId = x.CategoryId,
                Discontinued = x.Discontinued,
                ProductName = x.ProductName,
                QuantityPerUnit = x.QuantityPerUnit,
                ReorderLevel = x.ReorderLevel,
                SupplierId = x.SupplierId,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                UnitsOnOrder = x.UnitsOnOrder
            });
            return res;
        }
        public Product GetProductId(int id)
        {
            var res=context.Products.Find(id);
            return res;
        }

    }
}
