using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.Domain;
using Portal.Domain.Identity;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FoodConfig());

            base.OnModelCreating(builder);
        }

    }
}
