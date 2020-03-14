using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarpenterAPI.Domain;
using CarpenterAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarpenterAPI.Controllers
{
    [Route("api/craftsmen/")]
    [ApiController]
    public class CraftsmanController : ControllerBase
    {
        private readonly CraftsmanService _craftsmanService;

        public CraftsmanController(CraftsmanService craftsmanService)
        {
            _craftsmanService = craftsmanService;
        }

        // GET: api/craftsmen || api/craftsmen?id=5
        [HttpGet("{id?}")]
        public async Task<IEnumerable<Craftsman>> Get([FromQuery] string id)
        {
            if (!Request.QueryString.HasValue)
                return await _craftsmanService.GetAll();

            Craftsman cm = await _craftsmanService.Get(id);
            return new[] {cm};
        }

        // POST: api/craftsmen
        [HttpPost]
        public async Task<Craftsman> Post([FromBody] Craftsman craftsman)
        {
            try
            {
                return await _craftsmanService.Create(craftsman);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return craftsman;
        }

        // PUT: api/craftsmen
        [HttpPut]
        public async Task<Craftsman> Put([FromBody] Craftsman craftsman)
        {
            return await _craftsmanService.Update(craftsman);
        }

        // DELETE: api/craftsmen/delete?id=5
        [HttpDelete("{id}")]
        public async Task Delete([FromQuery] string id)
        {
            await _craftsmanService.Delete(id);
        }
    }
}