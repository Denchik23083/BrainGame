using System.Threading.Tasks;
using BrainGame.Db.Entities;

namespace BrainGame.WebDb.QuizRepository
{
    public interface IQuizRepository
    {
        Task<Quizzes> GetQuiz(Quizzes model);

        Task<AnimalQuestions> GetAnimalsQuestions(int id);

        Task<PlantsQuestions> GetPlantsQuestions(int id);

        Task<MushroomsQuestions> GetMushroomsQuestions(int id);
    }
}