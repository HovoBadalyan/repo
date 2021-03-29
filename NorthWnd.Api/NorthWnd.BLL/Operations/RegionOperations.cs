using Microsoft.Extensions.Logging;
using NorthWnd.CORE.Abstractions;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.Entities;
using NorthWnd.CORE.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace NorthWnd.BLL.Operations
{
    public class RegionOperations : IRegionOperations
    {
        private readonly IRepositoryManager repository;
        private readonly ILogger<RegionOperations> logger;
        public RegionOperations(IRepositoryManager manager, ILogger<RegionOperations> _logger)
        {
            logger = _logger;
            repository = manager;
        }

        public Region Add(RegionViewModel model)
        {
            logger.LogInformation("RegionOperations --- Add method started");

            Region region = new Region
            {
                RegionDescription = model.RegionDescription,
                RegionId = model.RegionId
            };
            repository.Regions.Add(region);
            repository.SaveChanges();

            logger.LogInformation("RegionOperations --- Add method finished");

            return region;
        }

        public Region Edit(RegionViewModel model)
        {
            logger.LogInformation("RegionOperations --- Edit method started");

            Region region = new Region
            {
                RegionId = model.RegionId
            };
            region.RegionDescription = model.RegionDescription;
            repository.Regions.Update(region);
            repository.SaveChanges();

            logger.LogInformation("RegionOperations --- Edit method finished");

            return region;
        }

        public RegionViewModel Get(int id)
        {
            logger.LogInformation("RegionOperations --- Get method started");

            var result = repository.Regions.Get(id) ?? throw new LogicException("wrong Region ID");

            logger.LogInformation("RegionOperations --- Get method finished");

            return new RegionViewModel
            {
                RegionDescription = result.RegionDescription,
                RegionId = result.RegionId
            };
        }

        public IEnumerable<RegionViewModel> GetAll()
        {
            logger.LogInformation("RegionOperations --- GetAll method started");

            var dat = repository.Regions.GetAll();
            var result = dat.Select(x => new RegionViewModel
            {
                RegionId = x.RegionId,
                RegionDescription = x.RegionDescription
            });

            logger.LogInformation("RegionOperations --- GetAll method finished");

            return result;
        }

        public void Remove(int id)
        {
            logger.LogInformation("RegionOperations --- Remove method started");

            var result = repository.Regions.Get(id);
            repository.Regions.Remove(result);
            repository.SaveChanges();

            logger.LogInformation("RegionOperations --- Remove method finished");
        }
    }
}
