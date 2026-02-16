using IdentityService.Domain.Common;

namespace IdentityService.Domain.Entities;

public partial class User : AggregateRoot
{
    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? PasswordHash { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
