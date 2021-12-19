using ShemTeh.Business.Models;

namespace ShemTeh.Business.Servises
{
    public interface IQuestionAnswerService : IGenericService<QuestionAnswerDto>
    {
        List<QuestionAnswerDto> ReadAllByQuestionId(int questionId);
    }
}
