using System;
using System.Threading.Tasks;
using Dotnet5.GraphQL3.Store.WebMVC.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dotnet5.GraphQL3.Store.WebMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStoreGraphClient _storeGraphClient;

        public ProductsController(ILogger<HomeController> logger, IStoreGraphClient storeGraphClient)
        {
            _logger = logger;
            _storeGraphClient = storeGraphClient;
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            _storeGraphClient.SubscribeToUpdates();

            var product = await _storeGraphClient
                .GetProductByIdAsync(id);

            return View(product);
        }
    }
}