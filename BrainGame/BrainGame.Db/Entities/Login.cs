﻿using System.ComponentModel.DataAnnotations;

namespace BrainGame.Db.Entities
{
    public class Login
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}