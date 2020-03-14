using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarpenterAPI.Domain;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CarpenterAPI.Services
{
    public class ToolService
    {
        private readonly IMongoCollection<Tool> _toolCollection;
        
        public ToolService(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration.GetConnectionString("CraftsmanDb"));
            var database = mongoClient.GetDatabase("CraftsmanDb");
            _toolCollection = database.GetCollection<Tool>("Tools");
        }

        public async Task<IEnumerable<Tool>> GetAll()
        {
            return await _toolCollection.FindAsync(_ => true).Result.ToListAsync(); 
        }

        public async Task<Tool> Get(string id)
        {
            return await _toolCollection.FindAsync(tool => tool.ToolId == id).Result.FirstOrDefaultAsync(); 
        }

        public async Task<Tool> Create(Tool value)
        {
            var tool = await _toolCollection.FindAsync(cm => cm.ToolId == value.ToolId).Result.FirstOrDefaultAsync();
            if (tool != null)
                throw new Exception("Tool already exists");
            await _toolCollection.InsertOneAsync(value);
            return value;
        }

        public async Task<Tool> Update(Tool value)
        {
            return await _toolCollection.FindOneAndReplaceAsync(tool => tool.ToolId == value.ToolId, value);
        }

        public async Task Delete(string id)
        {
            await _toolCollection.DeleteOneAsync(tool => tool.ToolId == id);
        }
    }
}