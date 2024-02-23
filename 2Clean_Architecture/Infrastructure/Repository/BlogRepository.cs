using Domain.Entity;
using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _blogdbContext;

        public BlogRepository(BlogDbContext blogdbContext)
        {
            _blogdbContext = blogdbContext;
        }

        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _blogdbContext.Blogs.AddAsync(blog);
            await _blogdbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _blogdbContext.Blogs
                  .Where(model => model.Id == id)
                  .ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await _blogdbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogdbContext.Blogs.AsNoTracking()
              .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
            return await _blogdbContext.Blogs
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, blog.Id)
                  .SetProperty(m => m.Name, blog.Name)
                  .SetProperty(m => m.Description, blog.Description)
                  .SetProperty(m => m.Author, blog.Author)
                );
        }
    }
}
