using System;
using System.Threading.Tasks;
using Dotnet6.GraphQL4.Store.WebMVC.Clients;
using Dotnet6.GraphQL4.Store.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dotnet6.GraphQL4.Store.WebMVC.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStoreGraphClient _storeGraphClient;

        public ReviewsController(ILogger<HomeController> logger, IStoreGraphClient storeGraphClient)
        {
            _logger = logger;
            _storeGraphClient = storeGraphClient;
        }

        public async Task<IActionResult> Reviews(Guid id)
        {
            var reviews = await _storeGraphClient
                .GetReviewByProductIdAsync(id);

            return View(reviews);
        }

        public IActionResult Add(Guid productId)
            => View(new ReviewModel {ProductId = productId});

        [HttpPost]
        public async Task<IActionResult> Add(ReviewModel model)
        {
            if (ModelState.IsValid)
                await _storeGraphClient.AddReviewAsync(model);

            return RedirectToAction(
                actionName: "Detail",
                controllerName: "Products",
                routeValues: new {id = model.ProductId});
        }
    }
}