using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain
{

    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public DateTime TimeCreated { get; set; }
        public OrderState State { get; set; }

        public bool IsPremiumUser { get; set; }

        public void Cancel()
        {
            if (State==OrderState.New || IsPremiumUser)
            {
                State = OrderState.Canceled;
            }
        }

        public ICollection<OrderItem> Items { get; set; }
    }
}
