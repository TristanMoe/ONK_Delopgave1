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
using Newtonsoft.Json;
using System.Text;

namespace CraftsmanApp.Pages.Craftsmen
{
    public class DeleteModel : PageModel
    {
        private readonly CraftsmanApp.Data.CraftsmanAppContext _context;
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _client;

        public DeleteModel(CraftsmanApp.Data.CraftsmanAppContext context, IHttpClientFactory clientFactory) {
            _context = context;
            _clientFactory = clientFactory;
            _client = _clientFactory.CreateClient("craftsmen");
        }

        [BindProperty]
        public Craftsman Craftsman { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _client.GetAsync(id);
            response.EnsureSuccessStatusCode();
            using var craftsmanresponseStream
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

            var request = new HttpRequestMessage(HttpMethod.Delete, "api/craftsmen/"+Craftsman.ID);
            await _client.SendAsync(request);

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
