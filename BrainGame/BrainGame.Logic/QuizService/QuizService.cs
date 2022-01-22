using System;
using System.Threading.Tasks;
using BrainGame.Db.Entities;
using BrainGame.WebDb.QuizRepository;

namespace BrainGame.Logic.QuizService
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _repository;
        public static Quizzes _quiz;
        public static int _correctId;

        public QuizService(IQuizRepository repository)
        {
            _repository = repository;
        }

        public async Task<Quizzes> Quiz(Quizzes model)
        {
            var quiz = await _repository.Quiz(model);

            _quiz = quiz;

            return quiz;
        }

        public async Task<AnimalQuestions> GetAnimalsQuestions(int id)
        {
            var question = await _repository.GetAnimalsQuestions(id);

            if (question is null)
            {
                throw new ArgumentNullException();
            }
            
            _correctId = question.CorrectAnswerId;
            
            return question;
        }

        public async Task<PlantsQuestions> GetPlantsQuestions(int id)
        {
            var question = await _repository.GetPlantsQuestions(id);

            if (question is null)
            {
                throw new ArgumentNullException();
            }
            
            _correctId = question.CorrectAnswerId;

            return question;
        }

        public async Task<MushroomsQuestions> GetMushroomsQuestions(int id)
        {
            var question = await _repository.GetMushroomsQuestions(id);

            if (question is null)
            {
                throw new ArgumentNullException();
            }
            
            _correctId = question.CorrectAnswerId;
            
            return question;
        }

        public async Task<Quizzes> GetPoint()
        {
            return await _repository.GetPoint();
        }

        public async Task RemovePoint()
        {
            await _repository.RemovePoint();
        }
    }
}