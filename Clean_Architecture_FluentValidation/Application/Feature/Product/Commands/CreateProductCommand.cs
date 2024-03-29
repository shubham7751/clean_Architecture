﻿using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.Product.Commands
{
    public class CreateProductCommand:IRequest<int>
    {
        public string Name { get; set; }
        public string Remarks { get; set; }
        public decimal Rate { get; set; }
        internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public  async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product=_mapper.Map<Domainn.Entities.Product>(request);//<Destination>(Data Comming Source)
                
                //var product=new Domainn.Entities.Product();
                // product.Name=request.Name;
                // product.Description=request.Description;
                // product.Rate=request.Rate; 


                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return product.Id;

            }
        }
    }
}
