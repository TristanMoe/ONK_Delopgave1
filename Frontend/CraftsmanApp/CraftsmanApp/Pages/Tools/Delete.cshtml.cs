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

namespace CraftsmanApp.Pages.Tools
{
    public class DeleteModel : PageModel
    {
        private readonly ToolClient _toolClient;

        public DeleteModel(ToolClient toolClient)
        {
            _toolClient = toolClient;
        }

        [BindProperty]
        public Tool Tool { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tool = await _toolClient.Get(id);

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

            Tool = await _toolClient.Get(id);

            if (Tool != null)
            {
                await _toolClient.Delete(id);

            }

            return RedirectToPage("./Index");
        }
    }
}
