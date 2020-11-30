using Microsoft.EntityFrameworkCore;

namespace Foodly.Models.EfModels
{
    public class Context:DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:foodly-server.database.windows.net,1433;Initial Catalog=foodly;Persist Security Info=False;User ID=Foodly-admin;Password=951753456Fo;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
