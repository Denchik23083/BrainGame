using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService.CorrectService
{
    public interface ICorrectService
    {
        Task<bool> Correct(Correct correctAnswerUser);
    }
}