using System.Collections.Generic;
using System.Threading.Tasks;
using Portal.Application.Foods.Models;

namespace Portal.Application.Foods
{
    public interface IFoodService
    {
        Task Create(FoodAddInfo info);
        Task<FoodInfo> FindById(int id);
        Task<IList<FoodInfo>> FindAll();
        Task<FoodEditInfo> GetEdit(int foodId);
        Task Update(FoodEditInfo foodEditInfo);
    }
}