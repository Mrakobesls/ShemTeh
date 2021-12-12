using ShemTeh.Business.Models;
using ShemTeh.Data.UnitOfWork.Interfaces;

namespace ShemTeh.Business.Servises.Intefaces
{
    public class QuestionService : IQuestionService
    {
        private IUnitOfWork _uow;
        public QuestionService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public void Add(QuestionAnswerDto entity)
        {
            throw new NotImplementedException();
        }

        public void Add(QuestionDto entity)
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

        public void Update(QuestionDto entity)
        {
            throw new NotImplementedException();
        }

        QuestionDto IQuestionService.Read(int id)
        {
            throw new NotImplementedException();
        }

        QuestionDto IGenericService<QuestionDto>.Read(int id)
        {
            throw new NotImplementedException();
        }

        List<QuestionDto> IQuestionService.ReadAll()
        {
            throw new NotImplementedException();
        }

        List<QuestionDto> IGenericService<QuestionDto>.ReadAll()
        {
            throw new NotImplementedException();
        }
    }
}
