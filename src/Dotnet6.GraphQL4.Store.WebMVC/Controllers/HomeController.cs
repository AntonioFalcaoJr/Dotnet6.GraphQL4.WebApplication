using System.Diagnostics;
using System.Threading.Tasks;
using Dotnet6.GraphQL4.Store.WebMVC.Clients;
using Dotnet6.GraphQL4.Store.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dotnet6.GraphQL4.Store.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStoreGraphClient _storeGraphClient;

        public HomeController(ILogger<HomeController> logger, IStoreGraphClient storeGraphClient)
        {
            _logger = logger;
            _storeGraphClient = storeGraphClient;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});

        public async Task<IActionResult> Index()
        {
            var response = await _storeGraphClient
                .GetAllProductsAsync();

            return View(response);
        }
    }
}