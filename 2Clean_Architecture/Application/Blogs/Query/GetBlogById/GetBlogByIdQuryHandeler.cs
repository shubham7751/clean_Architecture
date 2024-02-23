using Application.Blogs.Query.GetBlogs;
using AutoMapper;
using Domain.IRepository;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blogs.Query.GetBlogById
{
    public class GetBlogByIdQuryHandeler : IRequestHandler<GetBlogByIdQuery, BlogVm>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogByIdQuryHandeler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<BlogVm> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog=await _blogRepository.GetByIdAsync(request.BlogId);
            return _mapper.Map<BlogVm>(blog);
        }
    }
}
