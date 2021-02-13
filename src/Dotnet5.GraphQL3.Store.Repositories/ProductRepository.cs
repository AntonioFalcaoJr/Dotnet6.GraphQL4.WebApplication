using System;
using AutoMapper;
using Dotnet5.GraphQL3.Repositories.Abstractions;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.GraphQL3.Store.Repositories
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(DbContext dbDbContext, IConfigurationProvider configuration)
            : base(dbDbContext, configuration) { }
    }
}