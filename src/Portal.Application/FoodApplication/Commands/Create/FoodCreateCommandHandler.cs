using MediatR;
using Portal.Application.Common;
using Portal.Application.Foods;
using Portal.Domain;
using Portal.Domain.Values;
using Portal.Infrastructure.Persistance.Repositories;
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
        private readonly IUnitOfWork _uow;
        public FoodCreateCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<OperationResult<FoodCreateCommandResult>> Handle(FoodCreateCommand request, CancellationToken cancellationToken)
        {

            var food = new Food(request.Name, new Money(request.Price), request.FoodType)
            {
                Description = request.Description
            };

            try
            {

                var newFoodId =await _uow.FoodRepository.Create(food);// await _db.Foods.AddAsync(food);
                await _uow.CommitAsync();
                var result = OperationResult<FoodCreateCommandResult>
                    .BuildSuccessResult(new FoodCreateCommandResult
                    {
                        FoodId = newFoodId
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
