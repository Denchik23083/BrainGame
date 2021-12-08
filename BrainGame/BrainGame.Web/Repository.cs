﻿using System;
using System.Collections.Generic;
using System.Linq;
using BrainGame.Db;
using BrainGame.Db.Entities;
using Microsoft.Data.SqlClient;
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

        public Register Register(Register register)
        {
            _context.Users.Add(Map(register));
            _context.SaveChanges();

            return register;
        }

        public User Login(Login login)
        {
            var user = _context.Users
                .FirstOrDefault(b =>
                    b.Email == login.Email &&
                    b.Password == login.Password);

            return user;
        }

        public User User(User user)
        {
            return user;
        }

        public User Update(User user)
        {
            var id = user.Id;
            var userToUpdate = _context.Users.FirstOrDefault(b => b.Id == id);
            return userToUpdate;
        }

        public void Remove(int id)
        {
            var userToRemove = _context.Users.FirstOrDefault(b => b.Id == id);

            if (userToRemove is null)
            {
                throw new ArgumentNullException();
            }

            _context.Users.Remove(userToRemove);
            _context.SaveChanges();
        }

        public Quizzes Quiz(Quizzes model)
        {
            var quiz = _context.Quizzes.FirstOrDefault(b => b.Id == model.Id);

            _quiz = quiz;

            return quiz;
        }

        public AnimalQuestions GetAnimalsQuestions(int id)
        {
            var questions = _context.AnimalQuestions.FirstOrDefault(q => q.Id == id);

            _id = questions?.CorrectAnswerId;

            if (questions?.Id == 1)
            {
                var points = 0;

                _quiz.Point = points;
                _context.SaveChanges();
            }

            return questions;
        }

        public PlantsQuestions GetPlantsQuestions(int id)
        {
            var questions = _context.PlantsQuestions.FirstOrDefault(q => q.Id == id);

            _id = questions?.CorrectAnswerId;

            if (questions?.Id == 1)
            {
                var points = 0;

                _quiz.Point = points;
                _context.SaveChanges();
            }

            return questions;
        }

        public MushroomsQuestions GetMushroomsQuestions(int id)
        {
            var questions = _context.MushroomsQuestions.FirstOrDefault(q => q.Id == id);

            _id = questions?.CorrectAnswerId;

            if (questions?.Id == 1)
            {
                var points = 0;

                _quiz.Point = points;
                _context.SaveChanges();
            }

            return questions;
        }

        public Correct Correct()
        {
            var correct = _context.Corrects.FirstOrDefault(a => a.Id == _id);

            return correct;
        }

        public IEnumerable<Quizzes> GetStatistics()
        {
            return _context.Quizzes;
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