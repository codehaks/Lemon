using AutoMapper;
using Portal.Application.Foods.Models;
using Portal.Domain;

namespace Portal.Application.FoodApplication
{
    public class FoodMapper : Profile
    {
        public FoodMapper()
        {
            CreateMap<FoodAddInfo, Food>();
            CreateMap<Food, FoodInfo>();
            CreateMap<Food, FoodEditInfo>().ReverseMap();
        }
    }
}