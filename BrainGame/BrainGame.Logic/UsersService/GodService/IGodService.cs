namespace BrainGame.Logic.UsersService.GodService
{
    public interface IGodService
    {
        Task UserToAdminAsync(int id);
        
        Task AdminToUserAsync(int id);
    }
}