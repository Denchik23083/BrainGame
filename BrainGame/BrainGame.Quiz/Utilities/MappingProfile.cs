using AutoMapper;
using BrainGame.Db.Entities.Quiz;
using BrainGame.Quiz.Models;

namespace BrainGame.Quiz.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<QuizzesWriteModel, Quizzes>();
            CreateMap<Quizzes, QuizzesReadModel>();

            CreateMap<QuestionsWriteModel, Questions>();
            CreateMap<Questions, QuestionsReadModel>();
        }
    }
}
