using Portal.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infrastructure.Persistance.Repositories
{
    public interface IFoodRepository
    {
        Task<int> Create(Food food);
    }
}
