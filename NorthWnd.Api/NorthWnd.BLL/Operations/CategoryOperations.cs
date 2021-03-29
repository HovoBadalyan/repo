using Microsoft.Extensions.Logging;
using NorthWnd.CORE.Abstractions;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.BusinessModels.QueryListModel;
using NorthWnd.CORE.Entities;
using NorthWnd.CORE.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace NorthWnd.BLL.Operations
{
    public class CategoryOperations : ICategoryOperations
    {
        private readonly IRepositoryManager category;
        private readonly ILogger<CategoryOperations> logger;
        public CategoryOperations(IRepositoryManager _category, ILogger<CategoryOperations> _logger)
        {
            logger = _logger;
            category = _category;
        }

        public Category Add(CategoryViewModel model)
        {
            logger.LogInformation("CategoryOperations --- Add method started");

            Category cat = new Category
            {
                CategoryName = model.CategoryName,
                Description = model.Description
            };
            category.Categories.Add(cat);
            category.SaveChanges();

            logger.LogInformation("CategoryOperations --- Add method finished");

            return cat;
        }

        public Category Edit(CategoryViewModel model)
        {
            logger.LogInformation("CategoryOperations --- Edit method started");

            Category cat = new Category
            {
                CategoryId = model.CategoryId
            };
            cat.CategoryName = model.CategoryName;
            cat.Description = model.Description;
            category.Categories.Update(cat);
            category.SaveChanges();

            logger.LogInformation("CategoryOperations --- Edit method finished");

            return cat;
        }

        public CategoryViewModel Get(int id)
        {
            logger.LogInformation("CategoryOperations --- Get method started");
            
            var res = category.Categories.Get(id)??throw new LogicException("Wrong Category Id");

            logger.LogInformation("CategoryOperations --- Get method finished");

            return new CategoryViewModel
            {
                CategoryId = res.CategoryId,
                CategoryName = res.CategoryName,
                Description = res.Description
            };
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            logger.LogInformation("CategoryOperations --- GetAll method started");

            var res= category.Categories.GetAll();
            var data = res.Select(x => new CategoryViewModel
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description
            });

            logger.LogInformation("CategoryOperations --- GetAll method finished");

            return data;
        }

        public IEnumerable<CategoryandTotalProducts> GetCategoryandtotalProducts()
        {
            logger.LogInformation("CategoryOperations --- Query N20");

            return category.Categories.GetCategoryandtotalProducts();
        }

        public void Remove(int id)
        {
            logger.LogInformation("CategoryOperations --- Remove method started");

            var res = category.Categories.Get(id);
            category.Categories.Remove(res);
            category.SaveChanges();

            logger.LogInformation("CategoryOperations --- Remove method finished");
        }
    }
}
