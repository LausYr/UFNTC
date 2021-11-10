using Directory.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Directory.WebAPI.Data
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
    }
}
