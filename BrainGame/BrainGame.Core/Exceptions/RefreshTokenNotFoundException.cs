namespace BrainGame.Core.Exceptions
{
    public class RefreshTokenNotFoundException : Exception
    {
        public RefreshTokenNotFoundException() { }

        public RefreshTokenNotFoundException(string message) : base(message) { }
    }
}
