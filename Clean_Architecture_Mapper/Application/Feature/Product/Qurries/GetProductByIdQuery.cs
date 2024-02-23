using Application.Feature.Product.Qurries;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.Product.Qurries
{
    public class GetProductByIdQuery : IRequest<Domainn.Entities.Product>
    {
        public int Id { get; set; }
        internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Domainn.Entities.Product>
        {
            private readonly IApplicationDbContext _context;

            public GetProductByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

          
            public async Task<Domainn.Entities.Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
              var result= await _context.Products.Where(x=>x.Id == request.Id).FirstOrDefaultAsync();
                return result;
            }
        }

    }

  
}
