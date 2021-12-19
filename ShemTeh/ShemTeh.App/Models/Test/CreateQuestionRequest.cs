using System.ComponentModel.DataAnnotations;

namespace ShemTeh.App.Models.Test
{
    public class CreateQuestionRequest
    {
        [Required(ErrorMessage = "Не указано название")]
        public string Name { get; set; }
        public int TestId { get; set; }
    }
}
