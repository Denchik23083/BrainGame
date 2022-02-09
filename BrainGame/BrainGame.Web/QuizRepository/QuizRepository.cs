using System.Threading.Tasks;
using BrainGame.Db;
using BrainGame.Db.Entities.Quiz;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb.QuizRepository
{
    public class QuizRepository : IQuizRepository
    {
        private readonly BrainGameContext _context;
        public static Quizzes Quiz;

        public QuizRepository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task<Quizzes> GetQuiz(Quizzes model)
        {
            var quiz = await _context.Quizzes.FirstOrDefaultAsync(b => b.Name == model.Name);
            
            Quiz = quiz;

            return quiz;
        }

        public async Task<Questions> GetQuestions(int id)
        {
            var questions = await _context.Questions.FirstOrDefaultAsync(q => q.Number == id && q.QuizId == Quiz.Id);
            
            return questions;
        }
    }
}