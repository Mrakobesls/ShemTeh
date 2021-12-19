using ShemTeh.Data.Models;

namespace ShemTeh.Business.Models
{
    public class QuestionAnswerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }

        public static implicit operator QuestionAnswerDto(QuestionAnswer questionAnswer)
        {
            return questionAnswer is null
                ? null
                : new QuestionAnswerDto
                {
                    Id = questionAnswer.Id,
                    Name = questionAnswer.Name,
                    QuestionId = questionAnswer.QuestionId,
                    IsCorrect = questionAnswer.IsCorrect,
                };
        }

        public static implicit operator QuestionAnswer(QuestionAnswerDto questionAnswer)
        {
            return questionAnswer is null
                ? null
                : new QuestionAnswer
                {
                    Id = questionAnswer.Id,
                    Name = questionAnswer.Name,
                    QuestionId = questionAnswer.QuestionId,
                    IsCorrect = questionAnswer.IsCorrect,
                };
        }
    }
}
