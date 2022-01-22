using System.Threading.Tasks;
using BrainGame.Db;
using BrainGame.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb.QuizRepository
{
    public class CorrectsRepository : ICorrectsRepository
    {
        private readonly BrainGameContext _context;

        public CorrectsRepository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task<Correct> Correct(int id)
        {
            var correct = await _context.Corrects.FirstOrDefaultAsync(a => a.Id == id);

            return correct;
        }
    }
}