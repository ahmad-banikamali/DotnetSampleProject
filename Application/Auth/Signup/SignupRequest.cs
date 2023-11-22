using Application.Infrastructure;
using MediatR;

namespace Application.Auth.Signup;

public record SignupRequest(string Email, string Password) : IRequest<Response>;