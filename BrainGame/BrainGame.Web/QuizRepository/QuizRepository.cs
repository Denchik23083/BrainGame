using System.Threading.Tasks;
using BrainGame.Db;
using BrainGame.Db.Entities;
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

        public async Task<AnimalQuestions> GetAnimalsQuestions(int id)
        {
            var questions = await _context.AnimalQuestions.FirstOrDefaultAsync(q => q.Number == id);
            
            return questions;
        }

        public async Task<PlantsQuestions> GetPlantsQuestions(int id)
        {
            var questions = await _context.PlantsQuestions.FirstOrDefaultAsync(q => q.Number == id);
            
            return questions;
        }

        public async Task<MushroomsQuestions> GetMushroomsQuestions(int id)
        {
            var questions = await _context.MushroomsQuestions.FirstOrDefaultAsync(q => q.Number == id);
            
            return questions;
        }
    }
}