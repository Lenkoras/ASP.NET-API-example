using Shared.Enums;

namespace Shared.Models
{
    public class RelationshipFull
    {
        public RelationshipType Type { get; set; }

        public RelativeFull Relative { get; set; }
    }
}
