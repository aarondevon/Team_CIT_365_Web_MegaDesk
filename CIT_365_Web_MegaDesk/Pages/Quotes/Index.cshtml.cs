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
    public class IndexModel : PageModel
    {
        private readonly CIT_365_Web_MegaDesk.Models.CIT_365_Web_MegaDeskContext _context;

        public IndexModel(CIT_365_Web_MegaDesk.Models.CIT_365_Web_MegaDeskContext context)
        {
            _context = context;
        }

        public IList<Quote> Quote { get;set; }

        public string CustomerSort { get; set; }

        public string DateSort { get; set; }

        public string CurrentFilter { get; set; }

        public string CurrentSort { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchCustomer { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            var customers = from m in _context.Quote
                          select m;

            //Sort
            CustomerSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(s => s.FirstName);
                    break;
                case "Date":
                    customers = customers.OrderBy(s => s.QuoteDate);
                    break;
                case "date_desc":
                    customers = customers.OrderByDescending(s => s.QuoteDate);
                    break;
                default:
                    customers = customers.OrderBy(s => s.FirstName);
                    break;
            }

            //Search
            if (!string.IsNullOrEmpty(SearchCustomer))
            {
                customers = customers.Where(s => s.FirstName.Contains(SearchCustomer));
            }
            //Quote = await _context.Quote.ToListAsync();
            Quote = await customers.ToListAsync();
        }
    }
}
