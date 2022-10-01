using System.Linq;
using BrainGame.Db;
using BrainGame.Db.Entities.Quiz;
using Xunit;

namespace BrainGame.Tests
{
    public class QuizTests
    {
        [Fact]
        public void Get_Test()
        {
            var context = new TestsBrainGameContext();
            var name = "Animals";

            var quiz = context.Quizzes.FirstOrDefault(b => b.Name.Equals(name));

            Assert.NotNull(quiz);
            Assert.Equal(name, quiz.Name);
        }

        [Fact]
        public void Get_Questions_Test()
        {
            var context = new TestsBrainGameContext();
            var number = 1;
            var quizId = 2;

            var question = context.Questions.FirstOrDefault(b => b.Number == number && b.QuizId == quizId);

            Assert.NotNull(question);
            Assert.Equal(number, question.Number);
            Assert.Equal(quizId, question.QuizId);
        }

        [Fact]
        public void Add_Point_Test()
        {
            var context = new TestsBrainGameContext();
            var expectedPoint = 1;

            var newQuiz = new Quizzes
            {
                Name = "Hallo",
                Point = 0
            };

            context.Quizzes.Add(newQuiz);
            context.SaveChanges();

            var quiz = context.Quizzes.FirstOrDefault(b => b.Name.Equals(newQuiz.Name));
            Assert.NotNull(quiz);

            quiz.Point++;

            context.SaveChanges();

            var quizAfterAddPoint = context.Quizzes.FirstOrDefault(b => b.Name.Equals(quiz.Name));

            Assert.NotNull(quizAfterAddPoint);
            Assert.Equal(expectedPoint, quizAfterAddPoint.Point);

            var quizRemoveAddPoint = context.Quizzes.FirstOrDefault(b => b.Name.Equals(newQuiz.Name));
            Assert.NotNull(quizRemoveAddPoint);

            context.Quizzes.Remove(quizRemoveAddPoint);
            context.SaveChanges();

            var quizAfterRemoveAddPoint = context.Quizzes.FirstOrDefault(b => b.Name.Equals(newQuiz.Name));
            Assert.Null(quizAfterRemoveAddPoint);
        }
    }
}
