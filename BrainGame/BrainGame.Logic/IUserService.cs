using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BrainGame.Db.Entities;

namespace BrainGame.Logic
{
    public interface IUserService
    {
        User Get();

        Task Update(User user);

        Task Remove();
    }
}
