using Portal.Domain.Common;

namespace Portal.Common.Enums
{
    public class FoodType : Enumeration
    {
        //Meal = 0,
        //Drink = 1,
        //Desert = 2

        public static FoodType Meal = new FoodType(0, "Meal");
        public static FoodType Drink = new FoodType(1, "Drink");
        public static FoodType Desert = new FoodType(2, "Desert");
        public FoodType()
        {

        }
        public FoodType(int id, string name)
            : base(id, name)
        {
        }
    }
}
