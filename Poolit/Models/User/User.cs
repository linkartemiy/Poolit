namespace Poolit.Models.User
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public User(string login)
        {
            Login = login;
        }
    }
}
