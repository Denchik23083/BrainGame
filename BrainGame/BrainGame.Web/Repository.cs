using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainGame.Db;
using BrainGame.Db.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BrainGame.WebDb
{
    public class Repository : IRepository
    {
        private readonly BrainGameContext _context;
        private static int? _id;
        private static Quizzes _quiz;

        public Repository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task<Register> Register(Register register)
        {
            await _context.Users.AddAsync(Map(register));
            await _context.SaveChangesAsync();

            return register;
        }

        public async Task<User> Login(Login login)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(b =>
                    b.Email == login.Email &&
                    b.Password == login.Password);

            return user;
        }

        public User User(User user)
        {
            return user;
        }

        public async Task<User> Update(User user)
        {
            var id = user.Id;
            var userToUpdate = await _context.Users.FirstOrDefaultAsync(b => b.Id == id);
            return userToUpdate;
        }

        public async Task Remove(int id)
        {
            var userToRemove = await _context.Users.FirstOrDefaultAsync(b => b.Id == id);

            if (userToRemove is null)
            {
                throw new ArgumentNullException();
            }

            _context.Users.Remove(userToRemove);
            await _context.SaveChangesAsync();
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

            _id = questions?.CorrectAnswerId;

            if (questions?.Id == 1)
            {
                var points = 0;

                _quiz.Point = points;
                await _context.SaveChangesAsync();
            }

            return questions;
        }

        public async Task<PlantsQuestions> GetPlantsQuestions(int id)
        {
            var questions = await _context.PlantsQuestions.FirstOrDefaultAsync(q => q.Id == id);

            _id = questions?.CorrectAnswerId;

            if (questions?.Id == 1)
            {
                var points = 0;

                _quiz.Point = points;
                await _context.SaveChangesAsync();
            }

            return questions;
        }

        public async Task<MushroomsQuestions> GetMushroomsQuestions(int id)
        {
            var questions = await _context.MushroomsQuestions.FirstOrDefaultAsync(q => q.Id == id);

            _id = questions?.CorrectAnswerId;

            if (questions?.Id == 1)
            {
                var points = 0;

                _quiz.Point = points;
                await _context.SaveChangesAsync();
            }

            return questions;
        }

        public async Task<Correct> Correct()
        {
            var correct = await _context.Corrects.FirstOrDefaultAsync(a => a.Id == _id);

            return correct;
        }

        public IEnumerable<Quizzes> GetStatistics()
        {
            return _context.Quizzes;
        }

        public async Task<Quizzes> GetPoint()
        {
            var point = await _context.Quizzes.FirstOrDefaultAsync(p => p.Id == _quiz.Id);

            return point;
        }

        private User Map(Register model)
        {
            return new User
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
            };
        }
    }
}