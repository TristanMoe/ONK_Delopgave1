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

namespace CraftsmanApp.Pages.ToolBoxes
{
    public class IndexModel : PageModel
    {
        private readonly ToolboxClient _client;

        public IndexModel(ToolboxClient client)
        {
            _client = client;
        }

        public IList<Toolbox> Toolbox { get;set; }

        public async Task OnGetAsync()
        {
            Toolbox = (await _client.GetAll()).ToList();
        }
    }
}
