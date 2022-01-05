using System.Threading.Tasks;
using BrainGame.Db;
using BrainGame.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb
{
    public class AnswersRepository : IAnswersRepository
    {
        private readonly BrainGameContext _context;

        public AnswersRepository(BrainGameContext context)
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