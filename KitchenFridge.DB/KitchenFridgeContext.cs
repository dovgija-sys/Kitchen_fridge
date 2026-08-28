using Microsoft.EntityFrameworkCore;
using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB
{
    public class KitchenFridgeContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Fridge> Fridges { get; set; } = null!;
        public DbSet<FridgeProduct> FridgeProducts { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<RecipeProduct> RecipeProducts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=KitchenFridgeDb;Trusted_Connection=True;TrustServerCertificate=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(n => n.Name).HasMaxLength(20);
            modelBuilder.Entity<Fridge>().Property(n => n.Name).HasMaxLength(20);
            modelBuilder.Entity<FridgeProduct>().ToTable(c => c.HasCheckConstraint("ValidCount", "Count > 0 AND Count < 21"));
            modelBuilder.Entity<Recipe>().Property(n => n.Name).HasMaxLength(20);
            modelBuilder.Entity<RecipeProduct>().ToTable(c => c.HasCheckConstraint("ValidCount", "Count > 0 AND Count < 21"));
        }

    }
}
