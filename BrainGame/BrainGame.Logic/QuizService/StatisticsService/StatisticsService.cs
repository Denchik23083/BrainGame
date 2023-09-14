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

        private static readonly List<Statistics> _statisticsList = new();

        public StatisticsService(IStatisticsRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Statistics>> GetStatisticsAsync(int userId)
        {
            var statistics = await _repository.GetStatisticsAsync(userId);

            if (statistics is null)
            {
                throw new StatisticsNotFoundException("Statistics not found");
            }

            return statistics;
        }

        public async Task CreateSessionAsync(int quizId, int userId)
        {
            var user = await _userRepository.GetUserAsync(userId);

            if (user is null)
            {
                throw new UserNotFoundException("User not found");
            }

            var newSession = new Statistics { QuizId = quizId, UserId = user.Id, Point = 0 };

            var statistics = _statisticsList.FirstOrDefault(_ => _.UserId == user.Id);

            if (statistics is not null)
            {
                _statisticsList.Remove(statistics);
            }

            _statisticsList.Add(newSession);
        }

        public async Task AddPointAsync(int quizId, int userId)
        {
            var user = await _userRepository.GetUserAsync(userId);

            if (user is null)
            {
                throw new UserNotFoundException("User not found");
            }

            var statistics = _statisticsList.FirstOrDefault(_ => _.QuizId == quizId && _.UserId == user.Id);

            if (statistics is null)
            {
                throw new StatisticsNotFoundException("Statistics not found");
            }

            statistics.Point++;
        }

        public async Task<Statistics> GetPointsAsync(int quizId, int userId)
        {
            var user = await _userRepository.GetUserAsync(userId);

            if (user is null)
            {
                throw new UserNotFoundException("User not found");
            }

            var statistics = _statisticsList.FirstOrDefault(_ => _.QuizId == quizId && _.UserId == user.Id);

            if (statistics is null)
            {
                throw new StatisticsNotFoundException("Statistics not found");
            }

            await _repository.SavePointsAsync(statistics);

            return statistics;
        }

        public async Task ResetStatisticsAsync(int userId)
        {
            var user = await _userRepository.GetUserAsync(userId);

            if (user is null)
            {
                throw new UserNotFoundException("User not found");
            }

            var statistic = _statisticsList.FirstOrDefault(_ => _.UserId == user.Id);

            if (statistic is not null)
            {
                _statisticsList.Remove(statistic);
            }

            var statistics = await _repository.GetStatisticsAsync(userId);

            await _repository.ResetStatisticsAsync(statistics);
        }
    }
}