using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Behaviors
{
    public class ValidationBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> //must inherit request from command->CreateProductCommand->IRequest<int>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public  ValidationBehaviors(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validators.Any())
            {
               var validationContext= new FluentValidation.ValidationContext<TRequest>(request);
               var result= await Task.WhenAll(_validators.Select(v=>v.ValidateAsync(validationContext,cancellationToken)));
               var failers=result.SelectMany(r=>r.Errors).Where(f=>f !=null).ToList();
                
                
                if (failers.Count > 0)
                {
                    throw new ValidationException(failers);
                }
            }
            var response=await next();
            return response;

        }
    }
}
