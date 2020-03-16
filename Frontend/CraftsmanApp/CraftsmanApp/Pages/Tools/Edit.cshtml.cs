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

namespace CraftsmanApp.Pages.Tools
{
    public class EditModel : PageModel
    {
        private readonly ToolClient _toolClient;
        private readonly ToolboxClient _toolboxClient;

        public EditModel(ToolClient toolClient, ToolboxClient toolboxClient)
        {
            _toolClient = toolClient;
            _toolboxClient = toolboxClient;
        }

        [BindProperty]
        public Tool Tool { get; set; }

        [BindProperty]
        public List<Toolbox> ToolBox { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToolBox = (await _toolboxClient.GetAll()).ToList();
            Tool = await _toolClient.Get(id);

            if (Tool == null)
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

            ToolBox = (await _toolboxClient.GetAll()).ToList();
            var toolbox = ToolBox.First(toolbo => toolbo.ToolboxId == Tool.ToolBoxId);
            toolbox.Tools.Add(Tool);
            var exists = await _toolClient.Get(Tool.ToolId);
            if (exists == null)
            {
                await _toolClient.Insert(Tool);
            }

            await _toolClient.Update(Tool.ToolId, Tool);
            await _toolboxClient.Update(toolbox.ToolboxId, toolbox);

            return RedirectToPage("./Index");
        }

    }
}
