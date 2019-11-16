using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Infrastructure.Persistance.Configs
{
    class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            
        }
    }

    class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(orderItem => new { orderItem.OrderId, orderItem.FoodId });
        }
    }
}
