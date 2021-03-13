using Northwndarchitect.API.Entities;
using Northwndarchitect.CORE.Abstractions.Operations;
using Northwndarchitect.CORE.BusinesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwndarchitect.BLL.Operations
{
    public class ShipperOperations:IShipperOperations
    {
        private readonly NORTHWNDContext context;
        public ShipperOperations(NORTHWNDContext context)
        {
            this.context = context;
        }
        public IEnumerable<ShipperViewModel> GetShippers()
        {
            var data = context.Shippers.ToList();
            var res = data.Select(x => new ShipperViewModel
            {
                ShipperId=x.ShipperId,
                CompanyName=x.CompanyName,
                Phone=x.Phone
            });
            return res;
        }
        public Shipper GetShipperId(int id)
        {
            
            var shipper = context.Shippers.Find(id);
         
            return shipper;
        }
        //delete
        //public Shipper RemoweShipper(int id)
        //{
        //    var res=context.Shippers.Find(id);
        //    var result = context.Shippers.Remove(res);
        //    return result;
        //}
    }
}
