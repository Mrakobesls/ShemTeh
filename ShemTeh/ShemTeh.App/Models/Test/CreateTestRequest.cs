using System.ComponentModel.DataAnnotations;

namespace ShemTeh.App.Models.Test
{
    public class CreateTestRequest
    {
        [Required(ErrorMessage = "Не указано название")]
        public string Name { get; set; }
    }
}
