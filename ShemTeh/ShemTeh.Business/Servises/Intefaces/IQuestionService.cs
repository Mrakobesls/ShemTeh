using ShemTeh.Business.Models;

namespace ShemTeh.Business.Servises
{
    public interface IQuestionService : IGenericService<QuestionDto>
    {
        void Add(QuestionDto entity);
        QuestionDto Read(int id);
        List<QuestionDto> ReadAll();
        void Delete(int id);
        void Update(QuestionDto entity);
    }
}
