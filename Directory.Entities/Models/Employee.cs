using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory.Entities.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Используйте кириллицу")]
        [MaxLength(256, ErrorMessage = "Длина поля LastName 256 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Используйте кириллицу")]
        [MaxLength(256, ErrorMessage = "Длина поля FirstName 256 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите отчество")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Используйте кириллицу")]
        [MaxLength(256, ErrorMessage = "Длина поля Patronymic 256 символов")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [RegularExpression(@"^((7|8)+([0-9]){10})$", ErrorMessage = "Неверный формат номера телефона")]
        [MaxLength(11, ErrorMessage = "Длина поля PhoneNumber 11 символов")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Введите Email")]
        [EmailAddress(ErrorMessage = "Неверный формат email")]
        [MaxLength(256, ErrorMessage = "Длина поля Email 256 символов")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите подразделение")]
        [MaxLength(256, ErrorMessage = "Длина поля Subdivision  256 символов")]
        public string Subdivision { get; set; }

        [Required(ErrorMessage = "Введите должность")]
        [MaxLength(256, ErrorMessage = "Длина поля PositionWork  256 символов")]
        public string PositionWork { get; set; }

        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
       

    }
}
