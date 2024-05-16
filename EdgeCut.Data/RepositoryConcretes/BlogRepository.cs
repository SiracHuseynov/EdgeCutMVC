using EdgeCut.Core.Models;
using EdgeCut.Core.RepositoryAbstracts;
using EdgeCut.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeCut.Data.RepositoryConcretes
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
