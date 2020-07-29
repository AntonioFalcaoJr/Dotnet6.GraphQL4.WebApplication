using System;
using AutoMapper;
using Dotnet5.GraphQL.WebApplication.Domain.Entities.Products;
using Dotnet5.GraphQL.WebApplication.Repositories;
using Dotnet5.GraphQL.WebApplication.Repositories.UnitsOfWorks;
using Dotnet5.GraphQL.WebApplication.Services.Abstractions;
using Dotnet5.GraphQL.WebApplication.Services.Models;

namespace Dotnet5.GraphQL.WebApplication.Services
{
    public class ProductService : Service<Product, ProductModel, Guid>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IProductRepository repository, IMapper mapper)
            : base(unitOfWork, repository, mapper) { }
    }
}