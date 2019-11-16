using System.Collections.Generic;
using System.Threading.Tasks;
using Portal.Application.Foods.Models;

namespace Portal.Application.Foods
{
    public interface IFoodService
    {
        Task Create(FoodAddInfo info);
        Task<FoodInfo> Get(int id);
        Task<IList<FoodInfo>> GetAll();
        Task<FoodEditInfo> GetForEdit(int foodId);
        Task Update(FoodEditInfo foodEditInfo);
    }
}