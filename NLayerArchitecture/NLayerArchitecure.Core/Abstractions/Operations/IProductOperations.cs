using NLayerArchitecure.Core.BusinessModels;
using NLayerArchitecure.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerArchitecure.Core.Abstractions.Operations
{
    public interface IProductOperations
    {
        IEnumerable<ProductViewModel> GetProducts();
        public Product GetProductid(int id);
        public Product UpdateProduct(ProductViewModel productView);
        public Product AddProduct(ProductViewModel productView);
        public Product RemoveProduct(int id);
    }
}
