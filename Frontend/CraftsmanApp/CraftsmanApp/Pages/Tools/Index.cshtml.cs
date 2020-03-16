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

namespace CraftsmanApp.Pages.Tools
{
    public class IndexModel : PageModel
    {
        private readonly ToolClient _client;

        public IndexModel(ToolClient client)
        {
            _client = client;
        }

        public IList<Tool> Tool { get;set; }

        public async Task OnGetAsync()
        {

            Tool = (await _client.GetAll()).ToList();
        }
    }
}
