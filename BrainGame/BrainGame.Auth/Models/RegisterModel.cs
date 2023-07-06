using BrainGame.Core.Utilities;

namespace BrainGame.Auth.Models
{
    public class RegisterModel
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public GenderType Type { get; set; }
        
        public string? Password { get; set; }
        
        public string? ConfirmPassword { get; set; }
    }
}