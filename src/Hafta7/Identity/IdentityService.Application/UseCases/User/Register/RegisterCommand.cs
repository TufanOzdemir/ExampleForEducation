using IdentityService.Application.DTOs;
using MediatR;

namespace IdentityService.Application.UseCases.Users.Register;

/// <summary>
/// Kullanıcı kaydı (MediatR command).
/// </summary>
public record RegisterCommand(RegisterRequest register) : IRequest<Unit>;
