using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Certificate : Entity
    {
        public string Number { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public float AverageMark { get; set; }

        public virtual IEnumerable<Education> Educations { get; set; }
    }
}