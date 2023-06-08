﻿namespace BrainGame.Auth.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }
        
        public string? Password { get; set; }
        
        public string? ConfirmPassword { get; set; }
    }
}