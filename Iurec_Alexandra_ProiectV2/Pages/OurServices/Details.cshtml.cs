using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Iurec_Alexandra_ProiectV2.Data;
using Iurec_Alexandra_ProiectV2.Models;

namespace Iurec_Alexandra_ProiectV2.Pages.OurServices
{
    public class DetailsModel : PageModel
    {
        private readonly Iurec_Alexandra_ProiectV2.Data.Iurec_Alexandra_ProiectV2Context _context;

        public DetailsModel(Iurec_Alexandra_ProiectV2.Data.Iurec_Alexandra_ProiectV2Context context)
        {
            _context = context;
        }

        public OurService OurService { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OurService = await _context.OurService.FirstOrDefaultAsync(m => m.ID == id);

            if (OurService == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
