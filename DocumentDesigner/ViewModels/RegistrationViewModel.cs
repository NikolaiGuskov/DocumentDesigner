using System.ComponentModel.DataAnnotations;

namespace DocumentDesigner.WebApi.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Введите свое имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите свою фамилию")]
        public string Surname { get; set; }

        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли несовпадают")]
        public string ConfirmPassword { get; set; }
    }
}
