using NorthWnd.CORE.Abstractions.Repository;
using NorthWnd.CORE.Entities;


namespace NorthWnd.DAL.Repositories
{
    public class ShipperRepository : RepositoryBase<Shipper>, IShipperRepository
    {
        public ShipperRepository(NORTHWNDContext context) : base(context)
        {
           
        }

       
    }
}
