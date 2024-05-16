using EdgeCut.Business.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EdgeCut.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;

        public HomeController(IBlogService blogService)
        {
            _blogService = blogService;
        }


        public IActionResult Index()
        {
            var blogs = _blogService.GetAll();
            return View(blogs);
        }

       
    }
}
