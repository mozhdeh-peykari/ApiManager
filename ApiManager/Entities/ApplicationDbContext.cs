using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { Id = 1, Username = "mojpey", Password = "123", FirstName = "Mozhdeh", LastName = "Peykari" },
                                                new User { Id = 2, Username = "na3rfaraji", Password = "456", FirstName = "Nasser", LastName = "Faraji" });
            base.OnModelCreating(modelBuilder);
        }
    }
}
