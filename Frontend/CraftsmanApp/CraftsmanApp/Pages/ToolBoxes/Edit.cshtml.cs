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

namespace CraftsmanApp.Pages.ToolBoxes
{
    public class EditModel : PageModel
    {
        private readonly ToolboxClient _toolboxClient;
        private readonly CraftsmanClient _craftsmanClient;

        public EditModel(ToolboxClient toolboxClient, CraftsmanClient craftsmanClient)
        {
            _toolboxClient = toolboxClient;
            _craftsmanClient = craftsmanClient;
        }

        [BindProperty]
        public Toolbox Toolbox { get; set; }

        [BindProperty]
        public List<Craftsman> Craftsmen { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Craftsmen = (await _craftsmanClient.GetAll()).ToList();
            Toolbox = await _toolboxClient.Get(id);

            if (Toolbox == null)
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

            Craftsmen = (await _craftsmanClient.GetAll()).ToList();
            var craftsman = Craftsmen.First(toolbo => toolbo.CraftsmanId == Toolbox.OwnerId);
            craftsman.ToolBoxes.Add(Toolbox);
            var exists = await _toolboxClient.Get(Toolbox.ToolboxId);
            if (exists == null)
            {
                await _toolboxClient.Insert(Toolbox);
            }
            else
            {
                Toolbox.Tools = exists.Tools;
            }

            await _toolboxClient.Update(Toolbox.ToolboxId, Toolbox);
            await _craftsmanClient.Update(craftsman.CraftsmanId, craftsman);
            return RedirectToPage("./Index");
        }
    }
}
