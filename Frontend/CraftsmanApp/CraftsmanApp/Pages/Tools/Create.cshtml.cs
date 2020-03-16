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
using Microsoft.CodeAnalysis;

namespace CraftsmanApp.Pages.Tools
{
    public class CreateModel : PageModel
    {
        private readonly ToolClient _toolClient;
        private readonly ToolboxClient _toolboxClient;

        public CreateModel(ToolClient toolClient, ToolboxClient toolboxClient)
        {
            _toolClient = toolClient;
            _toolboxClient = toolboxClient;
        }

        public IActionResult OnGet()
        {
            ToolBox = _toolboxClient.GetAll().Result.ToList();
            
            return Page();
        }

        [BindProperty]
        public List<Toolbox> ToolBox { get; set; }

        [BindProperty]
        public Tool Tool { get; set; }

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
            await _toolClient.Insert(Tool);
            await _toolboxClient.Update(toolbox.ToolboxId,toolbox);

            return RedirectToPage("./Index");
        }
    }
}
