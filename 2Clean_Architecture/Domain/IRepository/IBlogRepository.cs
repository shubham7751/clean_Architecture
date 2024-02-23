using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IBlogRepository //interface and its method :. can call any were
    {
        Task<List<Blog>> GetAllBlogsAsync();
        Task<Blog> GetByIdAsync(int id);
        Task<Blog> CreateAsync(Blog blog);
        Task<int> UpdateAsync(int id, Blog blog);
        Task<int> DeleteAsync(int id);
    }
}



//public interface IBlogRepository
//{
//    Task<List<Blog>> GetAllBlogsAsync();
//    Task<Blog> GetByIdAsync(int id);
//    Task<Blog> CreateAsync(Blog blog);
//    Task<Blog> UpdateAsync(int id, IBlogRepository blog);
//    Task<Blog> DeleteAsync(int id);
//         ^^^
//}