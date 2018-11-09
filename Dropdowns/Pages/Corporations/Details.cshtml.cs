using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dropdowns.Data;
using Dropdowns.Models;

namespace Dropdowns.Pages.Corporations
{
    public class DetailsModel : PageModel
    {
        private readonly Dropdowns.Data.DropdownContext _context;

        public DetailsModel(Dropdowns.Data.DropdownContext context)
        {
            _context = context;
        }

        public Corporation Corporation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Corporation = await _context.Corporations
                .Include(c => c.Continent)
                .Include(c => c.Country).FirstOrDefaultAsync(m => m.CorporationID == id);

            if (Corporation == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
