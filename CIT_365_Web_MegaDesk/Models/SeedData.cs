using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CIT_365_Web_MegaDesk.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CIT_365_Web_MegaDeskContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CIT_365_Web_MegaDeskContext>>()))
            {
                // Look for any Quotes.
                if (context.Quote.Any())
                {
                    return;   // DB has been seeded
                }

                context.Quote.AddRange(
                    new Quote
                    {
                        FirstName = "Miss",
                        LastName = "Piggy",
                        QuoteDate = DateTime.Parse("2019-10-29"),
                        Width = 96,
                        Depth = 48,
                        DeskTopArea = 4608,
                        Drawers = 7,
                        DeskMaterial = "Rosewood",
                        Rushdays = 3,
                        QuoteTotal = 5538
                    },

                    new Quote
                    {
                        FirstName = "Kermit",
                        LastName = "The Frog",
                        QuoteDate = DateTime.Parse("2019-10-28"),
                        Width = 24,
                        Depth = 12,
                        DeskTopArea = 288,
                        Drawers = 0,
                        DeskMaterial = "Pine",
                        Rushdays = 0,
                        QuoteTotal = 250
                    },

                    new Quote
                    {
                        FirstName = "Elora",
                        LastName = "Danan",
                        QuoteDate = DateTime.Parse("2019-10-27"),
                        Width = 30,
                        Depth = 30,
                        DeskTopArea = 900,
                        Drawers = 2,
                        DeskMaterial = "Oak",
                        Rushdays = 5,
                        QuoteTotal = 540
                    },

                    new Quote
                    {
                        FirstName = "Princess",
                        LastName = "Buttercup",
                        QuoteDate = DateTime.Parse("2019-11-09"),
                        Width = 60,
                        Depth = 24,
                        DeskTopArea = 1440,
                        Drawers = 2,
                        DeskMaterial = "Rosewood",
                        Rushdays = 7,
                        QuoteTotal = 2075
                    }
                );
                context.SaveChanges();
            }
        }
    }
}