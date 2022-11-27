using Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    /// <summary>
    /// Сущность работника (военнослужащий или гражданский).
    /// </summary>
    public class Employee : Entity
    {
        /// <summary>
        /// Имя.
        /// </summary>
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string MiddleName { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Предыдущее имя.
        /// </summary>
        [MinLength(2)]
        [MaxLength(50)]
        public string? PreviousLastName { get; set; }

        /// <summary>
        /// Местро прописки.
        /// </summary>
        [MinLength(10)]
        [MaxLength(100)]
        public string? Address { get; set; }

        /// <summary>
        /// Место проживания.
        /// </summary>
        [MinLength(10)]
        [MaxLength(100)]
        public string? ActualAddress { get; set; }

        /// <summary>
        /// Дата дня рождения.
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime BirthdayDate { get; set; }

        /// <summary>
        /// Дата призыва.
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime RecruitingDate { get; set; }

        /// <summary>
        /// Номер мобильного телефона.
        /// </summary>
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        /// <summary>
        /// Номер домашнего телефона.
        /// </summary>
        public string? HomePhone { get; set; }

        /// <summary>
        /// Выслуга лет.
        /// </summary>
        public float PeriodOfService { get; set; }

        /// <summary>
        /// Пол человека.
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Номер жетона.
        /// </summary>
        public string? BadgeNumber { get; set; }

        /// <summary>
        /// Номер оружия.
        /// </summary>
        public string? WeaponNumber { get; set; }

        /// <summary>
        /// Номер дела.
        /// </summary>
        public string? AffairNumber { get; set; }

        /// <summary>
        /// Женат/замужем.
        /// </summary>
        public bool IsMarried { get; set; }

        /// <summary>
        /// Электронная почта.
        /// </summary>
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        /// <summary>
        /// <see langword="true"/> если работника можно выводить в запросах.
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// Идентифицирующий документ.
        /// </summary>
        public virtual IdentifierDocument? Document { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        public string? Position { get; set; }

        /// <summary>
        /// Отдел или отделение, к которому принадлежит работник.
        /// </summary>
        public virtual Department? Department { get; set; }

        public virtual IEnumerable<Relationship> Relationships { get; set; }

        /// <summary>
        /// Предыдущие места работы человека.
        /// </summary>
        public virtual IEnumerable<Workplace> Workplaces { get; set; }

        /// <summary>
        /// Присвоенные военнослужащему звания за всё время службы.
        /// </summary>
        public virtual IEnumerable<RankAssignment> RankAssignments { get; set; }

        /// <summary>
        /// Присвоенные работнику должности за всё время работы.
        /// </summary>
        public virtual IEnumerable<PositionAssignment> PositionAssignments { get; set; }

        /// <summary>
        /// Полученные образования за всё время жизни.
        /// </summary>
        public virtual IEnumerable<Education> Educations { get; set; }

        public static string FullName(Employee emp) =>
            string.Join(' ', emp.LastName, emp.FirstName, emp.MiddleName);
    }
}
