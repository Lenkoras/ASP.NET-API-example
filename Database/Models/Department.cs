using Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Department : Entity
    {
        [Required]
        [MaxLength(200)]
        public string? Name { get; set; }

        public DepartmentType Type { get; set; }

        public virtual IEnumerable<Employee> Employees { get; set; }

        public virtual Department? ParentDepartment { get; set; }

        public virtual IEnumerable<Department> SubDepartment { get; set; }

    }
}
