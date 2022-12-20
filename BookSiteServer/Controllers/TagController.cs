using Microsoft.AspNetCore.Mvc;

namespace BookSiteServer.Controllers
{
    public class TagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
