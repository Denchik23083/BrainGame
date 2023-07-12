namespace BrainGame.Core.Exceptions
{
    public class AdminNotFoundException : Exception
    {
        public AdminNotFoundException() { }

        public AdminNotFoundException(string message) : base(message) { }
    }
}
