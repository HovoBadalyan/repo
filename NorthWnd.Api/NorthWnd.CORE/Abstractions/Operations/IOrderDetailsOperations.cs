using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using System.Collections.Generic;

namespace NorthWnd.CORE.Abstractions.Operations
{
    public interface IOrderDetailsOperations
    {
        IEnumerable<OrdersAccidentalDoubleEntry> GetDoubleEntries();
        IEnumerable<OrdersAccidentalDoubleEntryDetails> GetDoubleEntriesDetails();
        IEnumerable<OrderDetailsViewModel> GetAll();
        OrderDetailsViewModel Get(int id);
        void Remove(int id);
        OrderDetail Add(OrderDetailsViewModel model);
        OrderDetail Edit(OrderDetailsViewModel model);
    }
}
