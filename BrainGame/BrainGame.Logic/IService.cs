using System.Collections.Generic;
using System.Threading.Tasks;
using BrainGame.Db.Entities;

namespace BrainGame.Logic
{
    public interface IService
    {
        Task<Quizzes> Quiz(Quizzes model);

        Task<AnimalQuestions> GetAnimalsQuestions(int id);

        Task<PlantsQuestions> GetPlantsQuestions(int id);

        Task<MushroomsQuestions> GetMushroomsQuestions(int id);

        Task Correct(Correct correctAnswerUser);

        IEnumerable<Quizzes> GetStatistics();

        IEnumerable<Answers> GetAnswers();

        Task<Quizzes> GetPoint();
    }
}
