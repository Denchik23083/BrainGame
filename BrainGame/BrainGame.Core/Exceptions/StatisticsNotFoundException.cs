namespace BrainGame.Core.Exceptions
{
    public class StatisticsNotFoundException : Exception
    {
        public StatisticsNotFoundException() { }

        public StatisticsNotFoundException(string message) : base(message) { }
    }
}
