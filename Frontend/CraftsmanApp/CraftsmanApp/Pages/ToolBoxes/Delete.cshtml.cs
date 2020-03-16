using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CraftsmanApp.Data;
using CraftsmanApp.Models;
using CraftsmanApp.Services;

namespace CraftsmanApp.Pages.ToolBoxes
{
    public class DeleteModel : PageModel
    {
        private readonly ToolboxClient _client;

        public DeleteModel(ToolboxClient client)
        {
            _client = client;
        }

        [BindProperty]
        public Toolbox Toolbox { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Toolbox = await _client.Get(id);

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

            Toolbox = await _client.Get(id);

            if (Toolbox != null)
            {
                await _client.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
