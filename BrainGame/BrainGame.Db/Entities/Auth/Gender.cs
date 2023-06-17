namespace BrainGame.Db.Entities.Auth
{
    public class Gender
    {
        public int Id { get; set; }

        public string? Type { get; set; }

        public List<User>? Users { get; set; }
    }
}
