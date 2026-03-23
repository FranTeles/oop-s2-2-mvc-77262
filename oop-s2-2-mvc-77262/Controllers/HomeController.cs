using Microsoft.AspNetCore.Mvc;
using oop_s2_2_mvc_77262.Models;
using Serilog;
using System.Diagnostics;

namespace oop_s2_2_mvc_77262.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            Log.Error("Unhandled exception reached friendly error page. RequestId: {RequestId}", requestId);

            return View(new ErrorViewModel { RequestId = requestId });
        }
    }
}
