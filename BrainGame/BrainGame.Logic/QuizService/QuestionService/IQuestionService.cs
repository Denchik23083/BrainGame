using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService.QuestionService
{
    public interface IQuestionService
    {
        Task<IEnumerable<Questions>> GetQuestionsAsync(int quizId);

        Task CreateQuestionAsync(Questions question);

        Task UpdateQuestionAsync(Questions question, int id);

        Task DeleteQuestionAsync(int id);
    }
}
