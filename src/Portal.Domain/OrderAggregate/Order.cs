using System;
using System.Collections.Generic;
using System.Text;
using Portal.Domain.OrderAggregate.Specs;
namespace Portal.Domain
{

    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public DateTime TimeCreated { get; set; }
        public OrderState State { get; set; }
        public int Score { get; set; }



        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public bool IsPremiumUser { get; set; }

        public void Cancel()
        {
            var s1 = new CanBeCanceledBeforeCooking();
            var s2 = new PremiumUserCanCancelBeforeDelivery();

            if (s1.Or(s2).IsSatisfiedBy(this))
            {
                State = OrderState.Canceled;
            }
        }

        public ICollection<OrderItem> Items { get; set; }
    }
}
