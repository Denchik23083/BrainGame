namespace BrainGame.Core.Exceptions
{
    public class QuizzesNotFoundException : Exception
    {
        public QuizzesNotFoundException() { }

        public QuizzesNotFoundException(string message) : base(message) { }
    }
}
