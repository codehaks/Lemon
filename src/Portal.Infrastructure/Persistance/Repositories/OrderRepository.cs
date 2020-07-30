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
        public Order GetLastUserOrder(string userId)
        {
            throw new NotImplementedException();
        }

        public IList<Order> GetUserOrders(string userId)
        {
            throw new NotImplementedException();
        }

        public IList<Order> GetUserOrdersForThisWeek(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
