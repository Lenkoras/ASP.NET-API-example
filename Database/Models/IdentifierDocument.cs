using Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class IdentifierDocument : Entity
    {

        [Required]
        public DocumentType DocumentType { get; set; }

        [Required]
        public Nationality Nationality { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(2)]
        public string? Series { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Number { get; set; }

        public string? IdentificationNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfIssue { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfExpire { get; set; }

        [Required]
        public string? Authority { get; set; }

        public virtual IEnumerable<Employee>? Employees { get; set; }
    }
}
