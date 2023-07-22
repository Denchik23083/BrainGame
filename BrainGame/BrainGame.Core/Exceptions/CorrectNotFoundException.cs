namespace BrainGame.Core.Exceptions
{
    public class CorrectNotFoundException : Exception
    {
        public CorrectNotFoundException() { }

        public CorrectNotFoundException(string message) : base(message) { }
    }
}
