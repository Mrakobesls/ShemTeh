using Microsoft.EntityFrameworkCore;
using ShemTeh.Business.Models;
using ShemTeh.Data.Models;
using ShemTeh.Data.UnitOfWork;

namespace ShemTeh.Business.Servises
{
    public class QuestionService : IQuestionService
    {
        private IUnitOfWork _uow;
        public QuestionService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public int Add(QuestionDto entity)
        {
            Question entityDb = entity;
            entityDb.TypeId = 2;
            _uow.Questions.Create(entityDb);

            _uow.SaveChanges();

            return entityDb.Id;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public QuestionDto Read(int id)
        {
            return _uow.Questions.Read(id);
        }

        public List<QuestionDto> ReadAll()
        {
            return (List<QuestionDto>)_uow.Questions.ReadAll();
        }

        public void Update(QuestionDto entity)
        {
            _uow.Questions.Update(entity);

            _uow.SaveChanges();
        }

        public List<QuestionDto> ReadAllByTestId(int testId)
        {
            return _uow.Questions.ReadAll()
                .Where(x => x.TestId == testId)
                .Select(q => (QuestionDto)q).ToList();
        }

        public int GetCorrectAnswersCount(int questionId)
        {
            return _uow.GetContext().Questions.Include(q => q.QuestionAnswers).Where(q=>q.Id == questionId)
                .Select(q => q.QuestionAnswers.Sum(qa => qa.IsCorrect ? 1 : 0)).FirstOrDefault();
        }

        public int GetIncorrectAnswersCount(int questionId)
        {
            return _uow.GetContext().Questions.Include(q => q.QuestionAnswers).Where(q=>q.Id == questionId)
                .Select(q => q.QuestionAnswers.Sum(qa => qa.IsCorrect ? 0 : 1)).FirstOrDefault();
        }
    }
}
