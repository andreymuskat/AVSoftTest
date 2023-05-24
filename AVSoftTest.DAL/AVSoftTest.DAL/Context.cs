using System.Diagnostics.Metrics;
using AVSoftTest.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AVSoftTest.DAL
{
    public class Context : DbContext
    {
        public DbSet<CounterEntity> Counters { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = AVSoftTestDb0; TrustServerCertificate=True;Integrated Security=SSPI");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<CounterEntity> countersData = new List<CounterEntity>
        {
            new CounterEntity { Id = 1, Key = 1, Value = 1 },
            new CounterEntity { Id = 2, Key = 1, Value = 2 },
            new CounterEntity { Id = 3, Key = 1, Value = 3 },
            new CounterEntity { Id = 4, Key = 2, Value = 1 },
            new CounterEntity { Id = 5, Key = 2, Value = 1 },
            new CounterEntity { Id = 6, Key = 2, Value = 3 },
            new CounterEntity { Id = 7, Key = 2, Value = 1 }
        };

            modelBuilder.Entity<CounterEntity>().HasData(countersData);
        }
    }
}
