using System;
using System.Collections.Generic;
using CarpenterAPI.Domain;
using CarpenterAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarpenterAPI.Controllers
{
    [Route("api/craftsmen/")]
    [ApiController]
    public class CraftsmanController : ControllerBase
    {
        private readonly CraftmanService _craftmanService;

        public CraftsmanController(CraftmanService craftsmanService)
        {
            _craftmanService = craftsmanService;
        }

        [HttpGet("{id?}")]
        public IEnumerable<Craftsman> Get([FromQuery] string id)
        {
            if (!Request.QueryString.HasValue)
                return _craftmanService.GetAll();

            Craftsman cm = _craftmanService.Get(id);
            return new[] {cm};
        }

        [HttpPost]
        public Craftsman Post([FromBody] Craftsman craftsman)
        {
            try
            {
                return _craftmanService.Create(craftsman);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return craftsman;
        }

        [HttpPut("{id}")]
        public Craftsman Put([FromQuery] string id, [FromBody] Craftsman craftsman)
        {
            return _craftmanService.Update(id, craftsman);
        }

        [HttpDelete("{id}")]
        public void Delete([FromQuery] string id)
        {
            _craftmanService.Delete(id);
        }
    }
}