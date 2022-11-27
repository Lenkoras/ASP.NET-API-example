using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Workplace : Entity
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Position { get; set; }

        [DataType(DataType.Date)]
        public DateTime EmploymentDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DismissalDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
