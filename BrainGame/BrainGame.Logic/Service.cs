using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrainGame.Db;
using BrainGame.Db.Entities;
using BrainGame.WebDb;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.Logic
{
    public class Service : IService
    {
        private readonly BrainGameContext _context;
        private readonly IRepository _repository;
        private static User _user;
        private static Quizzes _quiz;
        private static string _answers;

        public Service(IRepository repository, BrainGameContext context)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<Quizzes> Quiz(Quizzes model)
        {
            var quiz = await _repository.Quiz(model);
            
            _quiz = quiz;

            return quiz;
        }

        public async Task<AnimalQuestions> GetAnimalsQuestions(int id)
        {
            var question = await _repository.GetAnimalsQuestions(id);

            if (question is null)
            {
                throw new ArgumentNullException();
            }

            var answers = question.Answers;

            _answers = answers;

            return question;
        }

        public async Task<PlantsQuestions> GetPlantsQuestions(int id)
        {
            var question = await _repository.GetPlantsQuestions(id);

            if (question is null)
            {
                throw new ArgumentNullException();
            }

            var answers = question.Answers;

            _answers = answers;

            return question;
        }

        public async Task<MushroomsQuestions> GetMushroomsQuestions(int id)
        {
            var question = await _repository.GetMushroomsQuestions(id);

            if (question is null)
            {
                throw new ArgumentNullException();
            }

            var answers = question.Answers;

            _answers = answers;

            return question;
        }

        public async Task Correct(Correct correctAnswerUser)
        {
            var correct = await _repository.Correct();
            var correctAnswer = correct.CorrectAnswer;

            var correctUser = correctAnswerUser.CorrectAnswer;

            if (correctAnswer == correctUser)
            {
                var getPoint = await _context.Quizzes.FirstOrDefaultAsync(p => p.Id == _quiz.Id);

                if (getPoint is null)
                {
                    throw new ArgumentNullException();
                }

                getPoint.Point++;

                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Quizzes> GetStatistics()
        {
            var statistics = _repository.GetStatistics();

            if (statistics is null)
            {
                throw new ArgumentNullException();
            }

            return statistics;
        }

        public async Task<Quizzes> GetPoint()
        {
            return await _repository.GetPoint();
        }

        public IEnumerable<Answers> GetAnswers()
        {
            var array = _answers.Split(',');

            var list = new List<Answers>();

            var id = 1;

            foreach (var answer in array)
            {
                var answers = new Answers 
                {
                    Id = id++,
                    Answer = answer
                };

                list.Add(answers);
            }

            var listAnswers = list.ToArray();


            return listAnswers;
        }
    }
}