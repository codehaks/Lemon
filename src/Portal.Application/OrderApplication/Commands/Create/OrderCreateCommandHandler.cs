using MediatR;
using Portal.Application.Common;
using Portal.Application.OrderApplication.Notifications;
using Portal.Domain;
using Portal.Infrastructure.Persistance.Repositories;
using Portal.Persisatance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.OrderApplication.Commands
{
    public class OrderCreateCommandHandler :
        IRequestHandler<OrderCreateCommand, OperationResult<OrderCreateCommandResult>>
    {
        private readonly PortalDbContext _db;
        private readonly IOrderRepository _orderRepository;

        private readonly IMediator _mediator;
        private readonly ScoreService _scoreService;
        public OrderCreateCommandHandler(ScoreService scoreService, 
            PortalDbContext db, 
            IOrderRepository orderRepository, 
            IMediator mediator)
        {
            _orderRepository = orderRepository;
            _mediator = mediator;
            _scoreService = scoreService;
            _db = db;
        }

        public async Task<OperationResult<OrderCreateCommandResult>> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
        {
            var order = new Order { State = OrderState.New, TimeCreated = DateTime.Now, UserId = request.UserId };

            order.Items = new List<OrderItem>();

            var foods = _db.Foods.ToList();

            foreach (var item in request.Items)
            {
                var food = foods.Single(f => f.Id == item.FoodId);

                order.Items.Add(new OrderItem
                {
                    FoodId = item.FoodId,
                    Count = item.Count,
                    OrderId = order.Id,
                    UnitPrice = food.Price.Value,
                    TotalPrice = food.Price.Value * item.Count
                });
            }

            order.Score = _scoreService.CalculateScore(order, new Domain.Identity.ApplicationUser());
            _orderRepository.Create(order);

            await _mediator.Publish(new OrderCreatedNotification());         

      
            var result = OperationResult<OrderCreateCommandResult>
               .BuildSuccessResult(new OrderCreateCommandResult
               {
                   OrderId = order.Id
               });
            await Task.CompletedTask;
            return result;

        }
    }
}
