using Portal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Web.Models
{
    public class PaymenrAddModel
    {
        public int Amount { get; set; }

        public string BankTransactionId { get; set; }

        public string BankName { get; set; }    
        
        public string UserId { get; set; }

        public PaymentEventType EventType { get; set; }
    }
}
