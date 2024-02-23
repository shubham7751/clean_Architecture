using AutoMapper;
using Domain.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blogs.Query.GetBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVm>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper mapper;

        public GetBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            this.mapper = mapper;
        }

        public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {

            var blog=await _blogRepository.GetAllBlogsAsync();
            //var BlogList=blog.Select(x=>new BlogVm { Author=x.Author, Name=x.Name, Description = x.Description, Id = x.Id }).ToList(); 
           var BlogList= mapper.Map<List<BlogVm>>(blog);
            return BlogList;    
        }
    }
}
