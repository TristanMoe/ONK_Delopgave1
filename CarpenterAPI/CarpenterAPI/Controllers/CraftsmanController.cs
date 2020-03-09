using System;
using System.Collections.Generic;
using CarpenterAPI.Domain;
using CarpenterAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarpenterAPI.Controllers
{
    [Route("api/craftsmen")]
    [ApiController]
    public class CraftsmanController : ControllerBase
    {
        private readonly CraftmanService _craftmanService; 

        public CraftsmanController(CraftmanService craftsmanService)
        {
            _craftmanService = craftsmanService; 
        }

        [HttpGet]
        public Craftsman GetCraftsman([FromQuery] string id)
        {
            Craftsman cm = null; 
            try
            {
                cm = _craftmanService.Get(id);
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return cm; 
        } 

        [HttpGet]
        public IEnumerable<Craftsman> GetCraftsmen()
        {
            return _craftmanService.GetAll();
        }
        
        [HttpPost]
        public Craftsman CreateCraftsman([FromBody] Craftsman craftsman)
        {
            try
            {
                return _craftmanService.Create(craftsman);
            } 
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return craftsman;
        }
        
        [HttpPut]
        public Craftsman UpdateCraftsman([FromBody] Craftsman craftsman)
        {
            try
            {
                return _craftmanService.Update(craftsman);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return craftsman;
        }

        [HttpDelete]
        public void DeleteCraftsman([FromQuery] string id)
        {
            _craftmanService.Delete(id);
        }
    }
}