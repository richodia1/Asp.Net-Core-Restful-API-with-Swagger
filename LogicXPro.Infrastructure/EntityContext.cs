using LogicXPro.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogicXPro.Infrastructure
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public  DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Log> Logs { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Customer>()
           .HasMany(c => c.Orders)
           .WithOne(e => e.Customer);

            builder.Entity<User>()
           .HasOne(a => a.Customer)
           .WithOne(b => b.User)
           .HasForeignKey<Customer>(b => b.UserID);

            builder.Entity<Coffee>()
           .HasMany(c => c.OrderDetails)
           .WithOne(e => e.Coffee);
        }
    }
}
