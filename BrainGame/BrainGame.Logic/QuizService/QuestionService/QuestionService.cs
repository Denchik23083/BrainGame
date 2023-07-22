using BrainGame.Core.Exceptions;
using BrainGame.Db.Entities.Quiz;
using BrainGame.WebDb.QuizRepository.QuestionRepository;

namespace BrainGame.Logic.QuizService.QuestionService
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;

        public QuestionService(IQuestionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Questions>> GetQuestions(int quizId)
        {
            var questions = await _repository.GetQuestions(quizId);

            if (questions is null)
            {
                throw new QuestionNotFoundException("Questions not found");
            }

            return questions;
        }
    }
}
