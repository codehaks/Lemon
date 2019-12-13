using Portal.Common.Enums;
using Portal.Domain.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain
{
    public class Food
    {
        public int Id { get; set; }

        public Money Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FoodType FoodType { get; set; }
    }
}
