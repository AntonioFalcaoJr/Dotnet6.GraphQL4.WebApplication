using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.MVC.Clients;
using Dotnet5.GraphQL.Store.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dotnet5.GraphQL.Store.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductGraphClient _productGraphClient;

        public HomeController(ILogger<HomeController> logger, IProductGraphClient productGraphClient)
        {
            _logger = logger;
            _productGraphClient = productGraphClient;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});

        public async Task<IActionResult> Index()
        {
            var response = await _productGraphClient.GetProductsAsync();
            return View(response);
        }

        public async Task<IActionResult> ProductDetail(Guid id)
        {
            var product = await _productGraphClient.GetProductByIdAsync(id);
            return View(product);
        }
        
        public async Task<IActionResult> ProductReview(Guid id)
        {
            var reviews = await _productGraphClient.GetReviewByProductIdAsync(id);
            return View(reviews);
        }
    }
}