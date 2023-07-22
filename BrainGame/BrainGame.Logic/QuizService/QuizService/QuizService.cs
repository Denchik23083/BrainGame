using BrainGame.Core.Exceptions;
using BrainGame.Db.Entities.Quiz;
using BrainGame.WebDb.QuizRepository.QuizRepository;

namespace BrainGame.Logic.QuizService.QuizService
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _repository;

        public QuizService(IQuizRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<Quizzes>> GetQuizzes()
        {
            var quizzes = await _repository.GetQuizzes();

            if (quizzes is null)
            {
                throw new QuizNotFoundException("Quizzes not found");
            }

            return quizzes;
        }
    }
}