namespace BrainGame.Core.Exceptions
{
    public class QuestionsNotFoundException : Exception
    {
        public QuestionsNotFoundException() { }

        public QuestionsNotFoundException(string message) : base(message) { }
    }
}
