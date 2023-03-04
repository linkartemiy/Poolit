namespace Poolit.Models.Responses;

public class LoginResponse
{
    public int Status { get; set; }
    public User User { get; set; }
    public string Error { get; set; }
}
