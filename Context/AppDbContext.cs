using basitsatinalimuyg.Models;
using Microsoft.EntityFrameworkCore;

namespace basitsatinalimuyg.Context
{
    public class AppDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }


        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("basicecomm"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
