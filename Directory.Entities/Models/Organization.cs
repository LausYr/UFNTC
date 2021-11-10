using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Directory.Entities.Models
{
    public class Organization
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название организации")]
        public string Name { get; set; }

        public List<Subdivision> Subdivisions { get; set; }
    }
}
