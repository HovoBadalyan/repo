using NLayerArchitecure.Core.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerArchitecure.Core.Abstractions.Operations
{
    public interface IProductOperations
    {
        IEnumerable<ProductViewModel> GetProducts();
        ProductViewModel GetProductid();
        ProductViewModel RemoweProduct();
        ProductViewModel AddProduct();
        ProductViewModel EditProduct();

    }
}
