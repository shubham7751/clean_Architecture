using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.Product.Commands
{
    public class CreateProductCommand:IRequest<int>
    //IRequest<int> interface, indicating that it is a MediatR request that returns an integer value upon execution.
    //This integer value is presumably the ID of the created product.
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {   //IRequestHandler<CreateProductCommand, int> interface, specifying that it handles requests of type
            //CreateProductCommand and returns an integer
            private readonly IApplicationDbContext _context;

            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public  async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {//Handle Method: This method is responsible for handling the creation of the product. It takes the CreateProductCommand request as
             //a parameter and performs the necessary actions to create the
             //product in the database.
                var product=new Domainn.Entities.Product();//It creates a new Product entity from the domain model.
                product.Name=request.Name;
                product.Description=request.Description;
                product.Rate=request.Rate; 


                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return product.Id;

            }
        }
    }
}
