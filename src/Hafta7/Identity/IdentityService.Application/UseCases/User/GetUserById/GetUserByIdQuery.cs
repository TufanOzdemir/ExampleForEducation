using IdentityService.Domain.Entities;
using MediatR;

namespace IdentityService.Application.UseCases.Users.GetUserById;

/// <summary>
/// Id ile kullanıcı getirme (MediatR query).
/// </summary>
public record GetUserByIdQuery(int Id) : IRequest<User>;
