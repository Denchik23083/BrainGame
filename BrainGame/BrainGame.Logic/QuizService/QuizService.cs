using System;
using System.Threading.Tasks;
using BrainGame.Db.Entities.Quiz;
using BrainGame.WebDb.QuizRepository;

namespace BrainGame.Logic.QuizService
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _repository;
        public static Quizzes Quiz;
        public static Questions Questions;

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
            var question = await _repository.GetQuestions(id, Quiz.Id);

            Questions = question ?? throw new ArgumentNullException();
            
            return question;
        }
    }
}