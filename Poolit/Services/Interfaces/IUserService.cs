using Poolit.Models.User;
using Poolit.Models.User.Requests;
using Poolit.Models.User.Responses;

namespace Poolit.Services.Interfaces
{
    public interface IUserService
    {
        public Task<RegisterResponse> RegisterAsync(RegisterRequest request);
        public Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}
