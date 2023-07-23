using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Quiz.Models
{
    public class StatisticsReadModel
    {
        public int Point { get; set; }

        public int? QuizId { get; set; }

        public Quizzes? Quizzes { get; set; }
    }
}
