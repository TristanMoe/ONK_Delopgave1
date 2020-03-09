using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CraftsmanApp.Data;
using CraftsmanApp.Models;

namespace CraftsmanApp.Pages.Tools
{
    public class EditModel : PageModel
    {
        private readonly CraftsmanApp.Data.CraftsmanAppContext _context;

        public EditModel(CraftsmanApp.Data.CraftsmanAppContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tool).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToolExists(Tool.ID))
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

        private bool ToolExists(string id)
        {
            return _context.Tool.Any(e => e.ID == id);
        }
    }
}
