using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService.CorrectsService
{
    public interface ICorrectsService
    {
        Task Correct(Correct correctAnswerUser);
    }
}