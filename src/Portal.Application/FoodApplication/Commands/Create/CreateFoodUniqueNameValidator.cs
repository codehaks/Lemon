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
    public class CreateFoodUniqueNameValidator: IPipelineBehavior<FoodCreateCommand,OperationResult<FoodCreateCommandResult>>
    {
        private readonly PortalDbContext _db;

        public CreateFoodUniqueNameValidator(PortalDbContext db)
        {
            _db = db;

        }

        public async Task<OperationResult<FoodCreateCommandResult>> Handle(FoodCreateCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult<FoodCreateCommandResult>> next)
        {
            var any = _db.Foods.Any(f => f.Name.Trim() == request.Name.Trim());

            if (any)
            {
                var result = OperationResult<FoodCreateCommandResult>.BuildFailure(new Exception("Food name already exists!"),"Food name already exists!");
              
                return result;
                //throw 
            }

            var response = await next();
            return response;
        }
    }
}
