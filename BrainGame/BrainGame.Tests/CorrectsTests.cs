using System.Linq;
using BrainGame.Db;
using Xunit;

namespace BrainGame.Tests
{
    public class CorrectsTests
    {
        [Fact]
        public void Correct_Test()
        {
            var context = new TestsBrainGameContext();
            var correctId = 1;
            var userAnswer = "Собака";

            var correctAnswer = context.Corrects.FirstOrDefault(b => b.Id == correctId);
            
            Assert.NotNull(correctAnswer);
            Assert.Equal(correctId, correctAnswer.Id);

            Assert.Equal(userAnswer, correctAnswer.CorrectAnswer);
        }
    }
}
