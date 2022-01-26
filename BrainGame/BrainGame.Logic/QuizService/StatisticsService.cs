using System;
using System.Collections.Generic;
using System.Net.Http;
using BrainGame.Db.Entities;

namespace BrainGame.Logic.QuizService
{
    public class StatisticsService : IStatisticsService
    {
        public IEnumerable<Quizzes> GetStatistics()
        {
            var statistics = QuizService.StatisticsList;

            if (statistics is null)
            {
                throw new ArgumentNullException();
            }

            return statistics;
        }

        public void Clear()
        {
            QuizService.StatisticsList.Clear();
            QuizService._countQuiz = 0;
        }
    }
}