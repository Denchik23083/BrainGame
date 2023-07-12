using BrainGame.Db.Entities.Auth;

namespace BrainGame.Db.Entities.Quiz
{
    public class Statistics
    {
        public int Id { get; set; }

        public int Point { get; set; }

        public int? QuizId { get; set; }

        public Quizzes? Quizzes { get; set; }

        public int? UserId { get; set; }

        public User? User { get; set; }
    }
}
