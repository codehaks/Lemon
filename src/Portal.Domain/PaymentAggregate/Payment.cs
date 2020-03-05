using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.PaymentAggregate
{
    public class Payment
    {
        public int Amount { get; set; }
        public string Note { get; set; }
        public string BankTransactionId { get; set; }
        public int OrderId { get; set; }
    }
}
