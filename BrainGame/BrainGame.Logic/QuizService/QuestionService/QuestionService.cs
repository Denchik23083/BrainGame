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

        public async Task<IEnumerable<Questions>> GetQuestions(int quizId)
        {
            var questions = await _repository.GetQuestions(quizId);

            if (questions is null)
            {
                throw new QuestionNotFoundException("Questions not found");
            }

            return questions;
        }

        public async Task CreateQuestion(Questions question)
        {
            await _repository.CreateQuestion(question);
        }

        public async Task UpdateQuestion(Questions question, int id)
        {
            var questionToUpdate = await _repository.GetQuestion(id);

            if (questionToUpdate is null)
            {
                throw new QuestionNotFoundException("Question not found");
            }

            questionToUpdate.Number = question.Number;
            questionToUpdate.Question = question.Question;
            questionToUpdate.Answers = question.Answers;
            questionToUpdate.Correct = question.Correct;

            await _repository.UpdateQuestion(questionToUpdate);
        }

        public async Task DeleteQuestion(int id)
        {
            var questionToDelete = await _repository.GetQuestion(id);

            if (questionToDelete is null)
            {
                throw new QuestionNotFoundException("Question not found");
            }

            await _repository.DeleteQuestion(questionToDelete);
        }
    }
}
