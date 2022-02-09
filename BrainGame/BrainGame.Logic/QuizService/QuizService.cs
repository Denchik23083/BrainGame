using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrainGame.Db.Entities.Quiz;
using BrainGame.WebDb.QuizRepository;

namespace BrainGame.Logic.QuizService
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _repository;
        public static Quizzes Quiz;
        public static int CorrectId;
        public static List<Quizzes> StatisticsList = new List<Quizzes>();
        public static int CountQuiz;
        public static Quizzes GetPoint;

        public QuizService(IQuizRepository repository)
        {
            _repository = repository;
        }

        public async Task<Quizzes> GetQuiz(Quizzes model)
        {
            var quiz = await _repository.GetQuiz(model);

            Quiz = quiz;

            return quiz;
        }

        public async Task<Questions> GetQuestions(int id)
        {
            var question = await _repository.GetQuestions(id);

            if (question is null)
            {
                throw new ArgumentNullException();
            }
            
            CorrectId = question.CorrectAnswerId;
            
            return question;
        }
    }
}