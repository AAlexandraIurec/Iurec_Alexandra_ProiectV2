using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Iurec_Alexandra_ProiectV2.Data;
using Iurec_Alexandra_ProiectV2.Models;

namespace Iurec_Alexandra_ProiectV2.Pages.Contracts
{
    public class CreateModel : SchedulesPageModel
    {
        private readonly Iurec_Alexandra_ProiectV2.Data.Iurec_Alexandra_ProiectV2Context _context;

        public CreateModel(Iurec_Alexandra_ProiectV2.Data.Iurec_Alexandra_ProiectV2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["OurServiceID"] = new SelectList(_context.Set<OurService>(), "ID", "ServiceName");
            var contract = new Contract();
            contract.Schedules = new List<Schedule>();
            PopulateAssignedEmployeeData(_context, contract);
            return Page();
        }

        [BindProperty]
        public Contract Contract { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedEmployees)
        {
            var newContract = new Contract();
            if (selectedEmployees != null)
            {
                newContract.Schedules = new List<Schedule>();
                foreach (var emp in selectedEmployees)
                {
                    var empToAdd = new Schedule
                    {
                        EmployeeID = int.Parse(emp)
                    };
                    newContract.Schedules.Add(empToAdd);
                }
            }
            if (await TryUpdateModelAsync<Contract>(
            newContract,
            "Contract",
            i => i.Title, i => i.Beneficiary,
            i => i.SigningDate, i => i.OurServiceID))
            {
                _context.Contract.Add(newContract);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedEmployeeData(_context, newContract);
            return Page();
        }
    }
}
