using Microsoft.AspNetCore.Identity;
using Poolit.Models.User;
using Poolit.Models.User.Requests;
using Poolit.Models.User.Responses;
using Poolit.Services.Interfaces;

namespace Poolit.Services;

public class UserService : IUserService
{
    public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
    {
        var user = new User(request.Login);
        var hashedPassword = HashPassword(user, request.Password);
        user.Id = 0;
        return new RegisterResponse
        {
            User = user,
            Status = AuthStatus.Success,
        };
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var id = 0;
        // login: w, password: w
        var hashedPassword = "AQAAAAIAAYagAAAAENBPS1G889jxdh2gdddLCvhEA7gbyF2Jb7MsxOXKkiXWGzcYj9/Z4bfzQi/FTXrv6A==";
        var user = new User(request.Login);
        user.Id = id;

        if (VerifyPassword(user, hashedPassword, request.Password) != PasswordVerificationResult.Success)
        {
            return new LoginResponse
            {
                Error = "Wrong password",
                Status = AuthStatus.Error,
            };
        }

        return new LoginResponse
        {
            User = user,
            Status = AuthStatus.Success,
        };
    }

    private string HashPassword(User user, string password)
    {
        var passwordHasher = new PasswordHasher<User>();
        return passwordHasher.HashPassword(user, password);
    }

    private PasswordVerificationResult VerifyPassword(User user, string hashedPassword, string password)
    {
        var passwordHasher = new PasswordHasher<User>();
        return passwordHasher.VerifyHashedPassword(user, hashedPassword, password);
    }
}
