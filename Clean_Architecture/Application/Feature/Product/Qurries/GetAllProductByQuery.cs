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
    public class GetAllProductByQuery : IRequest<IEnumerable<Domainn.Entities.Product>>
    {
        internal class GetAllProductByQueryHandeler : IRequestHandler<GetAllProductByQuery, IEnumerable<Domainn.Entities.Product>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllProductByQueryHandeler(IApplicationDbContext context)
            {
                _context = context;
            }

          
            public async Task<IEnumerable<Domainn.Entities.Product>> Handle(GetAllProductByQuery request, CancellationToken cancellationToken)
            {
              var result= await _context.Products.ToListAsync(cancellationToken);
                return result;
            }
        }

    }

  
}
