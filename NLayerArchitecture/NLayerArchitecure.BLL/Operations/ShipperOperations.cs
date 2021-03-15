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
    public class ShipperOperations : IShipperOperations
    {
        private readonly IShipperRepository shipperRepository;
        public ShipperOperations(IShipperRepository shipper)
        {
            shipperRepository = shipper;
        }

        public Shipper AddShipper(ShipperViewModel shipperView)
        {
            Shipper shipper=new Shipper 
            {
                CompanyName=shipperView.CompanyName,
                Phone=shipperView.Phone,
                ShipperId=shipperView.ShipperId
            };
            shipperRepository.Add(shipper);
            shipperRepository.SaveChanges();
            return shipper;
        }

        public Shipper GetShipperid(int id)
        {
            var res=shipperRepository.Get(id);
            return res;
        }

        public IEnumerable<ShipperViewModel> GetShippers()
        {
            var data=shipperRepository.GetAll();
            var res = data.Select(x => new ShipperViewModel 
            {
                CompanyName=x.CompanyName,
                Phone=x.Phone,
                ShipperId=x.ShipperId
            });
            return res;
        }

        public Shipper RemoveShipper(int id)
        {
            var res=shipperRepository.Get(id);
            shipperRepository.Remove(res);
            return res;
        }

        public Shipper UpdateShipper(ShipperViewModel shipperView)
        {
            Shipper shipper=new Shipper 
            {
                ShipperId=shipperView.ShipperId
            };
            if (shipperView.CompanyName != null)
                shipper.CompanyName = shipperView.CompanyName;
            if (shipperView.Phone != null)
                shipper.Phone = shipperView.Phone;
            shipperRepository.Update(shipper);
            shipperRepository.SaveChanges();
            return shipper;
        }
    }
}
