using Microsoft.AspNetCore.Mvc;
using ShemTeh.Business.Models;

namespace ShemTeh.App.Models.Test
{
    public class EditQuestionRequest
    {
        public QuestionDto Question { get; set; }
        public List<QuestionAnswerDto> Answers { get; set; }
    }
}
