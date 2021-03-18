using NLayerArchitecure.Core.Abstractions;
using NLayerArchitecure.Core.Abstractions.Operations;
using NLayerArchitecure.Core.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLayerArchitecure.BLL.Operations
{
    public class ProductOperations : IProductOperations
    {
        private readonly IRepositoryManager repositoryManager;
        public ProductOperations(IRepositoryManager repository)
        {
            repositoryManager=repository;
        }
        public ProductViewModel AddProduct()
        {
            throw new NotImplementedException();
        }

        public ProductViewModel EditProduct()
        {
            throw new NotImplementedException();
        }

        public ProductViewModel GetProductid()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            var data = repositoryManager.Products.GetAll();
            var res = data.Select(x => new ProductViewModel
            {
                CategoryId=x.CategoryId,
                Discontinued=x.Discontinued,
                ProductId=x.ProductId,
                ProductName=x.ProductName,
                UnitPrice=x.UnitPrice,
                UnitsInStock=x.UnitsInStock,
                UnitsOnOrder=x.UnitsOnOrder,
                QuantityPerUnit=x.QuantityPerUnit
            });
            return res;
            
        }

        public ProductViewModel RemoweProduct()
        {
            throw new NotImplementedException();
        }
    }
}
