using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public abstract class AssignmentBase : Entity
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string OrderNumber { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
