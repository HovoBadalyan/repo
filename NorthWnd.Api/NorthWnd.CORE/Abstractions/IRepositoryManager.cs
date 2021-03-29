using NorthWnd.CORE.Abstractions.Repository;
using System.Data;
using System.Threading.Tasks;

namespace NorthWnd.CORE.Abstractions
{
    public interface IRepositoryManager
    {
        public IOrderRepository Orders { get; }
        public IUserRepository Users { get; }
        public IProductRepository Products { get; }
        public IRegionRepository Regions { get; }
        public IShipperRepository Shippers { get; }
        public ISupplierRepository Suppliers { get; }
        public IEmployeeRepository Employees { get; }
        public IOrderDetailsRepository OrderDetails { get; }
        public ICustomerRepository Customers { get; }
        public ICategoryRepository Categories { get; }

        public IDatabaseTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
