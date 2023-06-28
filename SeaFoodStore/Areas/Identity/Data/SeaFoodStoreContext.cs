using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeaFoodStore.Areas.Identity.Data;
using SeaFoodStore.Models;

namespace SeaFoodStore.Areas.Identity.Data;

public class SeaFoodStoreContext : IdentityDbContext<SeaFoodStoreUser>
{
    public SeaFoodStoreContext(DbContextOptions<SeaFoodStoreContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new SeaFoodStoreEntityConfiguration());
    }

    public DbSet<SeaFoodStore.Models.CustomerTable> CustomerTable { get; set; } = default!;

    public DbSet<SeaFoodStore.Models.ProductTable> ProductTable { get; set; } = default!;

    public DbSet<SeaFoodStore.Models.OrdersTable> OrdersTable { get; set; } = default!;

    public DbSet<SeaFoodStore.Models.CategoriesTable> CategoriesTable { get; set; } = default!;

    public DbSet<SeaFoodStore.Models.BrandTable> BrandTable { get; set; } = default!;

    public DbSet<SeaFoodStore.Models.StockTable> StockTable { get; set; } = default!;

    public DbSet<SeaFoodStore.Models.StoreTable> StoreTable { get; set; } = default!;
}

internal class SeaFoodStoreEntityConfiguration : IEntityTypeConfiguration<SeaFoodStoreUser>
{
    public void Configure(EntityTypeBuilder<SeaFoodStoreUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.FirstName).HasMaxLength(255);       
    }
}