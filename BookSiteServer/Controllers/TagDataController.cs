using Microsoft.AspNetCore.Mvc;

namespace BookSiteServer.Controllers
{
    public class TagDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
