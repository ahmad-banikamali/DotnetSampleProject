using Application.Infrastructure;
using MediatR;

namespace Application.Auth.Login;

public record LoginRequest(string Email, string Password) : IRequest<Response>;