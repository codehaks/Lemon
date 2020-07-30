using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain
{
    public class Payment
    {
        public Guid Id { get; set; }

        public int Amount { get; set; }

        public string BankTransactionId { get; set; }

        public string BankName { get; set; }

        public DateTime TimeStamp { get; set; }

        public string UserId { get; set; }

        public int CreditSnapshot { get; set; }

        public PaymentEventType EventType { get; set; }
    }
    public enum PaymentEventType
    {
        AddCredit = 0,
        RemoveCredit = 1
    }
}
