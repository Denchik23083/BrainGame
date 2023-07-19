using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService.CorrectService
{
    public interface ICorrectService
    {
        Task Correct(Correct correctAnswerUser);
    }
}