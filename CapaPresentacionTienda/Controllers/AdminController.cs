using Microsoft.AspNetCore.Mvc;

namespace PwebDB.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
