using System;
using System.Collections.Generic;
using BrainGame.Db.Entities;
using BrainGame.WebDb;

namespace BrainGame.Logic
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository _repository;

        public StatisticsService(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Quizzes> GetStatistics()
        {
            var statistics = _repository.GetStatistics();

            if (statistics is null)
            {
                throw new ArgumentNullException();
            }

            return statistics;
        }
    }
}