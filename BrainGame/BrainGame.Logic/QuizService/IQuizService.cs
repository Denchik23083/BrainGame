using System.Threading.Tasks;
using BrainGame.Db.Entities;

namespace BrainGame.Logic.QuizService
{
    public interface IQuizService
    {
        Task<Quizzes> GetQuiz(Quizzes model);

        Task<AnimalQuestions> GetAnimalsQuestions(int id);

        Task<PlantsQuestions> GetPlantsQuestions(int id);

        Task<MushroomsQuestions> GetMushroomsQuestions(int id);
    }
}