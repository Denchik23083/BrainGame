using System;
using System.Linq;
using BrainGame.Db;
using BrainGame.Db.Entities;
using BrainGame.WebDb;

namespace BrainGame.Logic
{
    public class Service : IService
    {
        private readonly BrainGameContext _context;
        private readonly IRepository _repository;
        public static User _user;
        private static string[] _array;
        private static Quizzes _quiz;

        public Service(IRepository repository, BrainGameContext context)
        {
            _context = context;
            _repository = repository;
        }

        public Register Register(Register register)
        {
            if (register.Password != register.ConfirmPassword)
            {
                throw new ArgumentException();
            }

            return _repository.Register(register);
        }

        public User Login(Login login)
        {
            var user = _repository.Login(login);

            if (user is null)
            {
                return null;
            }

            _user = user;

            return user;
        }

        public User User()
        {
            var user = _user;

            _repository.User(user);

            return user;
        }

        public void Update(User user)
        {
            var userToUpdate = _repository.Update(_user);

            if (userToUpdate is null)
            {
                throw new ArgumentNullException();
            }

            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;
            userToUpdate.Password = user.Password;

            _context.SaveChanges();
        }

        public void Remove()
        {
            var id = _user.Id;
            _repository.Remove(id);
        }

        public Quizzes Quiz(Quizzes model)
        {
            var quiz = _repository.Quiz(model);
            
            _quiz = quiz;

            return quiz;
        }

        public AnimalQuestions GetAnimalsQuestions(int id)
        {
            var question = _repository.GetAnimalsQuestions(id);

            if (question is null)
            {
                throw new ArgumentNullException();
            }

            var answers = question.Answers;
            var array = answers.Split(',');
            _array = array;

            return question;
        }

        public PlantsQuestions GetPlantsQuestions(int id)
        {
            var question = _repository.GetPlantsQuestions(id);

            if (question is null)
            {
                throw new ArgumentNullException();
            }

            var answers = question.Answers;
            var array = answers.Split(',');
            _array = array;

            return question;
        }

        public MushroomsQuestions GetMushroomsQuestions(int id)
        {
            var question = _repository.GetMushroomsQuestions(id);

            if (question is null)
            {
                throw new ArgumentNullException();
            }

            var answers = question.Answers;
            var array = answers.Split(',');
            _array = array;

            return question;
        }

        public void Correct(int answerId)
        {
            var correct = _repository.Correct();
            var correctAnswer = correct.Id;

            if (answerId == correctAnswer)
            {
                var getPoint = _context.Quizzes.FirstOrDefault(p => p.Id == _quiz.Id);

                if (getPoint is null)
                {
                    throw new ArgumentNullException();
                }

                getPoint.Point++;

                _context.SaveChanges();
            }
        }
    }
}