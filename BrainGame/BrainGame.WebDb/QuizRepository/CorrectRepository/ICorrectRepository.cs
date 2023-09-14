using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository.CorrectRepository
{
    public interface ICorrectRepository
    {
        Task<Correct?> CorrectAsync(int id);
    }
}