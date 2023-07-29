using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository.QuestionRepository
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Questions>> GetQuestions(int quizId);

        Task<Questions> GetQuestion(int id);

        Task CreateQuestion(Questions question);

        Task UpdateQuestion(Questions questionToUpdate);

        Task DeleteQuestion(Questions questionToDelete);
    }
}
