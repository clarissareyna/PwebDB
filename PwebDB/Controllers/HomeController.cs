using Microsoft.AspNetCore.Mvc;
using PwebDB.Models;
using System.Diagnostics;

namespace PwebDB.Controllers
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Usuarios()
        {
            return View();
        }
        public ActionResult Productos()
        {
            return View();
        }
        public ActionResult Categorias()
        {
            return View();
        }
        public ActionResult Marcas()
        {
            return View();
        }

    }
}
