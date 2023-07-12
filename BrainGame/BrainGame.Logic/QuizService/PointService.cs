using BrainGame.Db.Entities.Quiz;
using BrainGame.WebDb.QuizRepository;

namespace BrainGame.Logic.QuizService
{
    public class PointService : IPointService
    {
        private readonly IPointRepository _repository;
        private readonly IQuizRepository _quizRepository;
        public static Quizzes GetPoints = null!;
        public static int CountQuiz;
        public static List<Quizzes> StatisticsList = new();

        public PointService(IPointRepository repository, IQuizRepository quizRepository)
        {
            _repository = repository;
            _quizRepository = quizRepository;
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
            GetPoints.Id = ++CountQuiz;

            StatisticsList.Add(GetPoints);
        }

        public async Task RemovePoint()
        {
            /*var quiz = await _quizRepository.GetQuiz(QuizService.Quiz);

            await _repository.RemovePoint(quiz);*/

            throw new NotImplementedException();
        }
    }
}