namespace Database.Models
{
    /// <summary>
    /// Сущность родственника.
    /// </summary>
    public class Relative : Entity
    {
        /// <summary>
        /// Полное имя.
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Место работы.
        /// </summary>
        public string Workplace { get; set; }

        /// <summary>
        /// Должность на работе.
        /// </summary>
        public string Position { get; set; }

        public virtual IEnumerable<Relationship> RelationShips { get; set; }
    }
}
