using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService.QuestionService
{
    public interface IQuestionService
    {
        Task<IEnumerable<Questions>> GetQuestions(int quizId);
    }
}
