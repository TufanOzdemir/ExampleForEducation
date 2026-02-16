using ProductService.Application.DTOs;
using MediatR;

namespace ProductService.Application.UseCases.Users.Login;

/// <summary>
/// Kullanıcı kaydı (MediatR command).
/// </summary>
public record RegisterCommand(RegisterRequest register) : IRequest<Unit>;
