using IdentityService.Domain.Common;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure;

internal partial class IdentityDbContext : DbContext
{
    private readonly IMediator _mediator;

    public IdentityDbContext(IMediator mediator) => _mediator = mediator;

    public IdentityDbContext(DbContextOptions<IdentityDbContext> options, IMediator mediator)
        : base(options) => _mediator = mediator;

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Permission> Permissions { get; set; }

    public override int SaveChanges()
    {
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
                    "UserPermission",
                    j => j
                        .HasOne<Permission>()
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .HasPrincipalKey(p => p.Id),
                    j => j
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasPrincipalKey(u => u.Id),
                    j => j.HasKey("UserId", "PermissionId"));
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.ToTable("Permission");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
