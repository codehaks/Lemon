using Portal.Domain;
using Portal.Persisatance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infrastructure.Persistance.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly PortalDbContext _db;

        public FoodRepository(PortalDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(Food food)
        {
            var result=_db.Foods.Add(food);
            await _db.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
