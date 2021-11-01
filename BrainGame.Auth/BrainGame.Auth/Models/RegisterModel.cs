﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrainGame.Auth.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }

        public string Login { get; set; }
        
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }
    }
}
