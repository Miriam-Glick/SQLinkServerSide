using SqLinkServer.DataDB;

namespace SqLinkServer.Models
{
    public class LoginResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string JoinedAt { get; set; }

        public string avatar { get; set; }
        public string Team { get; set; }
        public string Token { get; set; }
        public LoginResponse(User user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Team = user.Team;
            JoinedAt = user.JoinedAt.ToString();
            Token = token;
        }
    }
}
