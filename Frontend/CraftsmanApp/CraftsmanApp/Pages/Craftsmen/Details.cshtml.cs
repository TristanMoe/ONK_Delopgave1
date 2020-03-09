using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CraftsmanApp.Data;
using CraftsmanApp.Models;

namespace CraftsmanApp.Pages.Craftsmen
{
    public class DetailsModel : PageModel
    {
        private readonly CraftsmanApp.Data.CraftsmanAppContext _context;

        public DetailsModel(CraftsmanApp.Data.CraftsmanAppContext context)
        {
            _context = context;
        }

        public Craftsman Craftsman { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Craftsman = await _context.Craftsman.FirstOrDefaultAsync(m => m.ID == id);
            if (Craftsman == null)
            {
                return NotFound();
            }
            
            Craftsman.ToolBoxes = await _context.Toolbox.Where(item => item.OwnerId == Craftsman.ID).ToListAsync();

            if (Craftsman.ToolBoxes == null)
            {
                Craftsman.ToolBoxes = new List<Toolbox>();
                return Page();
            }
            var tools = await _context.Tool.Where(item => Craftsman.ToolBoxes.Select(box => box.ID).Contains(item.ToolBoxId)).ToListAsync();

            foreach (var toolbox in Craftsman.ToolBoxes)
            {
                toolbox.Tools = tools.Where(t => t.ToolBoxId == toolbox.ID).ToList();
            }
            return Page();
        }
    }
}
