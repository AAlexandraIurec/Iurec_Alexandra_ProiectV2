using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iurec_Alexandra_ProiectV2.Models
{
    public class OurService
    {
        public int ID { get; set; }
        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }
        [Display(Name = "Service Price")]
        [Column(TypeName = "decimal(6, 2)")]
        [Range(1, 3000)]
        public decimal ServicePrice { get; set; }
        public ICollection<Contract> Contracts { get; set; } //navigation property
    }
}
