namespace Shared.Models
{
    public class EducationFull : EducationShort
    {
        public string? ForeignLanguage { get; set; }

        public string? InstitutionAddress { get; set; }

        public DateTime DateOfStart { get; set; }
    }
}