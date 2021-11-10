using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directory.Entities.Models
{
    public class Subdivision
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите название подразделения")]
        public string Name{ get; set; }

        public List<Employee> Employees { get; set; }


        public int? OrganizationId { get; set; }

        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }
    }
}
