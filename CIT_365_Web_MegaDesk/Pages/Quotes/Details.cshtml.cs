using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIT_365_Web_MegaDesk.Models;

namespace CIT_365_Web_MegaDesk.Pages.Quotes
{
    public class DetailsModel : PageModel
    {
        private readonly CIT_365_Web_MegaDesk.Models.CIT_365_Web_MegaDeskContext _context;

        public DetailsModel(CIT_365_Web_MegaDesk.Models.CIT_365_Web_MegaDeskContext context)
        {
            _context = context;
        }

        public Quote Quote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quote = await _context.Quote.FirstOrDefaultAsync(m => m.ID == id);

            if (Quote == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
