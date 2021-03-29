using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.Entities;
using System.Collections.Generic;

namespace NorthWnd.CORE.Abstractions.Operations
{
    public interface IRegionOperations
    {
        IEnumerable<RegionViewModel> GetAll();
        RegionViewModel Get(int id);
        void Remove(int id);
        Region Add(RegionViewModel model);
        Region Edit(RegionViewModel model);

    }
}
