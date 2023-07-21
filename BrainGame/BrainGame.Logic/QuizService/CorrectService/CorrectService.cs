using BrainGame.Db.Entities.Quiz;
using BrainGame.Logic.QuizService.StatisticsService;
using BrainGame.WebDb.QuizRepository.CorrectRepository;
using BrainGame.WebDb.QuizRepository.QuizRepository;

namespace BrainGame.Logic.QuizService.CorrectService
{
    public class CorrectService : ICorrectService
    {
        private readonly ICorrectRepository _repository;
        private readonly IStatisticsService _statisticsService;

        public CorrectService(ICorrectRepository repository, IStatisticsService statisticsService)
        {
            _repository = repository;
            _statisticsService = statisticsService;
        }

        public async Task<bool> Correct(Correct correctAnswerUser)
        {
            var correct = await _repository.Correct(correctAnswerUser.QuestionId);

            return correct.CorrectAnswer!.Equals(correctAnswerUser.CorrectAnswer);
        }
    }
}