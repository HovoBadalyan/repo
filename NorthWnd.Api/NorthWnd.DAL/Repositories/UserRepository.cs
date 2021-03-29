using NorthWnd.CORE.Abstractions.Repository;
using NorthWnd.CORE.Entities;

namespace NorthWnd.DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(NORTHWNDContext context)
            : base(context)
        {

        }
    }
}
