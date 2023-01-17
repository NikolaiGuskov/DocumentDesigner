using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentDesigner.WebApi.ViewModels
{
	public class JuridicalPersonViewModel
	{
        public int JuridicalPersonId { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан ИНН")]
        [RegularExpression(@"\b([0-9]{10,12})\b", ErrorMessage = "Некорректный ИНН")]
        public string Inn { get; set; }

        [Required(ErrorMessage = "Не указан адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Не указан телефон")]
        public string Phone { get; set; }
    }
}
