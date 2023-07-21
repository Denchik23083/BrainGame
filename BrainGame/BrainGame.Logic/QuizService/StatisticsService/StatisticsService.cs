using BrainGame.Db.Entities.Auth;
using BrainGame.Db.Entities.Quiz;
using BrainGame.WebDb.QuizRepository.QuestionRepository;
using BrainGame.WebDb.QuizRepository.QuizRepository;
using BrainGame.WebDb.QuizRepository.StatisticsRepository;

namespace BrainGame.Logic.QuizService.StatisticsService
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository _repository;
        private readonly IQuestionRepository _questionRepository;
        public static Quizzes GetPoints = null!;
        public static int CountQuiz;
        public static List<Statistics> StatisticsList = new();

        public StatisticsService(IStatisticsRepository repository, IQuestionRepository questionRepository)
        {
            _repository = repository;
            _questionRepository = questionRepository;
        }

        public IEnumerable<Statistics> GetStatistics()
        {
            return StatisticsList;
        }

        public void Create(int quizId, int userId)
        {
            var statistic = StatisticsList.FirstOrDefault(_ => _.QuizId == quizId && _.UserId == userId);

            if (statistic is null)
            {
                StatisticsList.Add(new Statistics { QuizId = quizId, UserId = userId, Point = 0 });
            }
        }

        public async Task AddPoint(int questionId)
        {
            var question = await _questionRepository.GetQuestion(questionId);

            var statistic = StatisticsList.FirstOrDefault(_ => _.QuizId == question.QuizId);

            statistic!.Point++;
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