using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.WebMVC.Clients;
using Dotnet5.GraphQL.Store.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dotnet5.GraphQL.Store.WebMVC.Controllers
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
            var response = await _productGraphClient.GetAllAsync();
            return View(response);
        }

        public async Task<IActionResult> ProductDetail(Guid id)
        {
            var product = await _productGraphClient.GetByIdAsync(id);
            return View(product);
        }

        public async Task<IActionResult> ProductReview(Guid id)
        {
            var reviews = await _productGraphClient.GetReviewByProductIdAsync(id);
            return View(reviews);
        }

        public IActionResult AddReview(Guid productId)
            => View(new ReviewModel {ProductId = productId});

        [HttpPost]
        public async Task<IActionResult> AddReviewAsync(ReviewModel model)
        {
            if (ModelState.IsValid) await _productGraphClient.AddReviewAsync(model);
            return RedirectToAction("ProductDetail", new {id = model.ProductId});
        }
    }
}