using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directory.Entities.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Используйте кириллицу")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Используйте кириллицу")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите отчество")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Используйте кириллицу")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [RegularExpression(@"^((7|8)+([0-9]){10})$", ErrorMessage = "Неверный формат номера телефона")]
        [MaxLength(11, ErrorMessage = "Длина поля PhoneNumber 11 символов")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Введите Email")]
        [EmailAddress(ErrorMessage = "Неверный формат email")]
        public string Email { get; set; }


        public int? OrganizationId { get; set; }


        public int? SubdivisionId { get; set; }


        public int? PositionWorkId { get; set; }


        [ForeignKey("OrganizationId")]
        public PositionWork Organization { get; set; }

        [ForeignKey("SubdivisionId")]
        public Subdivision Subdivision { get; set; }

        [ForeignKey("PositionWorkId")]
        public PositionWork PositionWork { get; set; }

    }
}
