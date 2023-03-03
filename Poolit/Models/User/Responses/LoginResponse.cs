namespace Poolit.Models.User.Responses
{
    public class LoginResponse
    {
        public AuthStatus Status { get; set; }
        public User User { get; set; }
        public string Error { get; set; }
    }

    public enum AuthStatus
    {
        Undefined = 0,
        Success = 1,
        Error = 2
    }
}
