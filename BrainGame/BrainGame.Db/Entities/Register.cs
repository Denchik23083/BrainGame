﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BrainGame.Db.Entities
{
    public class Register
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}