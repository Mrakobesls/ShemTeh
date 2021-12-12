using ShemTeh.Business.Models;
using ShemTeh.Data.UnitOfWork.Interfaces;

namespace ShemTeh.Business.Servises.Intefaces
{
    public class QuestionAnswerService : IQuestionAnswerService
    {
        private IUnitOfWork _uow;
        public QuestionAnswerService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public void Add(QuestionAnswerDto entity)
        {
            throw new NotImplementedException();
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

        public void Update(QuestionAnswerDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
