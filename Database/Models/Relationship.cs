using Shared.Enums;

namespace Database.Models
{
    /// <summary>
    /// Сущность-связь отношения родственника с сотрудником.
    /// </summary>
    public class Relationship : Entity
    {
        /// <summary>
        /// Тип родства.
        /// </summary>
        public RelationshipType Type { get; set; }

        /// <summary>
        /// Родственник.
        /// </summary>
        public virtual Relative? Relative { get; set; }

        /// <summary>
        /// Сотрудник.
        /// </summary>
        public virtual Employee? Employee { get; set; }
    }
}
