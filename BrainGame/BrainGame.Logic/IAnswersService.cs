using System.Collections.Generic;
using System.Threading.Tasks;
using BrainGame.Db.Entities;

namespace BrainGame.Logic
{
    public interface IAnswersService
    {
        Task Correct(Correct correctAnswerUser);

        IEnumerable<Answers> GetAnswers();
    }
}
