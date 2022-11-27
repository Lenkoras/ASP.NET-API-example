using Shared.Enums;

namespace Shared.Models
{
    public class DocumentFull : ShareEntity
    {
        public DocumentType DocumentType { get; set; }

        public Nationality Nationality { get; set; }

        public string Series { get; set; }

        public string Number { get; set; }

        public string IdentificationNumber { get; set; }

        public DateTime DateOfIssue { get; set; }

        public DateTime DateOfExpire { get; set; }

        public string? Authority { get; set; }
    }
}
