namespace BrainGame.Users.Models
{
    public class AdminReadModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public int? GenderId { get; set; }

        public int? RoleId { get; set; }
    }
}
