using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CraftsmanApp.Data;
using CraftsmanApp.Models;

namespace CraftsmanApp.Pages.ToolBoxes
{
    public class DetailsModel : PageModel
    {
        private readonly CraftsmanApp.Data.CraftsmanAppContext _context;

        public DetailsModel(CraftsmanApp.Data.CraftsmanAppContext context)
        {
            _context = context;
        }

        public Toolbox Toolbox { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Toolbox = await _context.Toolbox.FirstOrDefaultAsync(m => m.ID == id);

            if (Toolbox == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
