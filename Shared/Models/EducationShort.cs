using Shared.Enums;

namespace Shared.Models
{
    public class EducationShort : ShareEntity
    {
        public EducationLevel EducationLevel { get; set; }

        public DateTime? DateOfEnd { get; set; }
    }
}
