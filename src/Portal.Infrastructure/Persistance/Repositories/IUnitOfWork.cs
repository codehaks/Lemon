using Portal.Persisatance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infrastructure.Persistance.Repositories
{
    public interface IUnitOfWork
    {
        IFoodRepository FoodRepository { get; }
        IOrderRepository OrderRepository { get; }

        Task<bool> CommitAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly PortalDbContext _db;


        public UnitOfWork(PortalDbContext db)
        {
            _db = db;
            FoodRepository = new FoodRepository(db);
            OrderRepository = new OrderRepository(db);
        }

        public IFoodRepository FoodRepository { get; }

        public IOrderRepository OrderRepository { get; }

        public async Task<bool> CommitAsync()
        {
            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
