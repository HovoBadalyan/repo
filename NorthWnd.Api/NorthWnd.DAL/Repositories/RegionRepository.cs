using NorthWnd.CORE.Abstractions.Repository;
using NorthWnd.CORE.Entities;

namespace NorthWnd.DAL.Repositories
{
    public class RegionRepository : RepositoryBase<Region>, IRegionRepository
    {
        public RegionRepository(NORTHWNDContext context) : base(context)
        {

        }
    }
}
