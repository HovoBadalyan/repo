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
    public class ShipperOperations : IShipperOperations
    {
        private readonly IRepositoryManager repository;
        private readonly ILogger<ShipperOperations> logger;
        public ShipperOperations(IRepositoryManager manager, ILogger<ShipperOperations> _logger)
        {
            logger = _logger;
            repository = manager;
        }

        public Shipper Add(ShipperViewModel model)
        {
            logger.LogInformation("ShipperOperation --- Add method started");

            Shipper shipper = new Shipper
            {
                ShipperId = model.ShipperId,
                CompanyName = model.CompanyName,
                Phone=model.Phone
            };
            repository.Shippers.Add(shipper);
            repository.SaveChanges();

            logger.LogInformation("ShipperOperation --- Add method finished");

            return shipper;
        }

        public Shipper Edit(ShipperViewModel model)
        {
            logger.LogInformation("ShipperOperation --- Edit method started");

            Shipper shipper = new Shipper
            {
                ShipperId = model.ShipperId
            };
            shipper.Phone = model.Phone;
            shipper.CompanyName = model.CompanyName;

            repository.Shippers.Update(shipper);
            repository.SaveChanges();

            logger.LogInformation("ShipperOperation --- Edit method finished");

            return shipper;
        }

        public ShipperViewModel Get(int id)
        {
            logger.LogInformation("ShipperOperation --- Get method started");

            var result = repository.Shippers.Get(id) ?? throw new LogicException("wrong Shipper Id");

            logger.LogInformation("ShipperOperation --- Add method finished");

            return new ShipperViewModel
            {
                CompanyName = result.CompanyName,
                Phone = result.Phone,
                ShipperId = result.ShipperId
            };
        }

        public IEnumerable<ShipperViewModel> GetAll()
        {
            logger.LogInformation("ShipperOperation --- GetAll method started");

            var dat = repository.Shippers.GetAll();
            var result = dat.Select(x => new ShipperViewModel
            {
                ShipperId = x.ShipperId,
                CompanyName = x.CompanyName,
                Phone = x.Phone
            });

            logger.LogInformation("ShipperOperation --- GetAll method finished");

            return result;
        }

       
        public void Remove(int id)
        {
            logger.LogInformation("ShipperOperation --- Remove method started");

            var result = repository.Shippers.Get(id);
            repository.Shippers.Remove(result);
            repository.SaveChanges();

            logger.LogInformation("ShipperOperation --- Remove method finished");
        }
    }
}
