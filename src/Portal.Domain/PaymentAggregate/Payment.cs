using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.PaymentAggregate
{
    class Payment
    {
        public string UserId { get; set; }
        public int Amount { get; set; }
        public string Note { get; set; }
    }
}
