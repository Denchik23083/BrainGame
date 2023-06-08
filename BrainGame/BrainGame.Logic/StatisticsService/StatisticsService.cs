using BrainGame.Db.Entities.Quiz;
using BrainGame.Logic.QuizService;

namespace BrainGame.Logic.StatisticsService
{
    public class StatisticsService : IStatisticsService
    {
        public IEnumerable<Quizzes> GetStatistics()
        {
            var statistics = PointService.StatisticsList;

            if (statistics is null)
            {
                throw new ArgumentNullException();
            }

            return statistics;
        }

        public void Clear()
        {
            PointService.StatisticsList.Clear();
            PointService.CountQuiz = 0;
        }
    }
}