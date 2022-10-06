using Microsoft.EntityFrameworkCore;
using testing2.Models;

namespace Growth_Website.Models
{
    public class DbContextClass:DbContext
    {
        public DbSet<Signup> Signups { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Cart> Cart { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GrowthDB2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    }
}
