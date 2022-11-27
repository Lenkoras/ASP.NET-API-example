using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class WorkplaceFull
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Position { get; set; }

        [DataType(DataType.Date)]
        public DateTime EmploymentDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DismissalDate { get; set; }
    }
}
