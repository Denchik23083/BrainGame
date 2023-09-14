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

        public async Task<IEnumerable<Questions>> GetAllQuestionsAsync(int quizId)
        {
            return await _context.Questions
                .Include(_ => _.Correct)
                .Where(_ => _.QuizId == quizId)
                .OrderBy(b => b.Number)
                .ToListAsync();
        }

        public async Task<Questions?> GetQuestionAsync(int id)
        {
            return await _context.Questions
                .Include(_ => _.Correct)
                .FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task CreateQuestionAsync(Questions question)
        {
            await _context.Questions.AddAsync(question);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuestionAsync(Questions questionToUpdate)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuestionAsync(Questions questionToDelete)
        {
            _context.Questions.Remove(questionToDelete);

            await _context.SaveChangesAsync();
        }
    }
}
