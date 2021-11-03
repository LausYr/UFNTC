using System.Collections.Generic;

namespace Directory.Entities.Models
{
    public class Subdivision
    {
        public int Id { get; set; }

        public string Name{ get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
