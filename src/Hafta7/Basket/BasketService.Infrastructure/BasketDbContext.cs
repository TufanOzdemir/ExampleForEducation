using BasketService.Domain.Common;
using BasketService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasketService.Infrastructure;

internal partial class BasketDbContext : DbContext
{
    public BasketDbContext() { }

    public BasketDbContext(DbContextOptions<BasketDbContext> options)
        : base(options) { }

    public virtual DbSet<Basket> Baskets { get; set; }
    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Basket>(entity =>
        {
            entity.ToTable("Basket");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
