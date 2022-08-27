using ImmoBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace ImmoBooking.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Property_Agent>().HasKey(pa => new
            {
                pa.PropertyId,
                pa.AgentId
            });

            modelBuilder.Entity<Property_Agent>().HasOne(p => p.Property).WithMany(pa => pa.Properties_Agents).HasForeignKey(p => p.PropertyId);

            modelBuilder.Entity<Property_Agent>().HasOne(a => a.Agent).WithMany(pa => pa.Properties_Agents).HasForeignKey(a => a.AgentId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Agent> Agents { get; set; }

        public DbSet<Property_Agent> Properties_Agents { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<Agencie> Agencies { get; set; }


        //Order Related Tables
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrdersItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
