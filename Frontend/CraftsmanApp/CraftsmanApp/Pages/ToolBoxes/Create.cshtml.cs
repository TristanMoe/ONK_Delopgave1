using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CraftsmanApp.Data;
using CraftsmanApp.Models;

namespace CraftsmanApp.Pages.ToolBoxes
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
            Craftsmen = _context.Craftsman.ToList();
            return Page();
        }

        public List<Craftsman> Craftsmen { get; set; }

        [BindProperty]
        public Toolbox Toolbox { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Toolbox.Add(Toolbox);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
