using MediatR;
using Portal.Application.Common;
using Portal.Domain;
using Portal.Persisatance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.FoodApplication.Commands.Create
{
    public class CreateFoodUniqueNameValidator: IPipelineBehavior<FoodCreateCommand, FoodCreateCommandResult>
    {
        private readonly PortalDbContext _db;

        public CreateFoodUniqueNameValidator(PortalDbContext db)
        {
            _db = db;

        }

        public async Task<FoodCreateCommandResult> Handle(FoodCreateCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult<FoodCreateCommandResult>> next)
        {
            var any = _db.Foods.Any(f => f.Name.Trim() == request.Name.Trim());

            if (any)
            {
                var result = new FoodCreateCommandResult
                {
                    Result = OperationResult.BuildFailure(new Exception("Food name already exists!"))
                };
                return result;
                //throw 
            }

            var response = await next();
            return response;
        }
    }
}
