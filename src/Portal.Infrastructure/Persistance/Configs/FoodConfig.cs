using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Common.Enums;
using Portal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Persistance.Configs
{
    public class FoodConfig : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasIndex(f => f.Name).IsUnique();
            builder.Property(f => f.Name).HasMaxLength(25).IsRequired();
            builder.Property(f => f.Description).HasMaxLength(1000).IsRequired();
            builder.Property(f=>f.FoodType)
                .HasColumnName("FoodType")
                .HasConversion(v => v.Id,
                v => FoodType.GetAll<FoodType>().Single(s => s.Id==v));
        }
    }
}
