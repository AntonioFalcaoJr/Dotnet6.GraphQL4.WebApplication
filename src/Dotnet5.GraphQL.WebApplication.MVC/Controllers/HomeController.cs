using System.Diagnostics;
using Dotnet5.GraphQL.WebApplication.MVC.Models;
using Dotnet5.GraphQL.WebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dotnet5.GraphQL.WebApplication.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _service;

        public HomeController(IProductService service, ILogger<HomeController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});

        public IActionResult Index() => View();

        public IActionResult Privacy() => View();
    }
}