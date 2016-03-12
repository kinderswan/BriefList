using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.BriefList.WebUI.Models
{
    public class PasswordModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [RegularExpression("[.\\-_a-z0-9]{6,18}", ErrorMessage = "Пароль должен содержать символы .\\-_ буквы и цифры от 2 до 12 символов")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [RegularExpression("[.\\-_a-z0-9]{6,18}", ErrorMessage = "Пароль должен содержать символы .\\-_ буквы и цифры от 2 до 12 символов")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}