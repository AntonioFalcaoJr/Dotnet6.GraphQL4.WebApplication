using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dotnet5.GraphQL.WebApplication.Domain.Entities.Products;
using Dotnet5.GraphQL.WebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dotnet5.GraphQL.WebApplication.MVC.Controllers
{
    [ApiController, Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _service;

        public ProductsController(IProductService service, ILogger<ProductsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAsync(CancellationToken cancellationToken)
            => await _service.GetAllAsync(x => x.Name != null, cancellationToken);
    }
}