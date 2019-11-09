using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CIT_365_Web_MegaDesk.Models
{
    public class Quote
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Quote Date")]
        [DataType(DataType.Date)]
        public DateTime QuoteDate { get; set; }
        
        [Range(24, 96)]
        public int Width { get; set; }

        [Range(12, 48)]
        public int Depth { get; set; }

        public int DeskTopArea { get; set; }

        [Range(0, 7)]
        public int Drawers { get; set; }
        public string DeskMaterial { get; set; }

        public int Rushdays { get; set; }
        public decimal QuoteTotal { get; set; }
    }
}
