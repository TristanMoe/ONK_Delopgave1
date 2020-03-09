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

namespace CraftsmanApp.Pages.Craftsmen
{
    public class DetailsModel : PageModel
    {
        private readonly CraftsmanClient _client;

        public DetailsModel(CraftsmanApp.Data.CraftsmanAppContext context, CraftsmanClient clientFactory)
        {
            _client = clientFactory;
        }

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
    }
}
