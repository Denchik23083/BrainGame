using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Quiz.Models
{
    public class QuestionReadModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string? Question { get; set; }

        public string? Answers { get; set; }

        public Correct? Correct { get; set; }
    }
}
