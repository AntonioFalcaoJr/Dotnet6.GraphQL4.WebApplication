using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Dotnet5.GraphQL3.Store.WebMVC.Clients;
using Dotnet5.GraphQL3.Store.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dotnet5.GraphQL3.Store.WebMVC.Controllers
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
            var response = await _productGraphClient.GetAllAsync().ConfigureAwait(false);
            return View(response);
        }

        public async Task<IActionResult> ProductDetail(Guid id)
        {
            _productGraphClient.SubscribeToUpdates();
            var product = await _productGraphClient.GetByIdAsync(id).ConfigureAwait(false);
            return View(product);
        }

        public async Task<IActionResult> ProductReview(Guid id)
        {
            var reviews = await _productGraphClient.GetReviewByProductIdAsync(id).ConfigureAwait(false);
            return View(reviews);
        }

        public IActionResult AddReview(Guid productId)
            => View(new ReviewModel {ProductId = productId});

        [HttpPost]
        public async Task<IActionResult> AddReviewAsync(ReviewModel model)
        {
            if (ModelState.IsValid) await _productGraphClient.AddReviewAsync(model).ConfigureAwait(false);
            return RedirectToAction("ProductDetail", new {id = model.ProductId});
        }
    }
}