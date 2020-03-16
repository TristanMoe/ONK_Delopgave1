using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarpenterAPI.Services;
using Microsoft.AspNetCore.Mvc;
using CarpenterAPI.Domain;

namespace CarpenterAPI.Controllers
{
    [Route("api/toolbox")]
    [ApiController]
    public class ToolboxController : ControllerBase
    {
        private readonly ToolboxService _toolboxService;

        public ToolboxController(ToolboxService toolboxService)
        {
            _toolboxService = toolboxService;
        }

        // GET: api/toolbox || api/toolbox?id=5
        [HttpGet]
        public async Task<IEnumerable<Toolbox>> Get()
        {
            return await _toolboxService.GetAll(); 
        }

        [HttpGet("{id}")]
        public async Task<Toolbox> Get(string id)
        {
            Toolbox tb = await _toolboxService.Get(id);
            return tb;
        }

        // POST: api/toolbox
        [HttpPost]
        public async Task<Toolbox> Post([FromBody] Toolbox toolbox)
        {
            try
            {
                return await _toolboxService.Create(toolbox);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return toolbox;
        }

        // PUT: api/toolbox
        [HttpPut]
        public async Task<Toolbox> Put([FromBody] Toolbox toolbox)
        {
            return await _toolboxService.Update(toolbox);
        }

        // DELETE: api/toolbox/delete?id=5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _toolboxService.Delete(id);
        }
    }
}
