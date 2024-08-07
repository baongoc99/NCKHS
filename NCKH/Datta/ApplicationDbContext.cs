using Microsoft.EntityFrameworkCore;
using NCKH.Models;

namespace NCKH.Datta
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderDetailCustomer> OrderDetailCustomers{ get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<UsedSales> UsedSales { get; set; }


    }
}
