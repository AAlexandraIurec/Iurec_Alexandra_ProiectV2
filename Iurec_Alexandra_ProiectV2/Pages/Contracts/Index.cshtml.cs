using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Iurec_Alexandra_ProiectV2.Data;
using Iurec_Alexandra_ProiectV2.Models;

namespace Iurec_Alexandra_ProiectV2.Pages.Contracts
{
    public class IndexModel : PageModel
    {
        private readonly Iurec_Alexandra_ProiectV2.Data.Iurec_Alexandra_ProiectV2Context _context;

        public IndexModel(Iurec_Alexandra_ProiectV2.Data.Iurec_Alexandra_ProiectV2Context context)
        {
            _context = context;
        }

        public IList<Contract> Contract { get;set; }

        public ContractData ContractD { get; set; }
        public int ContractID { get; set; }
        public int EmployeeID { get; set; }
        public async Task OnGetAsync(int? id, int? employeeID)
        {
            ContractD = new ContractData();

            ContractD.Contracts = await _context.Contract
            .Include(b => b.OurService)
            .Include(b => b.Schedules)
            .ThenInclude(b => b.Employee)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();
            if (id != null)
            {
                ContractID = id.Value;
                Contract contract = ContractD.Contracts
                .Where(i => i.ID == id.Value).Single();
               ContractD.Employees = contract.Schedules.Select(s => s.Employee);
            }
        }

    }
}
