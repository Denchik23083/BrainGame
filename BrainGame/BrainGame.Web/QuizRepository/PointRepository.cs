using System.Threading.Tasks;
using BrainGame.Db;
using BrainGame.Db.Entities.Quiz;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb.QuizRepository
{
    public class PointRepository : IPointRepository
    {
        private readonly BrainGameContext _context;

        public PointRepository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task<Quizzes> GetPoint()
        {
            var point = await _context.Quizzes.FirstOrDefaultAsync(p => p.Id == QuizRepository.Quiz.Id);

            return point;
        }

        public async Task RemovePoint()
        {
            var points = 0;

            QuizRepository.Quiz.Point = points;

            _context.Quizzes.Update(QuizRepository.Quiz);
            await _context.SaveChangesAsync();
        }
    }
}