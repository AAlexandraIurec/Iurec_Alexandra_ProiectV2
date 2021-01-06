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
    public class DetailsModel : PageModel
    {
        private readonly Iurec_Alexandra_ProiectV2.Data.Iurec_Alexandra_ProiectV2Context _context;

        public DetailsModel(Iurec_Alexandra_ProiectV2.Data.Iurec_Alexandra_ProiectV2Context context)
        {
            _context = context;
        }

        public Contract Contract { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contract = await _context.Contract.Include(c => c.OurService).FirstOrDefaultAsync(m => m.ID == id);

            if (Contract == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
