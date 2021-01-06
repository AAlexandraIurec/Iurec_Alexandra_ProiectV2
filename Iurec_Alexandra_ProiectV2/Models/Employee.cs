using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Iurec_Alexandra_ProiectV2.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "The employee's name must be in the form 'First Name Last Name'"), Required, StringLength(60, MinimumLength = 5)]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Display(Name = "Employee Email")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "The email address must contain the @ sign and a domain."), StringLength(70, MinimumLength = 4)]
        public string EmployeeEmail { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
