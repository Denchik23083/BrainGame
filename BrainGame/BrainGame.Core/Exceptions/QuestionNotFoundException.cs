namespace BrainGame.Core.Exceptions
{
    public class QuestionNotFoundException : Exception
    {
        public QuestionNotFoundException() { }

        public QuestionNotFoundException(string message) : base(message) { }
    }
}
