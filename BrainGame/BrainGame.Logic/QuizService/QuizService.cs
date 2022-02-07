using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrainGame.Db.Entities;
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

        public async Task<AnimalQuestions> GetAnimalsQuestions(int id)
        {
            var question = await _repository.GetAnimalsQuestions(id);

            if (question is null)
            {
                throw new ArgumentNullException();
            }
            
            CorrectId = question.CorrectAnswerId;
            
            return question;
        }

        public async Task<PlantsQuestions> GetPlantsQuestions(int id)
        {
            var question = await _repository.GetPlantsQuestions(id);

            if (question is null)
            {
                throw new ArgumentNullException();
            }
            
            CorrectId = question.CorrectAnswerId;

            return question;
        }

        public async Task<MushroomsQuestions> GetMushroomsQuestions(int id)
        {
            var question = await _repository.GetMushroomsQuestions(id);

            if (question is null)
            {
                throw new ArgumentNullException();
            }
            
            CorrectId = question.CorrectAnswerId;
            
            return question;
        }
    }
}