using Microsoft.EntityFrameworkCore;
using DemoMvcApp.Models;

namespace DemoMvcApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        // ⚡ Ici la méthode OnModelCreating à l'intérieur de la classe
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Prix)
                .HasColumnType("decimal(18,2)"); // précision 18, 2 décimales
        }
    }
}
