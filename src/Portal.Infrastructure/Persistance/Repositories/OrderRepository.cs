using Microsoft.EntityFrameworkCore;
using Portal.Core.Base;
using Portal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Infrastructure.Persistance.Repositories
{
    interface IOrderRepository 
    {
        //IQueryable<Order> GetQuery();
        IList<Order> GetUserOrders(string userId);
        IList<Order> GetUserOrdersForThisWeek(string userId);
        Order GetLastUserOrder(string userId);
    }
}
