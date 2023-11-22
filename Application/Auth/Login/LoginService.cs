using Application.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.Login;

public class LoginService : IRequestHandler<LoginRequest, Response>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public LoginService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<Response> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.Email);
        if (user == null)
        {
            return new Response(IsSuccess: false, Message: "user not found");
        }
        
        var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
        
        return signInResult.Succeeded ? new Response() : new Response(IsSuccess: false, Message: signInResult.ToString());
    }
}