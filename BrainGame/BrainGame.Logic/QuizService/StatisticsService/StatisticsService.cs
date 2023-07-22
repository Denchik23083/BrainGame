using BrainGame.Core.Exceptions;
using BrainGame.Db.Entities.Quiz;
using BrainGame.WebDb.QuizRepository.StatisticsRepository;
using BrainGame.WebDb.UsersRepository.UserRepository;

namespace BrainGame.Logic.QuizService.StatisticsService
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository _repository;
        private readonly IUserRepository _userRepository;

        public static List<Statistics> StatisticsList = new();

        public StatisticsService(IStatisticsRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Statistics>> GetStatistics()
        {
            var statistics = await _repository.GetStatistics();

            if (statistics is null)
            {
                throw new StatisticsNotFoundException("Statistics not found");
            }

            return statistics;
        }

        public async Task CreateSession(int quizId, int userId)
        {
            var user = await _userRepository.GetUser(userId);

            if (user is null)
            {
                throw new UserNotFoundException("User not found");
            }

            var newSession = new Statistics { QuizId = quizId, UserId = user.Id, Point = 0 };

            var statistic = StatisticsList.FirstOrDefault(_ => _.QuizId == quizId && _.UserId == user.Id);

            if (statistic is not null)
            {
                StatisticsList.Remove(statistic);
            }

            StatisticsList.Add(newSession);
        }

        public async Task AddPoint(int quizId, int userId)
        {
            var user = await _userRepository.GetUser(userId);

            if (user is null)
            {
                throw new UserNotFoundException("User not found");
            }

            var statistic = StatisticsList.FirstOrDefault(_ => _.QuizId == quizId && _.UserId == user.Id);

            if (statistic is null)
            {
                throw new StatisticsNotFoundException("Statistics not found");
            }

            statistic.Point++;
        }

        public void Clear()
        {
            StatisticsList.Clear();
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