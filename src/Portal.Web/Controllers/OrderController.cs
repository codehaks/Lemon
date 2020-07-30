using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.OrderApplication.Commands;
using Portal.Domain;
using Portal.Web.Models;

namespace Portal.Web.Controllers
{
    //[Authorize]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("api/order")]
        public async Task<IActionResult> Create([FromBody] OrderBasketModel orderBasket)
        {
           var result= await _mediator.Send(new OrderCreateCommand
            {
                UserId = "123",
                Items = orderBasket.Items.Select(o => new OrderItem { FoodId = o.FoodId, Count = o.Count }).ToList()
            });
            return Ok(result.Result.OrderId);
        }
    }
}