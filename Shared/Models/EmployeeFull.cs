using Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class EmployeeFull : ShareEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        public string PreviousLastName { get; set; }

        public string Address { get; set; }

        public string ActualAddress { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthdayDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime RecruitingDate { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public string HomePhone { get; set; }

        public float PeriodOfService { get; set; }

        public Sex Sex { get; set; }

        public string BadgeNumber { get; set; }

        public string WeaponNumber { get; set; }

        public string AffairNumber { get; set; }

        public bool IsMarried { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
