using Microsoft.AspNetCore.Mvc;

namespace BookSiteServer.Controllers
{
    public class WarningController : Controller
    {
        public IActionResult NotFoundView()
        {
            return View();
        }

        public IActionResult UnauthorizedView()
        {
            return View();
        }
    }
}
