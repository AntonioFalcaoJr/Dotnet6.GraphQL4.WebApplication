using System;
using AutoMapper;
using Dotnet6.GraphQL4.Repositories.Abstractions;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Dotnet6.GraphQL4.Store.Repositories
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(DbContext dbDbContext, IConfigurationProvider configuration)
            : base(dbDbContext, configuration) { }
    }
}