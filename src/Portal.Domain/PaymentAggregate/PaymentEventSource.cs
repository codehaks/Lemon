using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.PaymentAggregate
{
    public class PaymentEventSource
    {
        public Guid Id { get; private set; }

        public string Data { get; private set; }

        public string User { get; private set; }
        public DateTime Timestamp { get; private set; }
        public PaymentEventType EventType { get; set; }
    }

    public enum PaymentEventType
    {
        AddCredit=0,
        RemoveCredit=1
    }
}
