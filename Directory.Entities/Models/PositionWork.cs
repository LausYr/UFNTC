using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Directory.Entities.Models
{
    public class PositionWork
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название должности")]
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
