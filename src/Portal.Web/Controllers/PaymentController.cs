using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portal.Domain.PaymentAggregate;
using Portal.Persisatance;

namespace Portal.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly PortalDbContext _db;

        public PaymentController(PortalDbContext db)
        {
            _db = db;
        }

        [Route("api/payment/add")]
        public IActionResult AddCredit(string userId, Payment payment)
        {
            _db.Payments.Add(new PaymentEventSource
            {
                User = userId,
                EventType = PaymentEventType.AddCredit,
                Data = JsonConvert.SerializeObject(payment)

            });
            return Ok();
        }

        public IActionResult CheckCredit(string userId)
        {
            var userPaymentEvents = _db.Payments.Where(p => p.User == userId).ToList();
            var credit=userPaymentEvents.Sum(p=>p.)
            return Ok();
        }

        [Route("api/payment/remove")]
        public IActionResult RemoveCredit(string userId, Payment payment)
        {
            _db.Payments.Add(new PaymentEventSource
            {
                User = userId,
                EventType = PaymentEventType.RemoveCredit,
                Data = JsonConvert.SerializeObject(payment)

            });
            return Ok();
        }
    }
}