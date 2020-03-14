﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarpenterAPI.Domain;
using CarpenterAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarpenterAPI.Controllers
{
    [Route("api/tool")]
    [ApiController]
    public class ToolController : ControllerBase
    {
        private readonly ToolService _toolService;

        public ToolController(ToolService toolService)
        {
            _toolService = toolService;
        }

        // GET: api/tool || api/tool?id=5
        [HttpGet("{id?}")]
        public async Task<IEnumerable<Tool>> Get([FromQuery] string id)
        {
            if (!Request.QueryString.HasValue)
                return await _toolService.GetAll();

            Tool tool = await _toolService.Get(id);
            return new[] {tool};
        }

        // POST: api/tool
        [HttpPost]
        public async Task<Tool> Post([FromBody] Tool tool)
        {
            try
            {
                return await _toolService.Create(tool);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tool;
        }

        // PUT: api/tool
        [HttpPut]
        public async Task<Tool> Put([FromBody] Tool tool)
        {
            return await _toolService.Update(tool);
        }

        // DELETE: api/tool/delete?id=5
        [HttpDelete("{id}")]
        public async Task Delete([FromQuery] string id)
        {
            await _toolService.Delete(id);
        }
    }
}
