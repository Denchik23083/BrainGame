namespace BrainGame.Db.Entities.Quiz
{
    public class Questions
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string? Question { get; set; }

        public string? Answers { get; set; }

        public Correct? Correct { get; set; }

        public int QuizId { get; set; }

        public Quizzes? Quizzes { get; set; }
    }
}