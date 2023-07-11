using BrainGame.Db.Entities.Quiz;
using BrainGame.WebDb.QuizRepository;

namespace BrainGame.Logic.QuizService
{
    public class CorrectsService : ICorrectsService
    {
        private readonly ICorrectsRepository _repository;
        private readonly IQuizRepository _quizRepository;

        public CorrectsService(ICorrectsRepository repository, IQuizRepository quizRepository)
        {
            _repository = repository;
            _quizRepository = quizRepository;
        }

        public async Task Correct(Correct correctAnswerUser)
        {
            var correct = await _repository.Correct(QuizService.Questions.CorrectAnswerId);
            
            if (correct.CorrectAnswer!.Equals(correctAnswerUser.CorrectAnswer))
            {
                var quiz = await _quizRepository.GetQuiz(QuizService.Quiz);

                await _quizRepository.AddPoints(quiz);
            }
        }
    }
}