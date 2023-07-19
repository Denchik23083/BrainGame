using BrainGame.Db.Entities.Quiz;
using BrainGame.WebDb.QuizRepository.QuizRepository;
using BrainGame.WebDb.QuizRepository.StatisticsRepository;

namespace BrainGame.Logic.QuizService.StatisticsService
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository _repository;
        private readonly IQuizRepository _quizRepository;
        public static Quizzes GetPoints = null!;
        public static int CountQuiz;
        public static List<Statistics> StatisticsList = new();

        public StatisticsService(IStatisticsRepository repository, IQuizRepository quizRepository)
        {
            _repository = repository;
            _quizRepository = quizRepository;
        }

        public IEnumerable<Quizzes> GetStatistics()
        {
            var statistics = StatisticsList;

            if (statistics is null)
            {
                throw new ArgumentNullException();
            }

            return new List<Quizzes>();
        }

        public void Clear()
        {
            StatisticsList.Clear();
            CountQuiz = 0;
        }

        public async Task<Quizzes> GetPoint()
        {
            /*var quizId = QuizService.Quiz.Id;

            var getPoint = await _repository.GetPoint(quizId);

            GetPoints = getPoint;

            return getPoint;*/

            throw new NotImplementedException();
        }

        public void Result()
        {

        }

        public async Task RemovePoint()
        {
            /*var quiz = await _quizRepository.GetQuiz(QuizService.Quiz);

            await _repository.RemovePoint(quiz);*/

            throw new NotImplementedException();
        }
    }
}