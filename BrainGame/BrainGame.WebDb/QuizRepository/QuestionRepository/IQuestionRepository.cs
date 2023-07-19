using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository.QuestionRepository
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Questions>> GetQuestions(int quizId);
    }
}
