using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public abstract class AssignmentBaseFull
    {
        public string OrderNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
