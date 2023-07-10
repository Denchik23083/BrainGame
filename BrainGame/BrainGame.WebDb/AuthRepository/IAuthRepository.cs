﻿using BrainGame.Db.Entities.Auth;

namespace BrainGame.WebDb.AuthRepository
{
    public interface IAuthRepository
    {
        Task Register(User register);

        Task<User> Login(User login);

        Task<User> RefreshLogin(RefreshToken refresh);

        Task CreateRefreshToken(Guid refreshToken, User user);

        Task UpdateRefreshToken(Guid refreshToken, User user);
    }
}