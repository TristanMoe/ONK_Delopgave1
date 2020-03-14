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
        [HttpGet("{id?}")]
        public async Task<IEnumerable<Toolbox>> Get([FromQuery] string id)
        {
            if (!Request.QueryString.HasValue)
                return await _toolboxService.GetAll();

            Toolbox tb = await _toolboxService.Get(id);
            return new[] {tb};
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
        public async Task Delete([FromQuery] string id)
        {
            await _toolboxService.Delete(id);
        }
    }
}
