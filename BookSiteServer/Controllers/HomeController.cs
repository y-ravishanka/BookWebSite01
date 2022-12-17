using BookSiteServer.Data;
using BookSiteServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookSiteServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBooksData books = new BooksData();
        private IAuthorData authors = new AuthorData();

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

        public IActionResult Library()
        {
            return View();
        }

        public IActionResult NewNovels()
        {
            return View();
        }

        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult DisplayNovels()
        {
            return View();
        }

        public async Task<IActionResult> AddTag()
        {
            return Redirect("NewNovels");
        }

        public async Task<IActionResult> AddAuthor()
        {
            //try
            //{
            //    Author author = new()
            //    {
            //        Name = "hello"
            //    };
            //    bool t = await authors.AddAuthorAsync(author);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("controller exception \n" + ex.ToString() + "\n");
            //}
            return Redirect("NewNovels");
        }

        public async Task<IActionResult> UpdateAuthor()
        {
            //AuthorName author = new()
            //{
            //    Name = "test01"
            //};
            //bool t = await authors.UpdateAuthorAsync("hello", author);
            return Redirect("../Author/Index");
        }

        public IActionResult ChapterView(int id, string name)
        {
            Console.WriteLine("name is :" + name);
            return View(id); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}