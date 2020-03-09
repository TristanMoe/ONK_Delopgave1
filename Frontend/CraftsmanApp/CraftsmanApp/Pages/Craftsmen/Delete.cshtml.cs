using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CraftsmanApp.Data;
using CraftsmanApp.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CraftsmanApp.Services;

namespace CraftsmanApp.Pages.Craftsmen
{
    public class DeleteModel : PageModel
    {
        private readonly CraftsmanClient _client;

        public DeleteModel(CraftsmanClient clientFactory)
        {
            _client = clientFactory;
        }

        [BindProperty]
        public Craftsman Craftsman { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Craftsman = await _client.Get(id);

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

            Craftsman = await _client.Get(id);

            if (Craftsman != null)
            {
                await _client.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
