using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CIT_365_Web_MegaDesk.Models;

namespace CIT_365_Web_MegaDesk.Pages.Quotes
{
    public class CreateModel : PageModel
    {

        private readonly CIT_365_Web_MegaDesk.Models.CIT_365_Web_MegaDeskContext _context;

        public CreateModel(CIT_365_Web_MegaDesk.Models.CIT_365_Web_MegaDeskContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            
            SetQuoteDate = DateTime.Now;
            return Page();
        }
        
        [ViewData]
        public DateTime SetQuoteDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string GetMaterial { get; set; }

        [BindProperty(SupportsGet = true)]
        public int GetRushDays { get; set; }

        public int BasePrice { get; set; }

        public int materialPrice { get; set; }

        [BindProperty]
        public Quote Quote { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public DateTime QuoteDate { get; set; }

            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
            public async Task<IActionResult> OnPostAsync()
        {
            BasePrice = 200;

            switch (Quote.DeskMaterial)
            {
                case "Oak":
                    materialPrice = 200;
                    break;
                case "Laminate":
                    materialPrice = 100;
                    break;
                case "Pine":
                    materialPrice = 50;
                    break;
                case "Rosewood":
                    materialPrice = 300;
                    break;
                case "Veneer":
                    materialPrice = 125;
                    break;
            }

            Quote.QuoteDate = DateTime.Now;
            Quote.DeskTopArea = Quote.Width * Quote.Depth;

            Quote.QuoteTotal = BasePrice + materialPrice;
            if (!ModelState.IsValid)
            {
                return Page();
            }


         
            _context.Quote.Add(Quote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
