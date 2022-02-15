using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SearchWebApp.Models;
using SearchWebApp.Services;
using System.Diagnostics;

namespace SearchWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public static Item[] Items = null;
        public Service service = new Service();
        public static string Question = string.Empty;

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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Search(string question)
        {
            Question = question;
            var answers = service.RequestAnswer(question);

            Items = answers.items;
            return View();
        }
    }
}
