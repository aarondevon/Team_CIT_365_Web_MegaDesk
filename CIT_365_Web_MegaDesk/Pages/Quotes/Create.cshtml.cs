﻿using System;
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

        public int DeskSurfaceArea { get; set; }

        public int BasePrice { get; set; }

        public int SurfaceAreaPrice { get; set; }
        public int MaterialPrice { get; set; }

        public int DrawerPrice { get; set; }
        public int RushOrderPrice { get; set; }

        [BindProperty]
        public Quote Quote { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public DateTime QuoteDate { get; set; }

            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
            public async Task<IActionResult> OnPostAsync()
        {
            BasePrice = 200;

            DeskSurfaceArea = Quote.Width * Quote.Depth;

            DrawerPrice = 50 * Quote.Drawers;

            SurfaceAreaPrice = 0;

            GetRushDays = Quote.Rushdays;

            if (DeskSurfaceArea > 1000)
            {
                SurfaceAreaPrice = DeskSurfaceArea;
            }

            switch (Quote.DeskMaterial)
            {
                case "Oak":
                    MaterialPrice = 200;
                    break;
                case "Laminate":
                    MaterialPrice = 100;
                    break;
                case "Pine":
                    MaterialPrice = 50;
                    break;
                case "Rosewood":
                    MaterialPrice = 300;
                    break;
                case "Veneer":
                    MaterialPrice = 125;
                    break;
            }

            if (GetRushDays == 3)
            {
                if (DeskSurfaceArea > 2000)
                {
                    RushOrderPrice = 80;
                }
                else if (DeskSurfaceArea >= 1000 && DeskSurfaceArea <= 2000)
                {
                    RushOrderPrice = 70;
                }
                else
                {
                    RushOrderPrice = 60;
                }
            }

            if(GetRushDays == 5)
            {
                if (DeskSurfaceArea > 2000)
                {
                    RushOrderPrice = 60;
                }
                else if (DeskSurfaceArea >= 1000 && DeskSurfaceArea <= 2000)
                {
                    RushOrderPrice = 50;
                }
                else
                {
                    RushOrderPrice = 40;
                }
            }

            if (GetRushDays == 7)
            {
                if (DeskSurfaceArea > 2000)
                {
                    RushOrderPrice = 40;
                }
                else if (DeskSurfaceArea >= 1000 && DeskSurfaceArea <= 2000)
                {
                    RushOrderPrice = 35;
                }
                else
                {
                    RushOrderPrice = 30;
                }
            }

            Quote.QuoteDate = DateTime.Now;
            Quote.DeskTopArea = DeskSurfaceArea;

            Quote.QuoteTotal = BasePrice + MaterialPrice + RushOrderPrice + SurfaceAreaPrice + DrawerPrice;
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
