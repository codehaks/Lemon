using Portal.Common.Enums;
using Portal.Domain.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain
{
    public class Food
    {
        private Food()
        {

        }
        public Food(string name,Money price,FoodType foodType)
        {
            Price = price;
            Name = name;
            FoodType = foodType;
        }

        public int Id { get; set; }

        public bool UpdatePrice(Money price)
        {
            // Validation
            Price = price;

            return true;
        }

        public Money Price { get; private set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public FoodType FoodType { get; set; }
    }
}
