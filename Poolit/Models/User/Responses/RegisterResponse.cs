namespace Poolit.Models.User.Responses
{
    public class RegisterResponse
    {
        public AuthStatus Status { get; set; }
        public User User { get; set; }
        public string Error { get; set; }
    }
}
