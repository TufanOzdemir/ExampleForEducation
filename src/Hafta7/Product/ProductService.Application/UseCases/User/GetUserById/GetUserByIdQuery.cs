using ProductService.Domain.Entities;
using MediatR;

namespace ProductService.Application.UseCases.Users.GetUserById;

/// <summary>
/// Id ile kullanıcı getirme (MediatR query).
/// </summary>
public record GetUserByIdQuery(int Id) : IRequest<User>;
