using IdentityService.Domain.Entities;
using MediatR;

namespace IdentityService.Application.UseCases.Users.GetUsers;

/// <summary>
/// Tüm kullanıcıları getirme (MediatR query).
/// </summary>
public record GetUsersQuery : IRequest<List<User>>;
