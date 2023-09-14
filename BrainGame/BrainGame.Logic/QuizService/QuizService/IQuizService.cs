﻿using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService.QuizService
{
    public interface IQuizService
    {
        Task<IEnumerable<Quizzes>> GetQuizzesAsync();

        Task CreateQuizAsync(Quizzes quiz);

        Task UpdateQuizAsync(Quizzes quiz, int id);

        Task DeleteQuizAsync(int id);
    }
}