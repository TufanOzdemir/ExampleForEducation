using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Users.GetUsers;

/// <summary>
/// Tüm kullanıcıları getirme (MediatR query).
/// </summary>
public record GetUsersQuery : IRequest<List<User>>;
