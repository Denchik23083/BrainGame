using BrainGame.Db.Entities.Quiz;
using BrainGame.WebDb.QuizRepository.CorrectRepository;
using BrainGame.WebDb.QuizRepository.QuizRepository;

namespace BrainGame.Logic.QuizService.CorrectService
{
    public class CorrectService : ICorrectService
    {
        private readonly ICorrectRepository _repository;
        private readonly IQuizRepository _quizRepository;

        public CorrectService(ICorrectRepository repository, IQuizRepository quizRepository)
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