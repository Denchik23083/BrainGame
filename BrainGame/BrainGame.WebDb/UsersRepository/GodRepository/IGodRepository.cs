using BrainGame.Db.Entities.Auth;

namespace BrainGame.WebDb.UsersRepository.GodRepository
{
    public interface IGodRepository
    {
        Task UserToAdminAsync(User userToAdmin);

        Task AdminToUserAsync(User adminToUser);
    }
}