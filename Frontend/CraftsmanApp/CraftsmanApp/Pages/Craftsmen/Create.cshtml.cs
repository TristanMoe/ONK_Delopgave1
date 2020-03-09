using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CraftsmanApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace CraftsmanApp.Pages.Craftsmen
{
    public class CreateModel : PageModel
    {
        private readonly CraftsmanApp.Data.CraftsmanAppContext _context;
        private readonly System.Net.Http.IHttpClientFactory _clientFactory;

        public CreateModel(CraftsmanApp.Data.CraftsmanAppContext context, System.Net.Http.IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
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
            var request = new HttpRequestMessage(HttpMethod.Post, "api/craftsmen/");
            var content = new StringContent(JsonConvert.SerializeObject(Craftsman), Encoding.UTF8, "application/json");
            request.Content = content;
            var client = _clientFactory.CreateClient("craftsmen");
            await client.SendAsync(request);

            _context.Craftsman.Add(Craftsman);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
