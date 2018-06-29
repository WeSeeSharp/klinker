using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Shifts.Entities;
using Microsoft.EntityFrameworkCore;

namespace BabySitter.Core.General
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Sitter> BabySitters { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public T GetById<T>(int id)
            where T : class
        {
            return Set<T>().Find(id);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sitter>().OwnsOne(s => s.HourlyRates);
            modelBuilder.Entity<Shift>().OwnsOne(s => s.HourlyRates);
        }
    }
}