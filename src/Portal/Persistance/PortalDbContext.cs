using Microsoft.EntityFrameworkCore;

namespace Portal.Persisatance
{
    public class PortalDbContext : DbContext
    {
        public PortalDbContext(DbContextOptions<PortalDbContext> options)
            : base(options)
        {

        }

    }
}
