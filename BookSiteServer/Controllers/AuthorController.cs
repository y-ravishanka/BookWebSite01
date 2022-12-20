using BookSiteServer.Data;
using BookSiteServer.Models;
using BookSiteServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookSiteServer.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorData db = new AuthorData();
        private readonly ICalculation cal = new Calculation();
        private readonly string ecTitle = "AuthorController Exception";

        public async Task<IActionResult> Books(int id, string value)
        {
            Author author;
            if (id == 1)
            {
                try
                {
                    author = await db.GetAuthorAsync(Guid.Parse(value));
                }
                catch (Exception ex)
                {
                    cal.DisplayExceptions(ecTitle, ex.ToString());
                    author = null;
                }
            }
            else
            { author = await db.GetAuthorAsync(value); }
            if (author is null)
            { return Redirect("../Warning/NotFoundView"); }
            else
            { return View(); }
        }
    }
}
