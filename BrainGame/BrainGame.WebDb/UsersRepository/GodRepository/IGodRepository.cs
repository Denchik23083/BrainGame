using BrainGame.Db.Entities.Auth;

namespace BrainGame.WebDb.UsersRepository.GodRepository
{
    public interface IGodRepository
    {
        Task UserToAdmin(User userToAdmin);

        Task AdminToUser(User adminToUser);
    }
}