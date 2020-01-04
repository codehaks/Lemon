using Portal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Web.Models
{
    public class OrderBasketModel
    {
        public string UserId { get; set; }
        public ICollection<OrderBasketItem> Items { get; set; }
    }

    public class OrderBasketItem
    {
        public int FoodId { get; set; }

        public int Count { get; set; }
        public int UnitPrice { get; set; }
    }
}
