﻿using System;
using System.Collections.Generic;
using System.Text;
using BrainGame.Db.Entities;

namespace BrainGame.Logic
{
    public interface IService
    {
        Register Register(Register register);
    }
}
