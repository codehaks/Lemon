using Portal.Domain.Common;
using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.Model.OrderAggregate.Specs
{
    class PremiumUserCanCancelBeforeDelivery : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return order.IsPremiumUser && order.State != Core.Enums.OrderState.Delivered;
        }
    }
}
