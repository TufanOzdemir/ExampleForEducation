using ProductService.Domain.Entities;
using MediatR;

namespace ProductService.Application.UseCases.Users.GetUsers;

/// <summary>
/// Tüm kullanıcıları getirme (MediatR query).
/// </summary>
public record GetUsersQuery : IRequest<List<User>>;
