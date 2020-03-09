using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CraftsmanApp.Data;
using CraftsmanApp.Models;

namespace CraftsmanApp.Pages.ToolBoxes
{
    public class IndexModel : PageModel
    {
        private readonly CraftsmanApp.Data.CraftsmanAppContext _context;

        public IndexModel(CraftsmanApp.Data.CraftsmanAppContext context)
        {
            _context = context;
        }

        public IList<Toolbox> Toolbox { get;set; }

        public async Task OnGetAsync()
        {
            Toolbox = await _context.Toolbox.ToListAsync();
        }
    }
}
