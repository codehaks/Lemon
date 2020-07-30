using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Persisatance;
using Portal.Web.Models;

namespace Portal.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly PortalDbContext _db;
        public PaymentController(PortalDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("api/payment")]
        public IActionResult AddEvent(PaymenrAddModel model)
        {
            //model.UserId = GetUserId(User.Identity.Name);

            _db.Payments.Add(new Domain.Payment
            {
                Amount=model.Amount,
                BankName=model.BankName,
                BankTransactionId=model.BankTransactionId,
                UserId=model.UserId,

                EventType=model.EventType,
                Id=Guid.NewGuid(),
                TimeStamp=DateTime.Now
            });

            _db.SaveChanges();

            // Add credit
            return Ok("done");
        }

        [Route("api/payment/check/{userid}")]
        public IActionResult Check(string userId)
        {
            var payments = _db.Payments.Where(p => p.UserId == userId).ToList();

            var credit = payments.Where(p => p.EventType == Domain.PaymentEventType.AddCredit).Sum(p => p.Amount)
                     - payments.Where(p => p.EventType == Domain.PaymentEventType.RemoveCredit).Sum(p => p.Amount);
            
            return Ok(credit);
        }
    }
}