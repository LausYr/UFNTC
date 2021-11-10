using Directory.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Directory.WebAPI.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }
        public DbSet<PositionWork> PositionWorks { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(p => p.Organization)
                .WithMany(t => t.Employees)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Employee>()
                .HasOne(p => p.Subdivision)
                .WithMany(t => t.Employees)
                .OnDelete(DeleteBehavior.SetNull);
            

        }
    }
}
