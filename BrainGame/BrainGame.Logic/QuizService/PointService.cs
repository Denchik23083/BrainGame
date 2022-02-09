using System.Collections.Generic;
using System.Threading.Tasks;
using BrainGame.Db.Entities.Quiz;
using BrainGame.WebDb.QuizRepository;

namespace BrainGame.Logic.QuizService
{
    public class PointService : IPointService
    {
        private readonly IPointRepository _repository;
        public static Quizzes GetPoints;
        public static int CountQuiz;
        public static List<Quizzes> StatisticsList = new List<Quizzes>();

        public PointService(IPointRepository repository)
        {
            _repository = repository;
        }

        public async Task<Quizzes> GetPoint()
        {
            var getPoint = await _repository.GetPoint();

            GetPoints = getPoint;

            return getPoint;
        }

        public void Result()
        {
            GetPoints.Id = ++CountQuiz;

            StatisticsList.Add(GetPoints);
        }

        public async Task RemovePoint()
        {
            await _repository.RemovePoint();
        }
    }
}