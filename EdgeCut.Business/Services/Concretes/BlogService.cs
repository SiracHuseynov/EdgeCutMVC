using EdgeCut.Business.Exceptions;
using EdgeCut.Business.Extensions;
using EdgeCut.Business.Services.Abstracts;
using EdgeCut.Core.Models;
using EdgeCut.Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeCut.Business.Services.Concretes
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IWebHostEnvironment _env;

        public BlogService(IBlogRepository blogRepository, IWebHostEnvironment env)
        {
            _blogRepository = blogRepository;
            _env = env;
        }

        public async Task AddAsyncBlog(Blog blog)
        {
            if (blog.ImageFile == null) 
                throw new EntityNotFoundException("Blog tapilmadi");

            blog.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\sliders", blog.ImageFile);

            await _blogRepository.AddAsync(blog);
            await _blogRepository.CommitAsync();
        }

        public void DeleteBlog(int id)
        {
            var existBlog = _blogRepository.Get(x => x.Id == id);

            if (existBlog == null)
                throw new EntityNotFoundException("Blog tapilmadi");

            Helper.DeletFile(_env.WebRootPath, @"uploads\sliders", existBlog.ImageUrl);

            _blogRepository.Delete(existBlog);
            _blogRepository.Commit();
        }

        public List<Blog> GetAll(Func<Blog, bool>? func = null)
        {
            return _blogRepository.GetAll(func);
        }

        public Blog GetBlog(Func<Blog, bool>? func = null)
        {
            return _blogRepository.Get(func);
        }

        public void UpdateBlog(int id, Blog newBlog)
        {
            var oldBlog = _blogRepository.Get(x => x.Id == id);

            if (oldBlog == null)
                throw new EntityNotFoundException("Blog tapilmadi");

            if(newBlog.ImageFile != null)
            {
                Helper.DeletFile(_env.WebRootPath, @"uploads\sliders", oldBlog.ImageUrl);

                oldBlog.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\sliders", newBlog.ImageFile);

            }

            oldBlog.Title = newBlog.Title;
            oldBlog.Description = newBlog.Description;
            oldBlog.RedirectUrl = newBlog.RedirectUrl;

            _blogRepository.Commit();
        }
    }
}
