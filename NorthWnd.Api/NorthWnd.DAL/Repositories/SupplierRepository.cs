using NorthWnd.CORE.Abstractions.Repository;
using NorthWnd.CORE.Entities;

namespace NorthWnd.DAL.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(NORTHWNDContext context) : base(context)
        {

        }
    }
}
