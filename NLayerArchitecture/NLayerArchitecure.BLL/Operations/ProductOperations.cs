using NLayerArchitecure.Core.Abstractions.Operations;
using NLayerArchitecure.Core.Abstractions.Repositories;
using NLayerArchitecure.Core.BusinessModels;
using NLayerArchitecure.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLayerArchitecure.BLL.Operations
{
    public class ProductOperations : IProductOperations
    {
        private readonly IProductRepository productRepository;
        public ProductOperations(IProductRepository product)
        {
            productRepository = product;
        }

        public Product AddProduct(ProductViewModel productView)
        {
            Product product=new Product
            {
                CategoryId=productView.CategoryId,
                Discontinued=productView.Discontinued,
                ProductId=productView.ProductId,
                ProductName=productView.ProductName,
                QuantityPerUnit=productView.QuantityPerUnit,
                SupplierId=productView.SupplierId,
                UnitPrice=productView.UnitPrice,
                ReorderLevel=productView.ReorderLevel
            };
            productRepository.Add(product);
            productRepository.SaveChanges();
            return product;
        }

        public Product GetProductid(int id)
        {
           var res=productRepository.Get(id);
            return res;
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            var data=productRepository.GetAll();
            var res = data.Select(x => new ProductViewModel
            {
                CategoryId = x.CategoryId,
                Discontinued=x.Discontinued,
                ProductId=x.ProductId,
                ProductName=x.ProductName,
                QuantityPerUnit=x.QuantityPerUnit,
                ReorderLevel=x.ReorderLevel,
                SupplierId=x.SupplierId,
                UnitPrice=x.UnitPrice,
                UnitsInStock=x.UnitsInStock,
                UnitsOnOrder=x.UnitsOnOrder
            });
            return res;
        }

        public Product RemoveProduct(int id)
        {
            var res=productRepository.Get(id);
            productRepository.Remove(res);
            productRepository.SaveChanges();
            return res;
        }

        public Product UpdateProduct(ProductViewModel productView)
        {
            Product product = new Product
            {
                ProductId = productView.ProductId
            };
            if (productView.ProductName!=null)
            {
                product.ProductName = productView.ProductName;
            }
            if (productView.QuantityPerUnit!=null)
            {
                product.QuantityPerUnit = productView.QuantityPerUnit;
            }
            if (productView.UnitPrice!=null)
            {
                product.UnitPrice = productView.UnitPrice;
            }
            productRepository.Update(product);
            productRepository.SaveChanges();
            return product;
        }
    }
}
