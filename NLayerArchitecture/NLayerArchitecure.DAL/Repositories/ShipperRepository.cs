using NLayerArchitecure.Core.Abstractions.Repositories;
using NLayerArchitecure.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerArchitecure.DAL.Repositories
{
    public class ShipperRepository:RepositoryBase<Shipper> , IShipperRepository
    {
        public ShipperRepository(NORTHWNDContext context):base(context)
        {

        }
    }
}
