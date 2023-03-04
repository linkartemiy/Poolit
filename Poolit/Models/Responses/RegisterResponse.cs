namespace Poolit.Models.Responses;

public class RegisterResponse
{
    public int Status { get; set; }
    public User User { get; set; }
    public string Error { get; set; }
}
