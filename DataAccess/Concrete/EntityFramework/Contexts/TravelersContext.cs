using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class TravelersContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\MSSQLLocalDB;Database=Travelers;Trusted_Connection=true");
            //optionsBuilder.UseNpgsql("Host=containers-us-west-97.railway.app;Port=7556;Database=railway;Username=postgres;Password=hjhEiTvfUT0K1mH3FZMx");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<ResetPassword> ResetPassword { get; set; }
        public DbSet<Areas> Areas { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<ImageEntity> Image { get; set; }
    }
}
