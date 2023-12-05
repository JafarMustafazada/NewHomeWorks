using Microsoft.EntityFrameworkCore;
using MVC_OneToMany.Models;

namespace MVC_OneToMany.Contexts
{
    public class PustokDbContext : DbContext
    {
        public PustokDbContext(DbContextOptions opt) : base(opt) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
