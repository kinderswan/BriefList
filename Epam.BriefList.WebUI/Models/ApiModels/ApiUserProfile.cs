using System;
using System.ComponentModel.DataAnnotations;

namespace Epam.BriefList.WebUI.Models.ApiModels
{
    public class ApiUserProfile
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Введите имя")]
        [RegularExpression("[a-zA-Z0-9]{2,12}", ErrorMessage = "Имя должно содержать буквы и цифры от 2 до 12 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [RegularExpression("[.\\-_a-z0-9]{6,18}", ErrorMessage = "Пароль должен содержать символы .\\-_ буквы и цифры от 2 до 12 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public DateTime TimeRegister { get; set; }
    }
}
