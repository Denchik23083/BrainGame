namespace BrainGame.Db.Entities.Auth
{
    public class User
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public int? GenderId { get; set; }

        public Gender? Gender { get; set; }

        public RefreshToken? RefreshToken { get; set; }
    }
}