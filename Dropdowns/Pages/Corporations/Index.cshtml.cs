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
    public class IndexModel : PageModel
    {
        private readonly Dropdowns.Data.DropdownContext _context;

        public IndexModel(Dropdowns.Data.DropdownContext context)
        {
            _context = context;
        }

        public IList<Corporation> Corporation { get;set; }

        public async Task OnGetAsync()
        {
            Corporation = await _context.Corporations
                .Include(c => c.Continent)
                .Include(c => c.Country).ToListAsync();
        }
    }
}
