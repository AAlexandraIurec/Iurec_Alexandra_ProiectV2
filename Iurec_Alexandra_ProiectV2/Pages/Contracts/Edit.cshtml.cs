using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Iurec_Alexandra_ProiectV2.Data;
using Iurec_Alexandra_ProiectV2.Models;

namespace Iurec_Alexandra_ProiectV2.Pages.Contracts
{
    public class EditModel : SchedulesPageModel
    {
        private readonly Iurec_Alexandra_ProiectV2.Data.Iurec_Alexandra_ProiectV2Context _context;

        public EditModel(Iurec_Alexandra_ProiectV2.Data.Iurec_Alexandra_ProiectV2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Contract Contract { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contract = await _context.Contract
                 .Include(b => b.OurService)
                 .Include(b => b.Schedules).ThenInclude(b => b.Employee)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ID == id);

            if (Contract == null)
            {
                return NotFound();
            }

            PopulateAssignedEmployeeData(_context, Contract);

            ViewData["OurServiceID"] = new SelectList(_context.Set<OurService>(), "ID", "ServiceName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedEmployees)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractToUpdate = await _context.Contract
            .Include(i => i.OurService)
            .Include(i => i.Schedules)
            .ThenInclude(i => i.Employee)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (contractToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Contract>(
                contractToUpdate,
                "Contract",
                i => i.Title, i => i.Beneficiary,
                i => i.SigningDate, i => i.OurService))
            {
                UpdateSchedules(_context, selectedEmployees, contractToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
           
            UpdateSchedules(_context, selectedEmployees, contractToUpdate);
            PopulateAssignedEmployeeData(_context, contractToUpdate);
            return Page();
        }
    }
}


