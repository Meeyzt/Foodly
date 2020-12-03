using Microsoft.EntityFrameworkCore;

namespace Foodly.Models.EfModels
{
    public class Context:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           dwqdqwd
        }
    }
}
