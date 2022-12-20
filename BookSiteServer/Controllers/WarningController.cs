using Microsoft.AspNetCore.Mvc;

namespace BookSiteServer.Controllers
{
    public class WarningController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
