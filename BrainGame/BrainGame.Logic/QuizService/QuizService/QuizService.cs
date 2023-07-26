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

        public async Task CreateQuiz(Quizzes quiz)
        {
            await _repository.CreateQuiz(quiz);
        }

        public async Task UpdateQuiz(Quizzes quiz, int id)
        {
            var quizToUpdate = await _repository.GetQuiz(id);

            if (quizToUpdate is null)
            {
                throw new QuizNotFoundException("Quiz not found");
            }

            quizToUpdate.Name = quiz.Name;

            await _repository.UpdateQuiz(quizToUpdate);
        }

        public async Task DeleteQuiz(int id)
        {
            var quizToDelete = await _repository.GetQuiz(id);

            if (quizToDelete is null)
            {
                throw new QuizNotFoundException("Quiz not found");
            }

            await _repository.DeleteQuiz(quizToDelete);
        }
    }
}