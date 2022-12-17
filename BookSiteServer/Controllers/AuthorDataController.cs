using Microsoft.AspNetCore.Mvc;

namespace BookSiteServer.Controllers
{
    public class AuthorDataController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("../Home/Privacy");
        }
    }
}
