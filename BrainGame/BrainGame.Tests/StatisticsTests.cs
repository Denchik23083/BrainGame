using System.Collections.Generic;
using BrainGame.Db.Entities.Quiz;
using Xunit;

namespace BrainGame.Tests
{
    public class StatisticsTests
    {
        [Fact]
        public void Get_Test()
        {
            var list = new List<Quizzes>
            {
                new()
                {
                    Id = 1,
                    Name = "Hallo",
                    Point = 2
                },
                new()
                {
                    Id = 2,
                    Name = "Foo",
                    Point = 1
                }
            };

            Assert.NotNull(list);
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void Clear_Test()
        {
            var list = new List<Quizzes>
            {
                new()
                {
                    Id = 1,
                    Name = "Too",
                    Point = 0
                },
            };

            Assert.NotNull(list);
            Assert.Single(list);

            list.Clear();

            Assert.NotNull(list);
            Assert.Empty(list);
        }
    }
}
