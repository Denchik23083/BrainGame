namespace BrainGame.Logic.UsersService.GodService
{
    public interface IGodService
    {
        Task UserToAdmin(int id);
        
        Task AdminToUser(int id);
    }
}