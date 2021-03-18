using Microsoft.EntityFrameworkCore;
using NLayerArchitecure.Core.Abstractions.Repositories;
using NLayerArchitecure.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerArchitecure.DAL.Repositories
{
    public class ProductRepository:RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(NORTHWNDContext Context):base (Context)
        {
            
        }

    }
}
