using EdgeCut.Business.Exceptions;
using EdgeCut.Business.Services.Abstracts;
using EdgeCut.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdgeCut.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var blogs = _blogService.GetAll();
            return View(blogs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _blogService.AddAsyncBlog(blog);
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch(ImageContentException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch(ImageSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var blog = _blogService.GetBlog(x => x.Id == id);

            if (blog == null)
                return NotFound();

            return View(blog);
        }

        [HttpPost]
        public IActionResult Update(Blog blog)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _blogService.UpdateBlog(blog.Id, blog);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (FileeNotFoundException ex)
            {
                return NotFound();
            }
            catch (ImageContentException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (ImageSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var blog = _blogService.GetBlog(x=> x.Id == id);  
            
            if(blog == null)
                return NotFound();  

            return View(blog);
        }

        [HttpPost]
        public IActionResult DeletPost(int id)
        {
            if (!ModelState.IsValid)
                return View();


            try
            {
                _blogService.DeleteBlog(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (FileeNotFoundException ex)
            {
                return NotFound();
            }


            return RedirectToAction("Index");
        }

    }
}
