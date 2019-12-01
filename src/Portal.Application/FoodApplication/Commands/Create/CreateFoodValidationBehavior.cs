using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.FoodApplication.Commands.Create
{
    public class CreateFoodValidationBehavior<TRequest, TResponse> : IPipelineBehavior<FoodCreateCommand, int>
    {
        public async Task<int> Handle(FoodCreateCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<int> next)
        {
            var validator = new FoodCreateCommandValidator();
            var check = validator.Validate(request);

            if (check.IsValid)
            {
                var response = await next();
                return response;
            }
            else
            {
                throw new Exception(" Food is not valid");

            }


            
        }
    }
}
