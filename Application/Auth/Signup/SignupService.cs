using Application.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.Signup;

public class SignupService : IRequestHandler<SignupRequest, Response>
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public SignupService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<Response> Handle(SignupRequest request, CancellationToken cancellationToken)
    {
        var user = new IdentityUser { UserName = request.Email };
        var result = await _userManager.CreateAsync(user, password: request.Password);
        if (!result.Succeeded) return new Response(IsSuccess: false,Message:result.Errors.ToString());

        var signInAsync = await _signInManager.PasswordSignInAsync(user, password: request.Password, true, false);
        return new Response(IsSuccess: signInAsync.Succeeded);
    }
}