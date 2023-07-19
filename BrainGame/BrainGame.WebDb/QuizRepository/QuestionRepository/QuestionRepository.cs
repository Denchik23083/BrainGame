using BrainGame.Db;
using BrainGame.Db.Entities.Quiz;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb.QuizRepository.QuestionRepository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly BrainGameContext _context;

        public QuestionRepository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Questions>> GetQuestions(int quizId)
        {
            return await _context.Questions
                .Include(_ => _.Correct)
                .Where(_ => _.QuizId == quizId)
                .ToListAsync();
        }
    }
}
