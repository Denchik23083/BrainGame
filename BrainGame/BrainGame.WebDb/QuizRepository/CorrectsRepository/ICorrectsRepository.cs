using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository.CorrectsRepository
{
    public interface ICorrectsRepository
    {
        Task<Correct> Correct(int id);
    }
}