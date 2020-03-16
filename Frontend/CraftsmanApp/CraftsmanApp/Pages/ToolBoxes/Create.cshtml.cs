using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CraftsmanApp.Data;
using CraftsmanApp.Models;
using CraftsmanApp.Services;

namespace CraftsmanApp.Pages.ToolBoxes
{
    public class CreateModel : PageModel
    {
        private readonly CraftsmanClient _client;
        private readonly ToolboxClient _toolboxClient;

        public CreateModel(CraftsmanClient clientFactory, ToolboxClient toolClient)
        {
            _toolboxClient = toolClient;
            _client = clientFactory;
        }

        public IActionResult OnGet()
        {
            Craftsmen = _client.GetAll().Result.ToList();
            return Page();
        }

        [BindProperty]
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

            Craftsmen = (await _client.GetAll()).ToList();
            var craftsman = Craftsmen.First(toolbo => toolbo.CraftsmanId == Toolbox.OwnerId);
            craftsman.ToolBoxes.Add(Toolbox);
            await _toolboxClient.Insert(Toolbox);
            await _client.Update(craftsman.CraftsmanId,craftsman);

            return RedirectToPage("./Index");
        }
    }
}
