using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpenterAPI.Domain;
using CarpenterAPI.Services;
using Microsoft.AspNetCore.Http;
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
        public Craftsman GetCraftsman([FromQuery] string firstname, [FromQuery] string surname)
        {
            Craftsman cm = null; 
            try
            {
                cm = _craftmanService.Get(firstname, surname);
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return cm; 
        } 
    }
}