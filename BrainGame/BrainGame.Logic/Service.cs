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
        private static Quiz _quiz;

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

        public Questions GetQuestion(int id)
        {
            var question = _repository.GetQuestion(id);

            if (question is null)
            {
                throw new ArgumentNullException();
            }

            var quiz = _context.Quiz.FirstOrDefault(b => b.Id == question.QuizId);

            var answers = question.Answers;
            var array = answers.Split(',');
            _array = array;
            _quiz = quiz;

            return question;
        }

        public string Correct(string answer)
        {
            var correct = _repository.Correct();
            var correctAnswer = correct.CorrectAnswer;

            if (answer == correctAnswer)
            {
                var getPoint = _context.Quiz.FirstOrDefault(p => p.Id == _quiz.Id);

                if (getPoint is null)
                {
                    throw new ArgumentNullException();
                }

                getPoint.Point++;

                _context.SaveChanges();
            }

            return correctAnswer;
        }
    }
}
