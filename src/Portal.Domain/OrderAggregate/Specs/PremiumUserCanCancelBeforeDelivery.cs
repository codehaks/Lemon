using Portal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Portal.Domain.OrderAggregate.Specs
{
    class PremiumUserCanCancelBeforeDelivery : Specification<Order>
    {
      
        public override Expression<Func<Order, bool>> ToExpression()
        {
            return order => order.IsPremiumUser;
        }
    }
}
