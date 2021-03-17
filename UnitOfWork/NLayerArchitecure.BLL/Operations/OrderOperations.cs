using NLayerArchitecure.Core.Abstractions;
using NLayerArchitecure.Core.Abstractions.Operations;
using NLayerArchitecure.Core.Abstractions.Repositories;
using NLayerArchitecure.Core.BusinessModels;
using System.Collections.Generic;
using System.Linq;

namespace NLayerArchitecure.BLL.Operations
{
    public class OrderOperations : IOrderOperations
    {
        private readonly IRepositoryManager _repositories;

        public OrderOperations(IRepositoryManager repositories)
        {
            _repositories = repositories;
        }

        public IEnumerable<InventoryListModel> GetInventoryList()
        {
            return _repositories.Orders.GetInventoryList();
        }

        public IEnumerable<OrderViewModel> GetOrders()
        {
            var data = _repositories.Orders.GetAll();

            var result = data.Select(x => new OrderViewModel
            {
                CustomerId = x.CustomerId,
                EmployeeId = x.EmployeeId,
                OrderId = x.OrderId,
                ShipAddress = x.ShipAddress,
                ShipName = x.ShipName
            });
            return result;
        }

        public void Test()
        {
            using (var transaction = _repositories.BeginTransaction())
            {
                try
                {
                    //add
                    //remove
                    //delete
                    _repositories.SaveChanges();
                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
