using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Portal.Application.Foods.Models;
using Portal.Domain;
using Portal.Domain.Values;
using Portal.Persisatance;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Foods
{
    public class FoodService : IFoodService
    {
        private readonly PortalDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public FoodService(PortalDbContext db, IMapper mapper, ILogger<FoodService> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Create(FoodAddInfo info)
        {
            var model = _mapper.Map<FoodAddInfo, Food>(info);
            _db.Foods.Add(model);
            await _db.SaveChangesAsync();
        }

        public async Task<IList<FoodInfo>> FindAll()
        {
            var model = await _db.Foods.ToListAsync();

            return model.Select(_mapper.Map<Food, FoodInfo>).ToList();
        }

        public async Task<FoodInfo> FindById(int id)
        {
            var model = await _db.Foods.FindAsync(id);
            return _mapper.Map<Food, FoodInfo>(model);
        }

        public async Task<FoodEditInfo> GetEdit(int foodId)
        {
            var food = await _db.Foods.FindAsync(foodId);
            _logger.LogInformation($"Food by Id [{food.Id}] found.");
            return _mapper.Map<Food, FoodEditInfo>(food);
        }

        public async Task Update(FoodEditInfo foodEditInfo)
        {
            var food = new Food(foodEditInfo.Name, new Money(foodEditInfo.Price.Value), foodEditInfo.FoodType);
            //{
            //    Id=foodEditInfo.Id,
            //    Name = foodEditInfo.Name,
            //    Price = new Money(foodEditInfo.Price.Value),
            //    FoodType = foodEditInfo.FoodType,
            //    Description = foodEditInfo.Description
            //};

            food.Id = foodEditInfo.Id;
            food.Description = foodEditInfo.Description;

            //food.UpdatePrice(foodEditInfo.Price);
            
                        
            _db.Entry(food).State = EntityState.Modified;
            _db.Entry(food.Price).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            _logger.LogInformation($"Food by Id [{food.Id}] Updated.", food);

        }
    }
}
