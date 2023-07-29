using System.Text.Json.Serialization;

namespace BrainGame.Db.Entities.Quiz
{
    public class Correct
    {
        public int Id { get; set; }

        public string? CorrectAnswer { get; set; }

        public int QuestionId { get; set; }

        [JsonIgnore]
        public Questions? Question { get; set; }
    }
}