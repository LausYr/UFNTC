using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory.Entities.Models
{
    public class Organization
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Введите название организации")]
        [MaxLength(256, ErrorMessage = "Длина поля Email 256 символов")]
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
