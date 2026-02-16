using IdentityService.Application.DTOs;
using MediatR;

namespace IdentityService.Application.UseCases.Users.Login;

/// <summary>
/// Kullanıcı kaydı (MediatR command).
/// </summary>
public record RegisterCommand(RegisterRequest register) : IRequest<Unit>;
