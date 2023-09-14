using BrainGame.Core.Exceptions;
using BrainGame.Db.Entities.Quiz;
using BrainGame.WebDb.QuizRepository.CorrectRepository;

namespace BrainGame.Logic.QuizService.CorrectService
{
    public class CorrectService : ICorrectService
    {
        private readonly ICorrectRepository _repository;

        public CorrectService(ICorrectRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CorrectAsync(Correct correctAnswerUser)
        {
            var correct = await _repository.CorrectAsync(correctAnswerUser.QuestionId);

            if (correct is null)
            {
                throw new CorrectNotFoundException("Correct not found");
            }

            return correct.CorrectAnswer!.Equals(correctAnswerUser.CorrectAnswer);
        }
    }
}