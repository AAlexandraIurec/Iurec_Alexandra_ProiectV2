using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iurec_Alexandra_ProiectV2.Models
{
    public class ContractData
    {
        public IEnumerable<Contract> Contracts { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
    }
}
