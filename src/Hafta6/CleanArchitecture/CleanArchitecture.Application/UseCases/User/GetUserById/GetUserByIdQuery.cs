using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Users.GetUserById;

/// <summary>
/// Id ile kullanıcı getirme (MediatR query).
/// </summary>
public record GetUserByIdQuery(int Id) : IRequest<User>;
