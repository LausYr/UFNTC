namespace Directory.Entities.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }


        public int SubdivisionId { get; set; }
        public Subdivision Subdivision { get; set; }
        public int PositionWorkId { get; set; }
        public PositionWork PositionWork { get; set; }

    }
}
