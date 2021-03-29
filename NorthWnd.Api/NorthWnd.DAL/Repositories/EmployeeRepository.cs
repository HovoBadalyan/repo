using NorthWnd.CORE.Abstractions.Repository;
using NorthWnd.CORE.Entities;

namespace NorthWnd.DAL.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(NORTHWNDContext context) : base(context)
        {

        }
    }
}
