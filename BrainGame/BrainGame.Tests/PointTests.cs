using System.Linq;
using BrainGame.Db;
using Xunit;

namespace BrainGame.Tests
{
    public class PointTests
    {
        [Fact]
        public void Get_Test()
        {
            var context = new TestsBrainGameContext();
            var quizId = 2;
            var points = 0;

            var quiz = context.Quizzes.FirstOrDefault(b => b.Id == quizId);

            Assert.NotNull(quiz);
            Assert.Equal(quizId, quiz.Id);

            Assert.Equal(points, quiz.Point);
        }

        [Fact]
        public void Remove_Test()
        {
            var context = new TestsBrainGameContext();
            var quizId = 2;
            var points = 0;

            var quiz = context.Quizzes.FirstOrDefault(b => b.Id == quizId);

            Assert.NotNull(quiz);
            Assert.Equal(quizId, quiz.Id);

            quiz.Point = points;

            context.SaveChanges();

            var quizAfterRemove = context.Quizzes.FirstOrDefault(b => b.Id == quizId);

            Assert.NotNull(quizAfterRemove);

            Assert.Equal(points, quizAfterRemove.Point);
        }
    }
}
