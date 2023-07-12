using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Quiz.Models
{
    public class QuestionsReadModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string? Question { get; set; }

        public string? Answers { get; set; }

        public int CorrectId { get; set; }

        public Correct? Correct { get; set; }
    }
}
