using NLayerArchitecure.Core.Abstractions;
using NLayerArchitecure.Core.Abstractions.Repositories;
using NLayerArchitecure.DAL.Repositories;
using System;
using System.Data;
using System.Threading.Tasks;

namespace NLayerArchitecure.DAL
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly NORTHWNDContext _dbContext;
        // private readonly IServiceProvider _serviceProvider;

        public RepositoryManager(NORTHWNDContext dbContext/*, IServiceProvider serviceProvider*/)
        {
            _dbContext = dbContext;
            //    _serviceProvider = serviceProvider;
        }

        private IOrderRepository _orders;
        //public IOrderRepository Orders
        //{
        //    get
        //    {
        //        if (_orders == null)
        //        {
        //            _orders = new OrderRepository(_dbContext);
        //        }
        //        return _orders;
        //    }
        //}
        public IOrderRepository Orders => _orders ?? (_orders = new OrderRepository(_dbContext));
        // public IOrderRepository Orders => _orders ?? (_orders = (IOrderRepository)_serviceProvider.GetService(typeof(IOrderRepository)));

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
