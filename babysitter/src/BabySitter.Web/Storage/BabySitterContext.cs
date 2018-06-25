using Microsoft.EntityFrameworkCore;

namespace BabySitter.Web.Storage
{
    public class BabySitterContext : DbContext
    {
        public DbSet<BabySitters.Entities.BabySitter> BabySitters { get; set; }
        
        public BabySitterContext(DbContextOptions<BabySitterContext> options)
            : base(options)
        {
        }
    }
}