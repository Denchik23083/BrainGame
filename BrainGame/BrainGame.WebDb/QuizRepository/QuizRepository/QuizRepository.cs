using BrainGame.Db;
using BrainGame.Db.Entities.Quiz;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb.QuizRepository.QuizRepository
{
    public class QuizRepository : IQuizRepository
    {
        private readonly BrainGameContext _context;

        public QuizRepository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quizzes>> GetAllQuizzesAsync()
        {
            return await _context.Quizzes.ToListAsync();
        }

        public async Task<Quizzes?> GetQuizAsync(int id)
        {
            return await _context.Quizzes.FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task CreateQuizAsync(Quizzes quiz)
        {
            await _context.Quizzes.AddAsync(quiz);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuizAsync(Quizzes quizToUpdate)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuizAsync(Quizzes quizToDelete)
        {
            _context.Quizzes.Remove(quizToDelete);

            await _context.SaveChangesAsync();
        }
    }
}