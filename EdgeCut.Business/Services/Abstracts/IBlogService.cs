using EdgeCut.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeCut.Business.Services.Abstracts
{
    public interface IBlogService
    {
        Task AddAsyncBlog(Blog blog);
        void DeleteBlog(int id);
        void UpdateBlog(int id, Blog newBlog);
        Blog GetBlog(Func<Blog, bool>? func = null);
        List<Blog> GetAll(Func<Blog, bool>? func = null);

    }
}
