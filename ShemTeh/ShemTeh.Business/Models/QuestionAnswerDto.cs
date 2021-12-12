namespace ShemTeh.Business.Models
{
    public class QuestionAnswerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TestQuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
