using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iurec_Alexandra_ProiectV2.Models
{
    public class Contract
    {
        public int ID { get; set; }
        [Display(Name = "Contract Title")]
        [Required, StringLength(200, MinimumLength = 10, ErrorMessage = "The length of the title must be between 10 and 200 characters")]
        public string Title { get; set; }
        [Display(Name = "Beneficiary Name")]
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "The name of the beneficiary must be in the form 'First name Last name'"), Required, StringLength(60, MinimumLength = 5)]
        public string Beneficiary { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Signing Date")]
        public DateTime SigningDate { get; set; }

        public int OurServiceID { get; set; }
        public OurService OurService { get; set; }

        public ICollection<Schedule> Schedules { get; set; }

    }
}
