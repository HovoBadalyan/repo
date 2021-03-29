using NorthWnd.CORE.Abstractions;
using NorthWnd.CORE.Abstractions.Repository;
using NorthWnd.CORE.Entities;
using NorthWnd.DAL.Repositories;
using System.Data;
using System.Threading.Tasks;

namespace NorthWnd.DAL
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly NORTHWNDContext _dbContext;

        public RepositoryManager(NORTHWNDContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IOrderRepository _orders;
        public IOrderRepository Orders => _orders ??= new OrderRepository(_dbContext);


        private IUserRepository _users;
        public IUserRepository Users => _users ??= new UserRepository(_dbContext);


        private IProductRepository product;
        public IProductRepository Products => product ??= new ProductRepository(_dbContext);


        private IRegionRepository region;
        public IRegionRepository Regions => region ??= new RegionRepository(_dbContext);


        private IShipperRepository shipper;
        public IShipperRepository Shippers => shipper ??= new ShipperRepository(_dbContext);


        private ISupplierRepository supplier;
        public ISupplierRepository Suppliers => supplier ??= new SupplierRepository(_dbContext);


        private IEmployeeRepository employee;
        public IEmployeeRepository Employees => employee ??= new EmployeeRepository(_dbContext);


        private IOrderDetailsRepository orderDetails;
        public IOrderDetailsRepository OrderDetails => orderDetails ??= new OrderDetailsRepository(_dbContext);


        private ICustomerRepository customer;
        public ICustomerRepository Customers => customer ??= new CustomerRepository(_dbContext);


        private ICategoryRepository category;
        public ICategoryRepository Categories => category ??= new CategoryRepository(_dbContext);




        public IDatabaseTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return new DatabaseTransaction(_dbContext, isolationLevel);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
