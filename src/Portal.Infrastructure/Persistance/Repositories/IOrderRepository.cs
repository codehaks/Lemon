using Microsoft.EntityFrameworkCore;
using Portal.Core.Base;
using Portal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Infrastructure.Persistance.Repositories
{
    public interface IOrderRepository 
    {
        Guid Create(Order order);
    }
}
