using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CraftsmanApp.Data;
using CraftsmanApp.Models;

namespace CraftsmanApp.Pages.Tools
{
    public class CreateModel : PageModel
    {
        private readonly CraftsmanApp.Data.CraftsmanAppContext _context;

        public CreateModel(CraftsmanApp.Data.CraftsmanAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ToolBox = _context.Toolbox.ToList();
            
            return Page();
        }

        public List<Toolbox> ToolBox { get; set; }
        [BindProperty]
        public Tool Tool { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tool.Add(Tool);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
