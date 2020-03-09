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

namespace CraftsmanApp.Pages.Craftsmen
{
    public class IndexModel : PageModel
    {
        private readonly CraftsmanClient _client;

        public IndexModel(CraftsmanClient clientFactory)
        {
            _client = clientFactory;
        }

        public IList<Craftsman> Craftsman { get; set; }

        public async Task OnGetAsync()
        {
            Craftsman = (await _client.GetAll()).ToList();

        }
    }
}


