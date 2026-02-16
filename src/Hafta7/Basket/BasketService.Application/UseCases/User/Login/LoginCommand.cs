using MediatR;

namespace BasketService.Application.UseCases.Users.Login;

/// <summary>
/// Kullanıcı girişi (MediatR query).
/// </summary>
public record LoginCommand(string Email, string Password) : IRequest<string>;
