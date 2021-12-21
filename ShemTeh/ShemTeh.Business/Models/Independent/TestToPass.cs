namespace ShemTeh.Business.Models.Independent
{
    public class TestToPass
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }

    public class Question
    {
        public int QuestionId { get; set; }
        public string Name { get; set; }
        public List<QuestionAnswer> QuestionAnswers { get; set; }
    }

    public class QuestionAnswer
    {
        public int QuestionAnswerId { get; set; }
        public string Name { get; set; }
        public bool IsCorrect { get; set; }
    }
}
