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
    public class DetailsModel : PageModel
    {
        private readonly ToolClient _client;

        public DetailsModel(ToolClient client)
        {
            _client = client;
        }

        public Tool Tool { get; set; }
       

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tool = await _client.Get(id);

            if (Tool == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
