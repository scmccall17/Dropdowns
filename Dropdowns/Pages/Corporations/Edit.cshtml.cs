using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dropdowns.Data;
using Dropdowns.Models;

namespace Dropdowns.Pages.Corporations
{
    public class EditModel : PageModel
    {
        private readonly Dropdowns.Data.DropdownContext _context;

        public EditModel(Dropdowns.Data.DropdownContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["ContinentID"] = new SelectList(_context.Continents, "ContinentID", "ContinentID");
           ViewData["CountryID"] = new SelectList(_context.Contries, "CountryID", "CountryID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Corporation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorporationExists(Corporation.CorporationID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CorporationExists(int id)
        {
            return _context.Corporations.Any(e => e.CorporationID == id);
        }
    }
}
