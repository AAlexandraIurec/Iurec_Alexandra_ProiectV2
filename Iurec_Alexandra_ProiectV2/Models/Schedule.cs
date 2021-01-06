using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iurec_Alexandra_ProiectV2.Models
{
    public class Schedule
    {
        public int ID { get; set; }
        public int ContractID { get; set; }
        public Contract Contract { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
