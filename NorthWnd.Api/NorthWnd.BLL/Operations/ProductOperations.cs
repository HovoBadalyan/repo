using Microsoft.Extensions.Logging;
using NorthWnd.CORE.Abstractions;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using NorthWnd.CORE.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace NorthWnd.BLL.Operations
{
    public class ProductOperations : IProductOperations
    {
        private readonly IRepositoryManager repository;
        private readonly ILogger<ProductOperations> logger;
        public ProductOperations(IRepositoryManager manager, ILogger<ProductOperations> _logger)
        {
            logger = _logger;
            repository = manager;
        }

        public Product Add(ProductViewModel model)
        {
            logger.LogInformation("ProductOperation --- Add method started");

            Product product = new Product
            {
                CategoryId = model.CategoryId,
                Discontinued = model.Discontinued,
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                QuantityPerUnit = model.QuantityPerUnit,
                SupplierId = model.SupplierId,
                ReorderLevel = model.ReorderLevel,
                UnitPrice = model.UnitPrice,
                UnitsOnOrder = model.UnitsOnOrder,
                UnitsInStock = model.UnitsInStock,

            };
            repository.Products.Add(product);
            repository.SaveChanges();

            logger.LogInformation("ProductOperation --- Add method finished");

            return product;
        }

        public Product Edit(ProductViewModel model)
        {
            logger.LogInformation("ProductOperation --- Edit method started");

            Product product = new Product
            {
                ProductId = model.ProductId
            };
            product.ProductName = model.ProductName;
            product.QuantityPerUnit = model.QuantityPerUnit;
            product.SupplierId = model.SupplierId;
            product.UnitPrice = model.UnitPrice;
            product.UnitsInStock = model.UnitsInStock;
            product.UnitsOnOrder = model.UnitsOnOrder;
            product.CategoryId = model.CategoryId;
            product.Discontinued = model.Discontinued;
            product.ReorderLevel = model.ReorderLevel;

            repository.Products.Update(product);
            repository.SaveChanges();

            logger.LogInformation("ProductOperation --- Edit method finished");

            return product;
        }

        public ProductViewModel Get(int id)
        {
            logger.LogInformation("ProductOperation --- Get method started");

            var result = repository.Products.Get(id) ?? throw new LogicException("tvyal id goyutyun chuni");

            logger.LogInformation("ProductOperation --- Get method finished");

            return new ProductViewModel
            {
                CategoryId = result.CategoryId,
                Discontinued = result.Discontinued,
                ProductId = result.ProductId,
                ProductName = result.ProductName,
                QuantityPerUnit = result.QuantityPerUnit,
                ReorderLevel = result.ReorderLevel,
                SupplierId = result.SupplierId,
                UnitPrice = result.UnitPrice,
                UnitsInStock = result.UnitsInStock,
                UnitsOnOrder = result.UnitsOnOrder
            };
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            logger.LogInformation("ProductOperation --- GetAll method started");

            var data = repository.Products.GetAll();
            var result = data.Select(x => new ProductViewModel
            {
                CategoryId = x.CategoryId,
                Discontinued = x.Discontinued,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                QuantityPerUnit = x.QuantityPerUnit,
                ReorderLevel = x.ReorderLevel,
                SupplierId = x.SupplierId,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                UnitsOnOrder = x.UnitsOnOrder
            });

            logger.LogInformation("ProductOperation --- GetAll method finished");

            return result;
        }

        public IEnumerable<ProductsNeedReordering> GetProductsneedreorderings()
        {
            logger.LogInformation("ProductOperation --- Query N22");
            return repository.Products.GetProductsneedreorderings();
        }

        public IEnumerable<ProductsThatNeedReordering> GetProductsthatneedreorderings()
        {
            logger.LogInformation("ProductOperation --- Query N23");
            return repository.Products.GetProductsthatneedreorderings();
        }

        public void Remove(int id)
        {
            logger.LogInformation("ProductOperation --- Remove method started");

            var res = repository.Products.Get(id);
            repository.Products.Remove(res);
            repository.SaveChanges();

            logger.LogInformation("ProductOperation --- Remove method finished");
        }
    }
}
