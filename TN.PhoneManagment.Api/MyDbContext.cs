using Microsoft.EntityFrameworkCore;
using TN.PhoneManagment.Api.Models;
using static MassTransit.Logging.OperationName;

namespace TN.PhoneManagment.Api
{
    public class MyDbContext: DbContext
    {
        protected readonly IConfiguration Configuration;

        public MyDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderPhone>().HasKey(sc => new { sc.OrderId, sc.SmartPhoneId});

            modelBuilder.Entity<OrderPhone>()
                        .HasOne<Order>(sc => sc.Order)
                        .WithMany(s => s.OrderPhones)
                        .HasForeignKey(sc => sc.OrderId);

            modelBuilder.Entity<OrderPhone>()
                        .HasOne<SmartPhone>(sc => sc.SmartPhone)
                        .WithMany(s => s.OrderPhones)
                        .HasForeignKey(sc => sc.SmartPhoneId);
        }

        public DbSet<SmartPhone> phones { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderPhone> orderPhones { get; set; }

    }
}
