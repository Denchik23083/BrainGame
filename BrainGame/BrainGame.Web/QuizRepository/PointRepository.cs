using System.Threading.Tasks;
using BrainGame.Db;
using BrainGame.Db.Entities;
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
            var point = await _context.Quizzes.FirstOrDefaultAsync(p => p.Id == QuizRepository._quiz.Id);

            return point;
        }

        public async Task RemovePoint()
        {
            var points = 0;

            QuizRepository._quiz.Point = points;

            _context.Quizzes.Update(QuizRepository._quiz);
            await _context.SaveChangesAsync();
        }
    }
}