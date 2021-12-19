using ShemTeh.Business.Models;

namespace ShemTeh.Business.Servises
{
    public interface IQuestionService : IGenericService<QuestionDto>
    {
        List<QuestionDto> ReadAllByTestId(int testId);
    }
}
