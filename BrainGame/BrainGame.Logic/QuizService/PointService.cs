using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrainGame.Db.Entities;
using BrainGame.WebDb.QuizRepository;

namespace BrainGame.Logic.QuizService
{
    public class PointService : IPointService
    {
        private readonly IPointRepository _repository;
        public static Quizzes _getPoint;
        public static int _countQuiz;
        public static List<Quizzes> StatisticsList = new List<Quizzes>();

        public PointService(IPointRepository repository)
        {
            _repository = repository;
        }

        public async Task<Quizzes> GetPoint()
        {
            var getPoint = await _repository.GetPoint();

            _getPoint = getPoint;

            return getPoint;
        }
        public void Result()
        {
            _getPoint.Id = ++_countQuiz;

            StatisticsList.Add(_getPoint);
        }

        public async Task RemovePoint()
        {
            await _repository.RemovePoint();
        }
    }
}