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

        public async Task<IEnumerable<Quizzes>> GetAllQuizzesAsync()
        {
            var quizzes = await _repository.GetAllQuizzesAsync();

            if (quizzes is null)
            {
                throw new QuizNotFoundException("Quizzes not found");
            }

            return quizzes;
        }

        public async Task CreateQuizAsync(Quizzes quiz)
        {
            await _repository.CreateQuizAsync(quiz);
        }

        public async Task UpdateQuizAsync(Quizzes quiz, int id)
        {
            var quizToUpdate = await _repository.GetQuizAsync(id);

            if (quizToUpdate is null)
            {
                throw new QuizNotFoundException("Quiz not found");
            }

            quizToUpdate.Name = quiz.Name;

            await _repository.UpdateQuizAsync(quizToUpdate);
        }

        public async Task DeleteQuizAsync(int id)
        {
            var quizToDelete = await _repository.GetQuizAsync(id);

            if (quizToDelete is null)
            {
                throw new QuizNotFoundException("Quiz not found");
            }

            await _repository.DeleteQuizAsync(quizToDelete);
        }
    }
}