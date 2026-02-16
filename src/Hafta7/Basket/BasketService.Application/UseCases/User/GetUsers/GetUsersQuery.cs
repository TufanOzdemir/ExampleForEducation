using BasketService.Domain.Entities;
using MediatR;

namespace BasketService.Application.UseCases.Users.GetUsers;

/// <summary>
/// Tüm kullanıcıları getirme (MediatR query).
/// </summary>
public record GetUsersQuery : IRequest<List<User>>;
