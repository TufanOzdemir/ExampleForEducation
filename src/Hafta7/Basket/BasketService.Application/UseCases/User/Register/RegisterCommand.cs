using BasketService.Application.DTOs;
using MediatR;

namespace BasketService.Application.UseCases.Users.Login;

/// <summary>
/// Kullanıcı kaydı (MediatR command).
/// </summary>
public record RegisterCommand(RegisterRequest register) : IRequest<Unit>;
