using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Utils;
using Microsoft.EntityFrameworkCore;

namespace basitsatinalimuyg.Context
{
    public class AppDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLineItem> OrderLineItems { get; set; }


        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("basicecomm"));
			AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // order and orderlineitem relationship
            modelBuilder.Entity<OrderLineItem>()
				.HasOne(s => s.Order)
				.WithMany(g => g.Orders)
				.HasForeignKey(s => s.OrderId);

            // orderlineitem and product relationship
            modelBuilder.Entity<OrderLineItem>()
                .HasOne(s => s.Product)
                .WithMany(g => g.OrderLineItems)
                .HasForeignKey(s => s.ProductId);

            // order and user relationship
			modelBuilder.Entity<Order>()
                .HasOne(s => s.User)
                .WithMany(g => g.Orders)
                .HasForeignKey(s => s.UserId);

			modelBuilder.ApplyMoneyValueConverter();

		}


    }
}
