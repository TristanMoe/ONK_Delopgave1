using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CraftsmanApp.Data;
using CraftsmanApp.Models;

namespace CraftsmanApp.Pages.Craftsmen
{
    public class DeleteModel : PageModel
    {
        private readonly CraftsmanApp.Data.CraftsmanAppContext _context;

        public DeleteModel(CraftsmanApp.Data.CraftsmanAppContext context) => _context = context;

        [BindProperty]
        public Craftsman Craftsman { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Craftsman = await _context.Craftsman.FirstOrDefaultAsync(m => m.ID == id);

            if (Craftsman == null)
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

            Craftsman = await _context.Craftsman.FindAsync(id);

            if (Craftsman != null)
            {
                _context.Craftsman.Remove(Craftsman);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
