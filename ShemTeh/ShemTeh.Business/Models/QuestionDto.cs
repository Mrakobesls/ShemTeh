using ShemTeh.Data.Models;

namespace ShemTeh.Business.Models
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TestId { get; set; }
        public int TypeId { get; set; }

        public static implicit operator QuestionDto(Question question)
        {
            return question is null
                ? null
                : new QuestionDto
                {
                    Id = question.Id,
                    Name = question.Name,
                    TestId = question.TestId,
                    TypeId = question.TypeId
                };
        }

        public static implicit operator Question(QuestionDto question)
        {
            return question is null
                ? null
                : new Question
                {
                    Id = question.Id,
                    Name = question.Name,
                    TestId = question.TestId,
                    TypeId = question.TypeId
                };
        }
    }
}
