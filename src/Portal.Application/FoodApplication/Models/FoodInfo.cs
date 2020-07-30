using Portal.Common.Enums;
using Portal.Domain.Values;

namespace Portal.Application.Foods.Models
{
    public class FoodInfo
    {
        public int Id { get; set; }
        public Money Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FoodType FoodType { get; set; }
    }
}
