﻿namespace BrainGame.Auth.Models
{
    public class PasswordModel
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
    }
}