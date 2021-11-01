using System.ComponentModel.DataAnnotations;

namespace BrainGame.Db.Entities
{
    public class Register
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
