using Portal.Common.Enums;

namespace Portal.Application.Foods.Models
{
    public class FoodEditInfo
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FoodType FoodType { get; set; }
    }
}
