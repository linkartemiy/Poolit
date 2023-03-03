namespace Poolit.Models.User.Requests
{
    public class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
