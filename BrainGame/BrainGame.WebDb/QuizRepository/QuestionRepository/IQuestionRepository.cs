using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository.QuestionRepository
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Questions>> GetAllQuestionsAsync(int quizId);

        Task<Questions?> GetQuestionAsync(int id);

        Task CreateQuestionAsync(Questions question);

        Task UpdateQuestionAsync(Questions questionToUpdate);

        Task DeleteQuestionAsync(Questions questionToDelete);
    }
}
