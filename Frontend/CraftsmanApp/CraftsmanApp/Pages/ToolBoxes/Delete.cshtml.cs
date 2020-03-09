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
    public class DeleteModel : PageModel
    {
        private readonly CraftsmanApp.Data.CraftsmanAppContext _context;

        public DeleteModel(CraftsmanApp.Data.CraftsmanAppContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Toolbox = await _context.Toolbox.FindAsync(id);

            if (Toolbox != null)
            {
                _context.Toolbox.Remove(Toolbox);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
