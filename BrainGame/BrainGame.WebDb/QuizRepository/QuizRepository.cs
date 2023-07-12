using BrainGame.Db;
using BrainGame.Db.Entities.Quiz;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb.QuizRepository
{
    public class QuizRepository : IQuizRepository
    {
        private readonly BrainGameContext _context;

        public QuizRepository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quizzes>> GetQuizzes()
        {
            return await _context.Quizzes.ToListAsync();
        }

        public async Task<IEnumerable<Questions>> GetQuestions(int quizId)
        {
            return await _context.Questions
                .Include(_ => _.Correct)
                .Where(_ => _.QuizId == quizId)
                .ToListAsync();
        }

        public async Task<Quizzes> GetQuiz(Quizzes model)
        {
            return (await _context.Quizzes.FirstOrDefaultAsync(b => b.Name!.Equals(model.Name)))!;
        }

        public async Task AddPoints(Quizzes quizzes)
        {
            //quizzes.Point++;

            await _context.SaveChangesAsync();
        }
    }
}