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
            _quizRepository = quizRepository;
            _repository = repository;
        }

        public async Task Correct(Correct correctAnswerUser)
        {
            var correct = await _repository.Correct(QuizService.Questions.CorrectAnswerId);
            
            if (correct.CorrectAnswer!.Equals(correctAnswerUser.CorrectAnswer))
            {
                var quiz = await _quizRepository.GetQuiz(QuizService.Quiz);

                if (quiz is null)
                {
                    throw new ArgumentNullException();
                }

                await _quizRepository.AddPoints(quiz);
            }
        }
    }
}