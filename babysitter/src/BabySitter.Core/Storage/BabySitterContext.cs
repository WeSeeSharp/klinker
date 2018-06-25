using Microsoft.EntityFrameworkCore;

namespace BabySitter.Core.Storage
{
    public class BabySitterContext : DbContext
    {
        public DbSet<Entities.BabySitter> BabySitters { get; set; }
        
        public BabySitterContext(DbContextOptions<BabySitterContext> options)
            : base(options)
        {
        }
    }
}