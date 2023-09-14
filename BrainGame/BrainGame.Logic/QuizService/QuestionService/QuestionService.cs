using BrainGame.Core.Exceptions;
using BrainGame.Db.Entities.Quiz;
using BrainGame.WebDb.QuizRepository.QuestionRepository;

namespace BrainGame.Logic.QuizService.QuestionService
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;

        public QuestionService(IQuestionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Questions>> GetAllQuestionsAsync(int quizId)
        {
            var questions = await _repository.GetAllQuestionsAsync(quizId);

            if (questions is null)
            {
                throw new QuestionNotFoundException("Questions not found");
            }

            return questions;
        }

        public async Task CreateQuestionAsync(Questions question)
        {
            await _repository.CreateQuestionAsync(question);
        }

        public async Task UpdateQuestionAsync(Questions question, int id)
        {
            var questionToUpdate = await _repository.GetQuestionAsync(id);

            if (questionToUpdate is null)
            {
                throw new QuestionNotFoundException("Question not found");
            }

            questionToUpdate.Number = question.Number;
            questionToUpdate.Question = question.Question;
            questionToUpdate.Answers = question.Answers;
            questionToUpdate.Correct = question.Correct;

            await _repository.UpdateQuestionAsync(questionToUpdate);
        }

        public async Task DeleteQuestionAsync(int id)
        {
            var questionToDelete = await _repository.GetQuestionAsync(id);

            if (questionToDelete is null)
            {
                throw new QuestionNotFoundException("Question not found");
            }

            await _repository.DeleteQuestionAsync(questionToDelete);
        }
    }
}
