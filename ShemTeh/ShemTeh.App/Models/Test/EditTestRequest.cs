using ShemTeh.Business.Models;

namespace ShemTeh.App.Models.Test
{
    public class EditTestRequest
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        public TestDto Test { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}
