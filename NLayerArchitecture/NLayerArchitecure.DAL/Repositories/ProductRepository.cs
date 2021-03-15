using Microsoft.EntityFrameworkCore;
using NLayerArchitecure.Core.Abstractions.Repositories;
using NLayerArchitecure.Core.BusinessModels;
using NLayerArchitecure.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NLayerArchitecure.DAL.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        public ProductRepository(NORTHWNDContext dbcontext) : base(dbcontext)
        {
        }

    }
}
