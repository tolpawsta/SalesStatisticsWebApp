using Microsoft.AspNet.Identity.EntityFramework;
using SalesStatistics.Core.Models;
using System.Data.Entity;

namespace SalesStatistics.DAL.Entities
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        public AppDbContext():base("DefaultConnection")
        {

        }
        static AppDbContext()
        {
            Database.SetInitializer<AppDbContext>(new CreateDatabaseIfNotExists<AppDbContext>());
        }
        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
    }
}
