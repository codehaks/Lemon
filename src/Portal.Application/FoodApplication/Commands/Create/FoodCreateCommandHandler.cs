using MediatR;
using Portal.Application.Foods;
using Portal.Domain;
using Portal.Domain.Values;
using Portal.Persisatance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.FoodApplication.Commands.Create
{
    class FoodCreateCommandHandler : IRequestHandler<FoodCreateCommand, FoodCreateCommandResult>
    {
        private readonly PortalDbContext _db;

        public FoodCreateCommandHandler(PortalDbContext db)
        {
            _db = db;
        }
        public async Task<FoodCreateCommandResult> Handle(FoodCreateCommand request, CancellationToken cancellationToken)
        {

            var food = new Food(request.Name, new Money(request.Price), request.FoodType)
            {
                Description = request.Description
            };

            try
            {
                var result = await _db.Foods.AddAsync(food);

                return new FoodCreateCommandResult
                {
                    FoodId = result.Entity.Id,
                    Result = OperationResult.BuildSuccess()
                };
            }
            catch (Exception ex)
            {

                return new FoodCreateCommandResult
                {
                    FoodId = -1,
                    Result = OperationResult.BuildFailure(ex)
                };
            }

            



        }
    }
}
