using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Infrastructure;

internal partial class MarketplaceDbContext : DbContext
{
    private readonly IMediator _mediator;
    public MarketplaceDbContext(IMediator mediator)
    {
         _mediator = mediator;
    }

    public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options, IMediator mediator)
        : base(options)
    {
        _mediator = mediator;
    }

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public override int SaveChanges()
    {
        // TODO: Implement domain event publishing
        var result = base.SaveChanges();

        var entitiesWithEvents = ChangeTracker.Entries<AggregateRoot>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToList();

        foreach (var entity in entitiesWithEvents)
        {
            foreach (var domainEvent in entity.DomainEvents)
            {
                _mediator.Publish(domainEvent);
            }
            entity.ClearDomainEvents();
        }

        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Basket>(entity =>
        {
            entity.ToTable("Basket");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.TotalPrice).HasColumnType("money");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.ToTable("OrderProduct");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PasswordHash).HasMaxLength(65);

            entity.HasMany(u => u.Permissions)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                "UserPermission", // Ara tablonun adı
                j => j
                    .HasOne<Permission>()
                    .WithMany()
                    .HasForeignKey("PermissionId") // Senin veritabanındaki kolon adı
                    .HasPrincipalKey(p => p.Id),
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId") // Senin veritabanındaki kolon adı
                    .HasPrincipalKey(u => u.Id),
                j =>
                {
                    j.HasKey("UserId", "PermissionId"); // Composite Key tanımı
                });
        });



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
