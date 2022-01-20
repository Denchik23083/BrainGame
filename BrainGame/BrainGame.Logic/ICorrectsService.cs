using System.Collections.Generic;
using System.Threading.Tasks;
using BrainGame.Db.Entities;

namespace BrainGame.Logic
{
    public interface ICorrectsService
    {
        Task Correct(Correct correctAnswerUser);
    }
}