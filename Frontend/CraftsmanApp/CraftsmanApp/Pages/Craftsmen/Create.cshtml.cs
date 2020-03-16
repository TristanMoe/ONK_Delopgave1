using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CraftsmanApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using CraftsmanApp.Services;

namespace CraftsmanApp.Pages.Craftsmen
{
    public class CreateModel : PageModel
    {
        private readonly CraftsmanClient _client;

        public CreateModel(CraftsmanClient clientFactory)
        {
            _client = clientFactory;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Craftsman Craftsman { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _client.Insert(Craftsman);

            return RedirectToPage("./Index");
        }
    }
}
