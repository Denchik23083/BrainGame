using System.Collections.Generic;
using System.Threading.Tasks;
using BrainGame.Db.Entities;

namespace BrainGame.WebDb
{
    public interface IRepository
    {

        Task<Quizzes> Quiz(Quizzes model);

        Task<AnimalQuestions> GetAnimalsQuestions(int id);

        Task<PlantsQuestions> GetPlantsQuestions(int id);

        Task<MushroomsQuestions> GetMushroomsQuestions(int id);

        Task<Correct> Correct();

        IEnumerable<Quizzes> GetStatistics();

        Task<Quizzes> GetPoint();
    }
}
