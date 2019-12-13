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
    class FoodCreateCommandHandler : IRequestHandler<FoodCreateCommand, int>
    {
        private readonly PortalDbContext _db;

        public FoodCreateCommandHandler(PortalDbContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(FoodCreateCommand request, CancellationToken cancellationToken)
        {
           
                var food = new Food
                {
                    Name = request.Name,
                    Description = request.Description,
                    FoodType = request.FoodType,
                    Price = new Money(request.Price)

                };
                var result = _db.Foods.Add(food);
                await _db.SaveChangesAsync();

                return result.Entity.Id;
            


        }
    }
}
