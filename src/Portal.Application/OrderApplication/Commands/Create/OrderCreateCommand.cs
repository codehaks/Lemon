using MediatR;
using Portal.Application.Common;
using Portal.Domain;
using Portal.Domain.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.OrderApplication.Commands
{
    public class OrderCreateCommand: IRequest<OperationResult<OrderCreateCommandResult>>
    {
        public string UserId { get; set; }

        public ICollection<OrderItem> Items { get; set; }
    }
}
