using BrainGame.Db.Entities.Auth;

namespace BrainGame.WebDb.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers(int roleId);

        Task<IEnumerable<Gender>> GetGenders();

        Task<User> GetUser(int id);

        Task EditUser(User userToUpdate);

        Task EditPassword(User userToUpdate);

        Task RemoveUser(User userToRemove);        
    }
}