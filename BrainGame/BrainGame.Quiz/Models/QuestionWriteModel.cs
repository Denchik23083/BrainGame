using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Quiz.Models
{
    public class QuestionWriteModel
    {
        public int Number { get; set; }

        public string? Question { get; set; }

        public string? Answers { get; set; }

        public int QuizId { get; set; }

        public Correct? Correct { get; set; }
    }
}
