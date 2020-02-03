using Portal.Domain;
using Portal.Persisatance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Infrastructure.Persistance.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PortalDbContext _db;
        public OrderRepository(PortalDbContext db)
        {
            _db = db;
        }
        public Guid Create(Order order)
        {
            var result=_db.Orders.Add(order);
            return result.Entity.Id;
        }
    }
}
