using MediatR;
using Portal.Application.Common;
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
    class FoodCreateCommandHandler : IRequestHandler<FoodCreateCommand, OperationResult<FoodCreateCommandResult>>
    {
        private readonly PortalDbContext _db;

        public FoodCreateCommandHandler(PortalDbContext db)
        {
            _db = db;
        }
        public async Task<OperationResult<FoodCreateCommandResult>> Handle(FoodCreateCommand request, CancellationToken cancellationToken)
        {

            var food = new Food(request.Name, new Money(request.Price), request.FoodType)
            {
                Description = request.Description
            };

            try
            {

                var newFood = await _db.Foods.AddAsync(food);

                var result = OperationResult<FoodCreateCommandResult>
                    .BuildSuccessResult(new FoodCreateCommandResult
                    {
                        FoodId = newFood.Entity.Id
                    });
                await Task.CompletedTask;
                return result;
            }
            catch (Exception ex)
            {

                var exResult = OperationResult<FoodCreateCommandResult>.BuildFailure(ex);
                return exResult;
            }





        }
    }
}
