using CleanArchitecture.Application.DTOs;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Users.Login;

/// <summary>
/// Kullanıcı kaydı (MediatR command).
/// </summary>
public record RegisterCommand(RegisterRequest register) : IRequest<Unit>;
