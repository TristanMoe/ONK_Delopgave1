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
using CraftsmanApp.Services;

namespace CraftsmanApp.Pages.Craftsmen
{
    public class EditModel : PageModel
    {
        private readonly CraftsmanClient _client;

        public EditModel(CraftsmanApp.Data.CraftsmanAppContext context, CraftsmanClient clientFactory)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var exists = _client.Get(Craftsman.ID);
            if (exists == null)
            {
                await _client.Insert(Craftsman);
            }

            await _client.Update(Craftsman.ID, Craftsman);

            return RedirectToPage("./Index");
        }
    }
}
