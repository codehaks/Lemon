using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain
{
    public class OrderItem
    {
        
        public Guid OrderId { get; set; }
        public int FoodId { get; set; }

        public int Count { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
    }
}
