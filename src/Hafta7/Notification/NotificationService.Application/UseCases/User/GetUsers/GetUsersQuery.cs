using NotificationService.Domain.Entities;
using MediatR;

namespace NotificationService.Application.UseCases.Users.GetUsers;

/// <summary>
/// Tüm kullanıcıları getirme (MediatR query).
/// </summary>
public record GetUsersQuery : IRequest<List<User>>;
