﻿using System.Threading.Tasks;
using BrainGame.Db;
using BrainGame.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb.QuizRepository
{
    public class QuizRepository : IQuizRepository
    {
        private readonly BrainGameContext _context;
        private static Quizzes _quiz;

        public QuizRepository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task<Quizzes> Quiz(Quizzes model)
        {
            var quiz = await _context.Quizzes.FirstOrDefaultAsync(b => b.Name == model.Name);
            
            _quiz = quiz;

            return quiz;
        }

        public async Task<AnimalQuestions> GetAnimalsQuestions(int id)
        {
            var questions = await _context.AnimalQuestions.FirstOrDefaultAsync(q => q.Id == id);
            
            return questions;
        }

        public async Task<PlantsQuestions> GetPlantsQuestions(int id)
        {
            var questions = await _context.PlantsQuestions.FirstOrDefaultAsync(q => q.Id == id);
            
            return questions;
        }

        public async Task<MushroomsQuestions> GetMushroomsQuestions(int id)
        {
            var questions = await _context.MushroomsQuestions.FirstOrDefaultAsync(q => q.Id == id);
            
            return questions;
        }

        public async Task<Quizzes> GetPoint()
        {
            var point = await _context.Quizzes.FirstOrDefaultAsync(p => p.Id == _quiz.Id);

            return point;
        }

        public async Task RemovePoint()
        {
            var points = 0;

            _quiz.Point = points;

            _context.Quizzes.Update(_quiz);
            await _context.SaveChangesAsync();
        }
    }
}