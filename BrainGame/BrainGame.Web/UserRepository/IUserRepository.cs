using BrainGame.Db.Entities.Auth;

namespace BrainGame.WebDb.UserRepository
{
    public interface IUserRepository
    {
        Task<User> GetUser(string userEmail);

        Task<IEnumerable<Gender>> GetGenders();

        Task EditUser(User userToUpdate);

        Task EditPassword(User userToUpdate);

        Task RemoveUser(User userToRemove);        
    }
}