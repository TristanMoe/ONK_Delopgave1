using System;
using System.Collections.Generic;
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

        // GET: api/ToolBox
        [HttpGet]
        public IEnumerable<Toolbox> GetToolbox()
        {
            return _toolboxService.GetAll();
        }

        // GET: api/ToolBox/5
        [HttpGet]
        public Toolbox Get(string id)
        {
            Toolbox tb = null;
            try
            {
                tb = _toolboxService.Get(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tb;
        }

        // POST: api/ToolBox
        [HttpPost]
        public Toolbox CreateToolbox([FromBody] Toolbox toolbox)
        {            
            try
            {
                return _toolboxService.Create(toolbox);
            } 
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return toolbox;
        }

        // PUT: api/ToolBox/5
        [HttpPut]
        public Toolbox UpdateToolbox([FromBody] Toolbox toolbox)
        {
            try
            {
                return _toolboxService.Update(toolbox);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return toolbox;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public void Delete([FromQuery] string id)
        {
            _toolboxService.Delete(id);
        }
    }
}
