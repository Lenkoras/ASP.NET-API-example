using Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Education : Entity
    {
        public EducationLevel EducationLevel { get; set; }

        public string? ForeignLanguage { get; set; }

        public string? InstitutionAddress { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfEnd { get; set; }

        public virtual Certificate Certificate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
