using Microsoft.EntityFrameworkCore;
using TN.PhoneManagment.Api.Models;

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

        public DbSet<SmartPhone> phones { get; set; }
        public DbSet<Order> orders { get; set; }

    }
}
