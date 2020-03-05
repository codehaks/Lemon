using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.Domain;
using Portal.Domain.Identity;
using Portal.Infrastructure.Persistance.Configs;
using Portal.Persistance.Configs;

namespace Portal.Persisatance
{
    public class PortalDbContext : IdentityDbContext<ApplicationUser>
    {
        public PortalDbContext(DbContextOptions<PortalDbContext> options)
              : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FoodConfig());
            builder.ApplyConfiguration(new OrderConfig());
            builder.ApplyConfiguration(new OrderItemConfig());

            base.OnModelCreating(builder);
        }

    }
}
