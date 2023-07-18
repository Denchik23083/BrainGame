namespace BrainGame.Quiz.Models
{
    public class QuestionsReadModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string? Question { get; set; }

        public string? Answers { get; set; }
    }
}
