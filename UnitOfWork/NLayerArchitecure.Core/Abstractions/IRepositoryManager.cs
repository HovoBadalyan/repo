using NLayerArchitecure.Core.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArchitecure.Core.Abstractions
{
    public interface IRepositoryManager
    {
        public IOrderRepository Orders { get; }


        public IDatabaseTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
