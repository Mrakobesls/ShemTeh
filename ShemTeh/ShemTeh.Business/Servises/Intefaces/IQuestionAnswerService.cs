using ShemTeh.Business.Models;

namespace ShemTeh.Business.Servises
{
    public interface IQuestionAnswerService : IGenericService<QuestionAnswerDto>
    {
        void Add(QuestionAnswerDto entity);
        QuestionAnswerDto Read(int id);
        List<QuestionAnswerDto> ReadAll();
        void Delete(int id);
        void Update(QuestionAnswerDto entity);
    }
}
