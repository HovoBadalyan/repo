using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using System.Collections.Generic;

namespace NorthWnd.CORE.Abstractions.Repository
{
    public interface IOrderDetailsRepository : IRepositoryBase<OrderDetail>
    {
        IEnumerable<OrdersAccidentalDoubleEntry> GetDoubleEntries();
        IEnumerable<OrdersAccidentalDoubleEntryDetails> GetDoubleEntriesDetails();
    }
}
