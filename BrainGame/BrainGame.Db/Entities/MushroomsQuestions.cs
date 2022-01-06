namespace BrainGame.Db.Entities
{
    public class MushroomsQuestions
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string Answers { get; set; }

        public int CorrectAnswerId { get; set; }

        public Correct Correct { get; set; }

        public int QuizId { get; set; }

        public Quizzes Quizzes { get; set; }
    }
}