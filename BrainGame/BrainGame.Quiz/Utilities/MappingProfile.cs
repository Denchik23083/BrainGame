using AutoMapper;
using BrainGame.Db.Entities.Quiz;
using BrainGame.Quiz.Models;

namespace BrainGame.Quiz.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<QuizWriteModel, Quizzes>();
            CreateMap<Quizzes, QuizReadModel>();

            CreateMap<QuestionWriteModel, Questions>();
            CreateMap<Questions, QuestionReadModel>();

            CreateMap<CorrectWriteModel, Correct>();

            CreateMap<Statistics, StatisticsReadModel>();
        }
    }
}
