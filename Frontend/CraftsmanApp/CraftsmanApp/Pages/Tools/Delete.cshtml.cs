using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CraftsmanApp.Data;
using CraftsmanApp.Models;

namespace CraftsmanApp.Pages.Tools
{
    public class DeleteModel : PageModel
    {
        private readonly CraftsmanApp.Data.CraftsmanAppContext _context;

        public DeleteModel(CraftsmanApp.Data.CraftsmanAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tool Tool { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tool = await _context.Tool.FirstOrDefaultAsync(m => m.ID == id);

            if (Tool == null)
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

            Tool = await _context.Tool.FindAsync(id);

            if (Tool != null)
            {
                _context.Tool.Remove(Tool);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
