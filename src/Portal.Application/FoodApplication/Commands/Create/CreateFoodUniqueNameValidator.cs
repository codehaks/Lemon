using MediatR;
using Portal.Persisatance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.FoodApplication.Commands.Create
{
    public class CreateFoodUniqueNameValidator: IPipelineBehavior<FoodCreateCommand, int>
    {
        private readonly PortalDbContext _db;

        public CreateFoodUniqueNameValidator(PortalDbContext db)
        {
            _db = db;

        }

        public async Task<int> Handle(FoodCreateCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<int> next)
        {
            var any = _db.Foods.Any(f => f.Name.Trim() == request.Name.Trim());

            if (any)
            {
                throw new Exception("Food name already exists!");
            }

            var response = await next();
            return response;
        }
    }
}
