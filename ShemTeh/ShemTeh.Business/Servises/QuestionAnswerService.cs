using ShemTeh.Business.Models;
using ShemTeh.Data.Models;
using ShemTeh.Data.UnitOfWork;

namespace ShemTeh.Business.Servises
{
    public class QuestionAnswerService : IQuestionAnswerService
    {
        private IUnitOfWork _uow;
        public QuestionAnswerService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public int Add(QuestionAnswerDto entity)
        {
            QuestionAnswer entityDb = entity;
            _uow.QuestionAnswers.Create(entityDb);

            _uow.SaveChanges();

            return entityDb.Id;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public QuestionAnswerDto Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<QuestionAnswerDto> ReadAll()
        {
            throw new NotImplementedException();
        }

        public List<QuestionAnswerDto> ReadAllByQuestionId(int questionId)
        {
            return _uow.QuestionAnswers.ReadAll()
                .Where(x => x.QuestionId == questionId)
                .Select(qa => (QuestionAnswerDto)qa).ToList(); ;
        }

        public void Update(QuestionAnswerDto entity)
        {
            _uow.QuestionAnswers.Update(entity);

            _uow.SaveChanges();
        }
    }
}
