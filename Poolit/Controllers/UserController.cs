using Microsoft.AspNetCore.Mvc;
using Poolit.Models.User;
using Poolit.Models.User.Requests;
using Poolit.Models.User.Responses;
using Poolit.Services.Interfaces;

namespace Poolit.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    /// <summary>
    /// User signing up.
    /// </summary>
    /// <param name="login">User's login.</param>
    /// <param name="password">User's password.</param>
    /// <returns></returns>
    [Route("/register")]
    [HttpPost]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RegisterResponse>> Register(string login, string password)
    {
        try
        {
            var request = new RegisterRequest { Login = login, Password = password };
            var response = await _userService.RegisterAsync(request);
            return response.Status switch
            {
                AuthStatus.Success => Ok(response),
                _ => BadRequest(response)
            };
        }
        catch (Exception e)
        {
            var response = new RegisterResponse { Status = AuthStatus.Error, Error = e.Message };
            return BadRequest(response);
        }
    }

    /// <summary>
    /// User signing in.
    /// </summary>
    /// <param name="login">User's login.</param>
    /// <param name="password">User's password.</param>
    /// <param name="token">User's token.</param>
    /// <returns></returns>
    [Route("/login")]
    [HttpPost]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LoginResponse>> Login(string login, string password, string? token)
    {
        try
        {
            var request = new LoginRequest { Login = login, Password = password, Token = token };
            var response = await _userService.LoginAsync(request);
            return response.Status switch
            {
                AuthStatus.Success => Ok(response),
                _ => BadRequest(response)
            };
        }
        catch (Exception e)
        {
            var response = new LoginResponse { Status = AuthStatus.Error, Error = e.Message };
            return BadRequest(response);
        }
    }
}