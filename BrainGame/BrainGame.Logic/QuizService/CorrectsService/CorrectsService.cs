using BrainGame.Db.Entities.Quiz;
using BrainGame.WebDb.QuizRepository.CorrectsRepository;
using BrainGame.WebDb.QuizRepository.QuizzesRepository;

namespace BrainGame.Logic.QuizService.CorrectsService
{
    public class CorrectsService : ICorrectsService
    {
        private readonly ICorrectsRepository _repository;
        private readonly IQuizzesRepository _quizRepository;

        public CorrectsService(ICorrectsRepository repository, IQuizzesRepository quizRepository)
        {
            _repository = repository;
            _quizRepository = quizRepository;
        }

        public async Task Correct(Correct correctAnswerUser)
        {
            var correct = await _repository.Correct(correctAnswerUser.QuestionId);

            if (correct.CorrectAnswer!.Equals(correctAnswerUser.CorrectAnswer))
            {
                //var quiz = await _quizRepository.GetQuiz(QuizService.Quiz);

                //await _quizRepository.AddPoints(quiz);
            }
        }
    }
}