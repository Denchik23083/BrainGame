namespace BrainGame.Users.Models
{
    public class PasswordWriteModel
    {
        public string? OldPassword { get; set; }

        public string? NewPassword { get; set; }

        public string? ConfirmPassword { get; set; }
    }
}