﻿namespace BrainGame.Db.Entities
{
    public class Password
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
    }
}