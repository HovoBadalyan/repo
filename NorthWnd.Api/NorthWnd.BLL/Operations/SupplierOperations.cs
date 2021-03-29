using Microsoft.Extensions.Logging;
using NorthWnd.CORE.Abstractions;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.Entities;
using NorthWnd.CORE.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace NorthWnd.BLL.Operations
{
    public class SupplierOperations : ISupplierOperations
    {
        private readonly IRepositoryManager repository;
        private readonly ILogger<SupplierOperations> logger;
        public SupplierOperations(IRepositoryManager manager, ILogger<SupplierOperations> _logger)
        {
            logger = _logger;
            repository = manager;
        }

        public Supplier Add(SupplierViewModel model)
        {
            logger.LogInformation("SupplierOperation --- Add method started");

            Supplier supplier = new Supplier
            {
                Address = model.Address,
                City=model.City,
                CompanyName=model.CompanyName,
                ContactName=model.ContactName,
                ContactTitle=model.ContactTitle,
                Country=model.Country,
                Fax=model.Fax,
                HomePage=model.HomePage,
                Phone=model.Phone,
                PostalCode=model.PostalCode,
                SupplierId=model.SupplierId,
                Region=model.Region
            };
            repository.Suppliers.Add(supplier);
            repository.SaveChanges();

            logger.LogInformation("SupplierOperation --- Add method finished");

            return supplier;
        }

        public Supplier Edit(SupplierViewModel model)
        {
            logger.LogInformation("SupplierOperation --- Edit method started");

            Supplier supplier = new Supplier
            {
                SupplierId = model.SupplierId
            };
            supplier.Address = model.Address;
            supplier.City = model.City;
            supplier.CompanyName = model.CompanyName;
            supplier.ContactName = model.ContactName;
            supplier.ContactTitle = model.ContactTitle;
            supplier.Country = model.Country;
            supplier.Fax = model.Fax;
            supplier.HomePage = model.HomePage;
            supplier.Phone = model.Phone;
            supplier.PostalCode = model.PostalCode;
            supplier.Region = model.Region;
            supplier.SupplierId = model.SupplierId;

            repository.Suppliers.Update(supplier);
            repository.SaveChanges();

            logger.LogInformation("SupplierOperation --- Edit method finished");

            return supplier;

        }

        public SupplierViewModel Get(int id)
        {
            logger.LogInformation("SupplierOperation --- Get method started");

            var result = repository.Suppliers.Get(id) ?? throw new LogicException("tvyal id goyutyun chuni");

            logger.LogInformation("SupplierOperation --- Get method finished");

            return new SupplierViewModel
            {
                Address = result.Address,
                City = result.City,
                CompanyName = result.CompanyName,
                ContactName = result.ContactName,
                ContactTitle = result.ContactTitle,
                Country = result.Country,
                Fax = result.Fax,
                HomePage = result.HomePage,
                Phone = result.Phone,
                PostalCode = result.PostalCode,
                Region = result.Region,
                SupplierId = result.SupplierId
            };
        }

        public IEnumerable<SupplierViewModel> GetAll()
        {
            logger.LogInformation("SupplierOperation --- GetAll method started");

            var data = repository.Suppliers.GetAll();
            var result = data.Select(x => new SupplierViewModel
            {
                Address = x.Address,
                City = x.City,
                CompanyName = x.CompanyName,
                ContactName = x.ContactName,
                ContactTitle = x.ContactTitle,
                Country = x.Country,
                Fax = x.Fax,
                HomePage = x.HomePage,
                Phone = x.Phone,
                PostalCode = x.PostalCode,
                Region = x.Region,
                SupplierId = x.SupplierId
            });
            logger.LogInformation("SupplierOperation --- GetAll method finished");

            return result;
        }

        public void Remowe(int id)
        {
            logger.LogInformation("SupplierOperation --- Remove method started");

            var result = repository.Suppliers.Get(id);
            repository.Suppliers.Remove(result);
            repository.SaveChanges();

            logger.LogInformation("SupplierOperation --- Remove method finished");
        }
    }
}
