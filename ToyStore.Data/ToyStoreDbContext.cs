namespace ToyStore.Data
{
    using Microsoft.EntityFrameworkCore;
    using ToyStore.Data.Models;

    public class ToyStoreDbContext : DbContext
    {
        public ToyStoreDbContext(DbContextOptions<ToyStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Toy> Toys { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<ToyCategory> ToyCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<ToyCategory>()
                .HasKey(tc => new { tc.ToyId, tc.CategoryId });

            builder
                .Entity<Toy>()
                .HasOne(b => b.Manufacturer)
                .WithMany(m => m.Toys)
                .HasForeignKey(t => t.ManufacturerId);

            builder
                .Entity<Toy>()
                .HasMany(t => t.Categories)
                .WithOne(tc => tc.Toy)
                .HasForeignKey(tc => tc.ToyId);

            builder
                .Entity<Category>()
                .HasMany(c => c.Toys)
                .WithOne(tc => tc.Category)
                .HasForeignKey(tc => tc.CategoryId);
        }
    }
}
