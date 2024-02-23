using Application.Blogs.Query.GetBlogs;
using AutoMapper;
using Domain.Entity;
using Domain.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blogs.Commands.UpdateBlog
{
    public class UpDateBlogCommandHandler : IRequestHandler<UpDateBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public UpDateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpDateBlogCommand request, CancellationToken cancellationToken)
        {

            var updateblogentity = new Blog()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Author = request.Author
            };
            return await _blogRepository.UpdateAsync(request.Id, updateblogentity);

            //var UpdateBlogEntity = _mapper.Map<Blog>(request);
            //var result = await _blogRepository.UpdateAsync(request.Id, UpdateBlogEntity);
            //return result;


        }
    }
}
