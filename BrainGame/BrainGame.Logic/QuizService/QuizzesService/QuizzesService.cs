using BrainGame.Core.Exceptions;
using BrainGame.Db.Entities.Quiz;
using BrainGame.WebDb.QuizRepository.QuizzesRepository;

namespace BrainGame.Logic.QuizService.QuizzesService
{
    public class QuizzesService : IQuizzesService
    {
        private readonly IQuizzesRepository _repository;

        public QuizzesService(IQuizzesRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<Quizzes>> GetQuizzes()
        {
            var quizzes = await _repository.GetQuizzes();

            if (quizzes is null)
            {
                throw new QuizzesNotFoundException("Quizzes not found");
            }

            return quizzes;
        }

        public async Task<IEnumerable<Questions>> GetQuestions(int quizId)
        {
            var questions = await _repository.GetQuestions(quizId);

            if (questions is null)
            {
                throw new QuestionsNotFoundException("Questions not found");
            }

            return questions;
        }
    }
}