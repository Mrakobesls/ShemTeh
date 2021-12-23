using System.ComponentModel.DataAnnotations;

namespace ShemTeh.App.Models.User
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Не указан Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан Имя")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указан Фамилия")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите группу")]
        public int Group { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
