namespace BrainGame.Core.Exceptions
{
    public class QuizNotFoundException : Exception
    {
        public QuizNotFoundException() { }

        public QuizNotFoundException(string message) : base(message) { }
    }
}
